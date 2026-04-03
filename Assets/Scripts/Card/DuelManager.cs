using UnityEngine;

public class DuelManager : MonoBehaviour, IActivable
{
    [SerializeField] private IACardManager IACardManager;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Camera _duelCamera;

    [SerializeField] private UIPlayerDatasController _playerHUD;

    public void CellAction(Pawn playerPawn)
    {
        _playerCamera.gameObject.SetActive(false);
        _duelCamera.gameObject.SetActive(true);
        _playerHUD.SetDuelHUD(true);
    }

    public void UpdateDuel()
    {
        if (IACardManager.indexOfCardPlay >= 0)
        {
            IACardManager.ClearDropZone();
        }
        
    }

    public void EndDuel()
    {
        _playerCamera.gameObject.SetActive(true);
        _duelCamera.gameObject.SetActive(false);
        _playerHUD.SetDuelHUD(false);
    }

    public void CheckDuelState(CardHUD playerCard)
    {
        IACardManager.PlayCard();
        
        if (playerCard.Card.Value > 0 && IACardManager.GetPlayCardValue() == 0) 
        {
            //player win
            Debug.Log(playerCard.Card.Value + IACardManager.GetPlayCardValue() + " player win");
            EndDuel();
        }
        else if ((playerCard.Card.Value == 0 && IACardManager.GetPlayCardValue() > 0)
            || (playerCard.Card.Value > 0 && IACardManager.GetPlayCardValue() > 0))
        {
            //player lose
            Debug.Log(playerCard.Card.Value + IACardManager.GetPlayCardValue() + " player lose");
            EndDuel();

        }
        else
        {
            //duel continue
            Debug.Log(playerCard.Card.Value + IACardManager.GetPlayCardValue() + " match continue");
            //IACardManager.ClearDropZone();
        }
        UpdateDuel();
    }


}
