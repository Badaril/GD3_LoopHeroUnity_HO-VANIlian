using UnityEngine;

public class Cell : MonoBehaviour, ICellActivable
{
    public virtual void OnCellActivate(Pawn playerPawn)
    {
        if (GetComponent<IActivable>() != null)
        {
            GetComponent<IActivable>().CellAction(playerPawn);
        }
    }
}
