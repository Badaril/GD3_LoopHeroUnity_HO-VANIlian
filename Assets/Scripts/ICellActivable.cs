using UnityEngine;

public interface ICellActivable
{
    public void OnCellActivate(Pawn playerPawn);
    public void OnCellUpdate(Pawn playerPawn);
    public void OnCellDeactivate(Pawn playerPawn);
}
