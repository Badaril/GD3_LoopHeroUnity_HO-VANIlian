using UnityEngine;

public class HealingComponent : MonoBehaviour, IActivable
{
    [SerializeField] private float value;
    [SerializeField] private PlayerDatas _playerDatas;
    [SerializeField] private UIPlayerDatasController _UIPlayerDatasController;
    public void CellAction(Pawn playerPawn)
    {
        _playerDatas._health += value;
        _playerDatas._health = Mathf.Clamp(_playerDatas._health, 0, 20);
        _UIPlayerDatasController.UpdateHealth(true,_playerDatas._health);
    }
}
