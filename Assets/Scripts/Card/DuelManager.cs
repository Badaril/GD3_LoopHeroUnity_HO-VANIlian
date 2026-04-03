using UnityEngine;

public class DuelManager : MonoBehaviour
{
    [SerializeField] private IACardManager IACardManager;
    public void UpdateDuel()
    {
        if (IACardManager.indexOfCardPlay >= 0)
        {
            IACardManager.ClearDropZone();
        }
        
    }

    public void CheckDuelState(CardHUD playerCard)
    {
        IACardManager.PlayCard();
        
        if (playerCard.Card.Value > 0 && IACardManager.GetPlayCardValue() == 0) 
        {
            //player win
            Debug.Log(playerCard.Card.Value + IACardManager.GetPlayCardValue() + " player win");
        }
        else if ((playerCard.Card.Value == 0 && IACardManager.GetPlayCardValue() > 0)
            || (playerCard.Card.Value > 0 && IACardManager.GetPlayCardValue() > 0))
        {
            //player lose
            Debug.Log(playerCard.Card.Value + IACardManager.GetPlayCardValue() + " player lose");
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
