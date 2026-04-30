using UnityEngine;

public class HealingComponent : MonoBehaviour, IActivable
{
    [SerializeField] private float value;
    [SerializeField] private UIPlayerDatasController _UIPlayerDatasController;
    public void CellAction(Pawn playerPawn)
    {
        playerPawn.GetPlayerDatas()._data._health += value;
        playerPawn.GetPlayerDatas()._data._health = Mathf.Clamp(playerPawn.GetPlayerDatas()._data._health, 0, 20);
        _UIPlayerDatasController.UpdateHealth(true,playerPawn.GetPlayerDatas()._data._health);
        if (playerPawn.GetPlayerDatas()._data._health <= 0)
        {
            _UIPlayerDatasController.DisplayDeathHUD();
        }
    }
}
