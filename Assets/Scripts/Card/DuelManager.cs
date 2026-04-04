using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR;

public class DuelManager : MonoBehaviour, IActivable
{
    [SerializeField] private IACardManager IACardManager;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Camera _duelCamera;

    [SerializeField] private UIPlayerDatasController _playerHUD;

    [SerializeField] private CardHand playerHand;
    [SerializeField] private Transform discardPilePoint;

    //private readonly List<Card> drawPile = new();
    private readonly List<Card> discardPile = new();
    //private readonly List<Card> hand = new();

    public void CellAction(Pawn playerPawn)
    {
        _playerCamera.gameObject.SetActive(false);
        _duelCamera.gameObject.SetActive(true);
        _playerHUD.SetDuelHUD(true);
    }

    public IEnumerator UpdateDuel(CardHUD playerCard)
    {
        IACardManager.PlayCard();
        yield return new WaitForSeconds(1);

        if (playerCard.Card.Value > 0 && IACardManager.GetPlayCardValue() == 0)
        {
            //player win
            Debug.Log(playerCard.Card.Value + IACardManager.GetPlayCardValue() + " player win");
            //flip

            EndDuel();
        }
        else if ((playerCard.Card.Value == 0 && IACardManager.GetPlayCardValue() > 0)
            || (playerCard.Card.Value > 0 && IACardManager.GetPlayCardValue() > 0))
        {
            //player lose
            Debug.Log(playerCard.Card.Value + IACardManager.GetPlayCardValue() + " player lose");
            //flip
            EndDuel();

        }
        else
        {
            //duel continue
            Debug.Log(playerCard.Card.Value + IACardManager.GetPlayCardValue() + " match continue");
            //flip then
            //discard
            StartCoroutine(DiscardCard(playerCard));
            StartCoroutine(DiscardCard(IACardManager.GetIACard()));
            //IACardManager.ClearDropZone();
        }
    }

    public void EndDuel()
    {
        StartCoroutine(DiscardAllCards(playerHand));
        StartCoroutine(DiscardAllCards(IACardManager.GetIAHand()));
        _duelCamera.gameObject.SetActive(false);
        _playerCamera.gameObject.SetActive(true);
        
        _playerHUD.SetDuelHUD(false);
    }

    public void CheckDuelState(CardHUD playerCard)
    {
        
        StartCoroutine(UpdateDuel(playerCard));
    }

    private IEnumerator DiscardAllCards(CardHand hand)
    {
        foreach (var card in hand.allCardsInHand)
        {
            discardPile.Add(card.Card);
            CardHUD cardHUD = hand.RemoveCard(card.Card);
            yield return DiscardCard(cardHUD);
        }
        hand.allCardsInHand.Clear();
    }

    private IEnumerator DiscardCard(CardHUD cardHUD)
    {
        //Debug.Log("jeje didiscascardrd");
        cardHUD.transform.DOScale(Vector3.zero, 0.15f);
        Tween tween = cardHUD.transform.DOMove(discardPilePoint.position, 0.15f);
        yield return tween.WaitForCompletion();
        Destroy(cardHUD);
    }

    private IEnumerator FlipIACard()
    {
        //aniamtion for flipping
        yield return new WaitForSeconds(1f);

    }
}
