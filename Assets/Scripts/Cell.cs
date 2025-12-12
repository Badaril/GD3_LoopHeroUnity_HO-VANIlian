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

    /*public virtual void OnCellUpdate(Pawn playerPawn)
    {
        if (GetComponent<IActivable>() != null)
        {
            GetComponent<IActivable>().CellUpdate(playerPawn);
        }
    }*/

    /*public virtual void OnCellDeactivate(Pawn playerPawn)
    {
        if (GetComponent<IActivable>() != null)
        {
            GetComponent<IActivable>().CellDeactivate(playerPawn);
        }
    }*/

    

}
