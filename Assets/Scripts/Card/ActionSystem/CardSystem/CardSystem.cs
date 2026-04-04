using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;

public class CardSystem : MonoBehaviour
{
    [SerializeField] private CardHand cardHand;
    [SerializeField] private Transform discardPilePoint;

    //private readonly List<Card> drawPile = new();
    private readonly List<Card> discardPile = new();
    private readonly List<Card> hand = new();

    private void OnEnable()
    {
        //ActionSystem.AttachPerformer<DrawCardsGA>(DrawCardsPerformer);
        ActionSystem.AttachPerformer<DiscardAllCardsGA>(DiscardAllCardsPerformer);
    }

    private void OnDisable()
    {
        //ActionSystem.DetachPerformer<DrawCardsGA>();
        ActionSystem.DetachPerformer<DiscardAllCardsGA>();
    }

    /*private IEnumerator DrawCardsPerformer(DrawCardsGA drawCardsGA)
    {

    }*/

    private IEnumerator DiscardAllCardsPerformer(DiscardAllCardsGA discardAllCardsGA)
    {
        foreach (var card in hand)
        {
            discardPile.Add(card);
            CardHUD cardHUD = cardHand.RemoveCard(card);
            yield return DiscardCard(cardHUD);
        }
        hand.Clear();
    }

    private IEnumerator DiscardCard(CardHUD cardHUD)
    {
        cardHUD.transform.DOScale(Vector3.zero, 0.15f);
        Tween tween = cardHUD.transform.DOMove(discardPilePoint.position, 0.15f);
        yield return tween.WaitForCompletion();
        Destroy(cardHUD);
    }
}
