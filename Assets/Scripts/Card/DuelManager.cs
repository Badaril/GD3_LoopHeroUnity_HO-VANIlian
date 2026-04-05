using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class DuelManager : MonoBehaviour, IActivable
{
    [SerializeField] private IACardManager IACardManager;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Camera _duelCamera;

    [SerializeField] private HandCreator _handCreator;

    [SerializeField] private UIPlayerDatasController _playerHUD;
    

    [SerializeField] private CardHand playerHand;
    [SerializeField] private Transform discardPilePoint;

    [SerializeField] private GameObject labyrinthePath;

    private bool duelActive = true;

    public void CellAction(Pawn playerPawn)
    {
        if (duelActive)
        {
            StartCoroutine(DiscardAllCards_V2(playerHand));
            StartCoroutine(DiscardAllCards_V2(IACardManager.hand));
            _handCreator.CreateAllHAnds();
            _playerCamera.gameObject.SetActive(false);
            _duelCamera.gameObject.SetActive(true);
            _playerHUD.SetDuelHUD(true);
        }
    }

    private void Update()
    {
        /*foreach (var card in playerHand.allCardsInHand)
        {
            Debug.Log(card + " player cards");
            
        }
        Debug.Log(playerHand.allCardsInHand.Count);
        /*foreach (var card in IACardManager.hand.allCardsInHand)
        {
            Debug.Log(card + " ia cards");
        }*/
    }

    public IEnumerator UpdateDuel(CardHUD playerCard)
    {
        IACardManager.PlayCard();
        yield return new WaitForSeconds(0.5f);

        //player win
        if (playerCard.Card.Value > 0 && IACardManager.GetPlayCardValue() == 0)
        {
            //flip
            duelActive = false;
            StartCoroutine(_playerHUD.DisplayDuelResult("You win !"));
            yield return new WaitForSeconds(0.5f);
            labyrinthePath.SetActive(true);
            EndDuel();
        }

        //player lose
        else if ((playerCard.Card.Value == 0 && IACardManager.GetPlayCardValue() > 0)
            || (playerCard.Card.Value > 0 && IACardManager.GetPlayCardValue() > 0))
        {
            //flip
            StartCoroutine(_playerHUD.DisplayDuelResult("You lose..."));
            yield return new WaitForSeconds(0.5f);
            _playerHUD.UpdateMoney(-5);
            EndDuel();

        }

        //duel continue
        else if (playerHand.allCardsInHand.Count > 1)
        {
            //flip
            StartCoroutine(_playerHUD.DisplayDuelResult("Draw, continue"));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(DiscardCard(playerCard));
            StartCoroutine(DiscardCard(IACardManager.GetIACard()));
        }

        //no card
        else
        {
            StartCoroutine(_playerHUD.DisplayDuelResult("You lose..."));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(DiscardCard(playerCard));
            StartCoroutine(DiscardCard(IACardManager.GetIACard()));
            yield return new WaitForSeconds(0.5f);
            EndDuel();
        }
    }

    public void EndDuel()
    {
        StartCoroutine(DiscardAllCards_V2(playerHand));
        StartCoroutine(DiscardAllCards_V2(IACardManager.hand));
        //playerHand.allCardsInHand.Clear();
        //IACardManager.hand.allCardsInHand.Clear();
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
        List<CardHUD> test = new List<CardHUD>(hand.allCardsInHand);

        foreach (var card in test)
        {
            Debug.Log(hand + " : " + card.ToString() + " before " + hand.allCardsInHand.IndexOf(card));
            //discardPile.Add(card.Card);
            hand.RemoveCard(card.Card);
            yield return DiscardCard(card);
        }
        hand.allCardsInHand.Clear();
    }

    private IEnumerator DiscardAllCards_V2(CardHand hand)
    {
       for (int i = hand.allCardsInHand.Count - 1; i >= 0; i--)
       {
            CardHUD cardHUD = hand.allCardsInHand[i];

            if (cardHUD == null) continue;

            hand.allCardsInHand.RemoveAt(i);

            yield return DiscardCard(cardHUD);
       }
        hand.allCardsInHand.Clear();
    }

    private IEnumerator DiscardCard(CardHUD cardHUD)
    {
        cardHUD.transform.DOScale(Vector3.zero, 0.15f);
        Tween tween = cardHUD.transform.DOMove(discardPilePoint.position, 0.15f);
        yield return tween.WaitForCompletion();
        Destroy(cardHUD.gameObject);
    }

    private IEnumerator FlipIACard()
    {
        //aniamtion for flipping
        yield return new WaitForSeconds(1f);

    }
}
