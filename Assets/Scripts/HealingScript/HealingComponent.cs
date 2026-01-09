using UnityEngine;

public class HealingComponent : MonoBehaviour, IActivable
{
    [SerializeField] private float value;
    [SerializeField] private UIPlayerDatasController _UIPlayerDatasController;
    public void CellAction(Pawn playerPawn)
    {
        playerPawn.GetComponent<PlayerDatas>()._health += value;
        _UIPlayerDatasController.UpdateHealth(value);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
