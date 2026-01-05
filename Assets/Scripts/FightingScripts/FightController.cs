using UnityEngine;

public class FightController: MonoBehaviour, IActivable
{
    [SerializeField] private Camera _playerCam;
    [SerializeField] private Camera _fightingCam;
    [SerializeField] private Pawn _player;
    [SerializeField] private Monster _monster;

    public void CellAction(Pawn playerPawn)
    {
        _playerCam.gameObject.SetActive(false);
        _fightingCam.gameObject.SetActive(true);
        _player = playerPawn;

    }

    private void FixedUpdate()
    {
        if (_player.GetStamina() >= 60)
        {
            _player.GetComponent<DamageComponent>().DealDamage(_monster.gameObject);
        }
        if (_monster.Attack())
        {
            _monster.GetComponent<DamageComponent>().DealDamage(_player.gameObject);
        }
    }

    public void FightOver()
    {
        _playerCam.gameObject.SetActive(true);
        _fightingCam.gameObject.SetActive(false);
    }
}
