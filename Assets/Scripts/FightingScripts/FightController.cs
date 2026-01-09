using UnityEngine;

public class FightController: MonoBehaviour, IActivable
{
    [SerializeField] private Camera _playerCam;
    [SerializeField] private Camera _fightingCam;
    private Pawn _player;
    [SerializeField] private Monster _monster;
    [SerializeField] private UIPlayerDatasController _playerDatasController;
    private bool _fight;

    public void CellAction(Pawn playerPawn)
    {
        if (_monster != null) {
            //_monster.GetComponent<MonsterDatas>()._health = 9;
            _playerDatasController.UpdateHealth(false, 1000);
            _playerCam.gameObject.SetActive(false);
            _fightingCam.gameObject.SetActive(true);
            _player = playerPawn;
            playerPawn.GetComponent<DamageComponent>()._fightController = this;
            _monster.GetComponent<DamageComponent>()._fightController = this;
            StartFight();
        }
    }

    private void StartFight()
    {
        _fight = true;
        _player.SetStamina(0);
        _playerDatasController.SetFightingHUD(true);
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
            _playerDatasController.UpdateStamina(_player.GetStamina());
            if ((_player.GetStamina() >= 60) & (!(_player.GetComponent<DamageComponent>()._attackCooldown)))
            {
                _player.GetComponent<DamageComponent>().DealDamage(_monster.gameObject);
                UpdateFight(false);
            }
            if (!(_monster.GetComponent<DamageComponent>()._attackCooldown))
            {
                _monster.GetComponent<DamageComponent>().DealDamage(_player.gameObject);
                UpdateFight(true);
            }
        }
    }

    private void UpdateFight(bool isPlayer)
    {
        if (isPlayer)
        {
            _playerDatasController.UpdateHealth(true, _player.GetComponent<DamageComponent>().GetHealth());
        }
        else
        {
            _playerDatasController.UpdateHealth(false, _monster.GetComponent<DamageComponent>().GetHealth());
        }
    }

    public void FightOver()
    {
        _fight = false;
        _playerDatasController.SetFightingHUD(false);
        _playerCam.gameObject.SetActive(true);
        _fightingCam.gameObject.SetActive(false);
        
    }
}
