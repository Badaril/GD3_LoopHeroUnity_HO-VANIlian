using UnityEngine;

public class FightController: MonoBehaviour, IActivable
{
    [SerializeField] private Camera _playerCam;
    [SerializeField] private Camera _fightingCam;
    [SerializeField] private Pawn _player;
    [SerializeField] private Monster _monster;
    private bool _fight;

    public void CellAction(Pawn playerPawn)
    {
        _playerCam.gameObject.SetActive(false);
        _fightingCam.gameObject.SetActive(true);
        _player = playerPawn;
        playerPawn.GetComponent<DamageComponent>()._fightController = this;
        _monster.GetComponent<DamageComponent>()._fightController = this;
        StartFight();

    }

    private void StartFight()
    {
        _fight = true;
        _player.SetStamina(0);
        _monster._isAttacking = true;
        _monster.Attack();
    }

    public bool GetFightState() 
    {  
        return _fight; 
    }

    private void FixedUpdate()
    {
        if (_fight)
        {
            //_monster.GetComponent<DamageComponent>().DealDamage(_player.gameObject);
            if (_player.GetStamina() >= 60)
            {
                _player.GetComponent<DamageComponent>().DealDamage(_monster.gameObject);
            }
            if (_monster.Attack())
            {
                Debug.Log("hvhv");
                _monster.GetComponent<DamageComponent>().DealDamage(_player.gameObject);
            }
        }
        Debug.Log(GetFightState());
        Debug.Log(Time.deltaTime);
    }

    private void UpdateFight()
    {
        _monster.GetComponent<DamageComponent>().GetHealth();
        _player.GetComponent<DamageComponent>().GetHealth();
    }

    public void FightOver()
    {
        _fight = false;
        _playerCam.gameObject.SetActive(true);
        _fightingCam.gameObject.SetActive(false);
        Destroy(this);
    }
}
