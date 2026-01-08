using UnityEditor.UI;
using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private PlayerDatas _playerDatas;
    private DamageComponent _damageComponent;
    //private bool _isAttacking;

    private void Start()
    {
        _damageComponent = this.GetComponent<DamageComponent>();
        _damageComponent.SetHealth(20);
        _damageComponent.SetAttack(3);
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

    public void SetStamina(float value)
    {
        _playerDatas._stamina = value;
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerDatas._stamina += 5;
            
        }
        _playerDatas._stamina -= Time.deltaTime*10f;
        _playerDatas._stamina = Mathf.Clamp(_playerDatas._stamina, 0, 100);
        Debug.Log(_playerDatas._stamina);
        //StartCoroutine(DecreaseStamina(1f));
    }

    /*IEnumerator DecreaseStamina(float duration)
    {
        _playerDatas._stamina -= 0.1f;
        yield return new WaitForSeconds(duration);
    }*/

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) & (_damageComponent._fightController.GetFightState()))
        { 
            Attack();
        }
    }

    public void Death()
    {
        
    }
}
