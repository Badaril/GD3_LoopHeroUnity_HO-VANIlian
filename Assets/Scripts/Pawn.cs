using UnityEditor.UI;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private PlayerDatas _playerDatas;
    [SerializeField] private DamageComponent _damageComponent;

    private void Start()
    {
        _damageComponent.SetHealth(_playerDatas._health);
        _damageComponent.SetAttack(_playerDatas._attack);
        MoveToCell();
        ActivateCell();
    }

    private void MoveToCell ()
    {
        Transform newPos = _board.GetCellByNumber(_playerDatas._cellNumber).transform;
        transform.position = newPos.position;
        transform.rotation = newPos.rotation;
    }

    public void TryMoving(int value)
    {
        _playerDatas._cellNumber = _board.GetNextCellToMove(_playerDatas._cellNumber + value);
        MoveToCell ();
        ActivateCell();

    }

    private void ActivateCell()
    {
        _board.GetCellByNumber(_playerDatas._cellNumber).OnCellActivate(this);
    }

    public float GetStamina()
    {
        return _playerDatas._stamina;
    }

    public void Attack()
    {
        _playerDatas._stamina += 10;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Attack();
        }
    }

    public void Death()
    {
        
    }
}
