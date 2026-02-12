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

    private void Update()
    {
        GetComponent<Animator>().SetFloat("Speed", GetComponent<NavMeshAgent>().velocity.magnitude);
        //Debug.Log(GetComponent<Animator>().GetFloat("Speed"));
        if (TestChangeState())
        {
            ChangeState();
        }
        Behaviour();
    }

    private void Behaviour()
    {
        switch (state)
        {
            // faire en sorte qu'il se déplac random dans une zone
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
                //GetComponent<Animator>().SetTrigger("Taunting");
                //à mettre dans un scriptable object
                GetComponent<NavMeshAgent>().speed = 3.5f;
                break;

            case StateType.Patrol:
                GetComponent<NavMeshAgent>().stoppingDistance = 0.5f;
                //à mettre dans un scriptable object
                GetComponent<NavMeshAgent>().speed = 2f;
                break;

            case StateType.Attack:
                GetComponent<Animator>().SetBool("Attack", true);
                GetComponent<NavMeshAgent>().stoppingDistance = GetComponent<Animator>().GetFloat("AttackRange");
                break;
        }
    }

    private void EndState()
    {
        switch (state)
        {
            case StateType.Follow:
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
                GetComponent<NavMeshAgent>().stoppingDistance = GetComponent<Animator>().GetFloat("AttackRange");
                GetComponent<NavMeshAgent>().speed = 0f;
                break;
            
            case StateType.Patrol:
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
                GetComponent<NavMeshAgent>().speed = 0f;
                break;

            case StateType.Attack:
                GetComponent<Animator>().SetBool("Attack", false);
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
                if (!GetComponent<SightPerception>().isDetected)
                {
                    newState = StateType.Patrol;
                    return true;
                }

                if (Vector3.Distance(target.transform.position, transform.position) <= GetComponent<Animator>().GetFloat("AttackRange"))
                {
                    newState = StateType.Attack; 
                    return true;
                }
                break;

            case StateType.Patrol:
                if (GetComponent<SightPerception>().isDetected)
                {
                    newState = StateType.Follow;
                    return true;
                }

                if (Vector3.Distance(target.transform.position, transform.position) <= GetComponent<Animator>().GetFloat("AttackRange"))
                {
                    newState = StateType.Attack;
                    return true;
                }
                break;

            case StateType.Attack:
                if (!GetComponent<SightPerception>().isDetected)
                {
                    newState = StateType.Patrol;
                    return true;
                }

                if (Vector3.Distance(target.transform.position, transform.position) > GetComponent<Animator>().GetFloat("AttackRange"))
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
        GetComponent<NavMeshAgent>().SetDestination(navPoint.transform.position);
        //GetComponent<Animator>().SetTrigger("Stretching");
    }
    private void FollowBehaviour()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }
    private void AttackBehaviour()
    {
        GetComponent<Animator>().SetTrigger("Kick");
    }
}
