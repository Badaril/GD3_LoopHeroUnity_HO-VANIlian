using UnityEngine;
using UnityEngine.AI;

public enum StateType
{
    None,
    Patrol,
    Follow,
    Attack,
}

public class IAController : MonoBehaviour
{
    [SerializeField] private StateType state = StateType.None;
    [SerializeField] private StateType newState = StateType.None;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject navPoint;
    [SerializeField] private LabyrinthManager labyrinthManager;

    private float patrolRadius = 100f;
    private float arrivalDistance = 0.5f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private SightPerception _sight;

    private bool _isWaiting;
    private float timer;

    private void Start()
    {
        // Cache des composants pour éviter les GetComponent répétés
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _sight = GetComponent<SightPerception>();

        SetNewRandomDestination();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);

        if (TestChangeState())
        {
            ChangeState();
        }
        Behaviour();

        Debug.Log(_isWaiting);
        Debug.Log(timer);
    }

    private void Behaviour()
    {
        switch (state)
        {
            case StateType.Patrol:
                PatrolBehaviour();
                break;

            case StateType.Follow:
                FollowBehaviour();
                break;

            case StateType.Attack:
                AttackBehaviour();
                break;
        }
    }

    private void BeginState()
    {
        switch (state)
        {
            case StateType.Follow:
                _agent.speed = 3.5f;
                break;

            case StateType.Patrol:
                _agent.stoppingDistance = arrivalDistance;
                _agent.speed = 3.5f;
                SetNewRandomDestination(); // Nouveau point dès qu'on entre en Patrol
                break;

            case StateType.Attack:
                _animator.SetBool("Attack", true);
                _agent.stoppingDistance = _animator.GetFloat("AttackRange");
                break;
        }
    }

    private void EndState()
    {
        switch (state)
        {
            case StateType.Follow:
                _agent.SetDestination(transform.position);
                _agent.stoppingDistance = _animator.GetFloat("AttackRange");
                _agent.speed = 0f;
                break;

            case StateType.Patrol:
                _isWaiting = true;
                _agent.SetDestination(transform.position);
                _agent.speed = 0f;
                break;

            case StateType.Attack:
                _animator.SetBool("Attack", false);
                break;
        }
    }

    private void ChangeState()
    {
        EndState();
        state = newState;
        BeginState();
    }

    private bool TestChangeState()
    {
        switch (state)
        {
            case StateType.Follow:
                if (!_sight.isDetected)
                {
                    newState = StateType.Patrol;
                    return true;
                }
                if (Vector3.Distance(target.transform.position, transform.position) <= _animator.GetFloat("AttackRange"))
                {
                    newState = StateType.Attack;
                    return true;
                }
                break;

            case StateType.Patrol:
                if (_sight.isDetected)
                {
                    newState = StateType.Follow;
                    return true;
                }
                if (Vector3.Distance(target.transform.position, transform.position) <= _animator.GetFloat("AttackRange"))
                {
                    newState = StateType.Attack;
                    return true;
                }
                break;

            case StateType.Attack:
                if (!_sight.isDetected)
                {
                    newState = StateType.Patrol;
                    return true;
                }
                if (Vector3.Distance(target.transform.position, transform.position) > _animator.GetFloat("AttackRange"))
                {
                    newState = StateType.Follow;
                    return true;
                }
                break;
        }
        return false;
    }

    private void PatrolBehaviour()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= arrivalDistance)
        {
            if (!_isWaiting)
            {
                // Vient d'arriver : démarre l'attente
                _isWaiting = true;
                timer = 0f;
                _agent.speed = 0f;
            }
            else
            {
                // Décompte
                timer += Time.deltaTime; //  additionne
                if (timer >= 0.5f)
                {
                    _isWaiting = false;
                    timer = 0f;
                    _agent.speed = 3.5f;
                    SetNewRandomDestination();
                }
            }
        }
    }


    private void FollowBehaviour()
    {
        _agent.SetDestination(target.transform.position);
    }

    private void AttackBehaviour()
    {
        _animator.SetTrigger("Kick");
        labyrinthManager.EndRunInLabyrinth(true);
    }

    private void SetNewRandomDestination()
    {
        Vector3 randomPoint = GetRandomNavMeshPoint();
        _agent.SetDestination(randomPoint);
    }

    private Vector3 GetRandomNavMeshPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, patrolRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return transform.position;
    }
}