using UnityEditor.UI;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private PlayerDatas _playerDatas;

    private void Start()
    {
        MoveToCell();
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
    }
}
