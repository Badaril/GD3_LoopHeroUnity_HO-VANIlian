using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private PlayerDatas _playerDatas;
    [SerializeField] private UIPlayerDatasController _playerDatasController;
    private DamageComponent _damageComponent;

    public void Start()
    {
        
        _damageComponent = this.GetComponent<DamageComponent>();
        
        //_damageComponent._playerPawn = this;
        MoveToCell();
        ActivateCell();
    }

    public void LateStart(PlayerDatas playerdatas)
    {
        _playerDatas = playerdatas;
        _damageComponent = this.GetComponent<DamageComponent>();
        _damageComponent.LateStart(playerdatas);
        //_damageComponent._playerPawn = this;
        MoveToCell();
        ActivateCell();
    }

    private void MoveToCell ()
    {
        Transform newPos = _board.GetCellByNumber(_playerDatas._data._cellNumber).transform;
        transform.position = newPos.position;
        transform.rotation = newPos.rotation;
    }

    public void TryMoving(int value)
    {
        _playerDatas._data._cellNumber = _board.GetNextCellToMove(_playerDatas._data._cellNumber + value);
        MoveToCell ();
        ActivateCell();
    }

    private void ActivateCell()
    {
        _board.GetCellByNumber(_playerDatas._data._cellNumber).OnCellActivate(this);
    }

    public float GetStamina()
    {
        return _playerDatas._data._stamina;
    }

    public void SetStamina(float value)
    {
        _playerDatas._data._stamina = value;
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerDatas._data._stamina += 5;
        }
        _playerDatas._data._stamina -= Time.deltaTime*5f;

        _playerDatas._data._stamina = Mathf.Clamp(_playerDatas._data._stamina, 0, 100);

    }

    private void Update()
    {

        if (_damageComponent._fightController != null)
        {
            if (_damageComponent._fightController.GetFightState())
            {
                Attack();
            }
        }
    }

    public void Death()
    {
        _playerDatasController.DisplayDeathHUD();
    }
}
