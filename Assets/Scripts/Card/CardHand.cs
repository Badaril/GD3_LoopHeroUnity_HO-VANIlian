using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Splines;

public class CardHand : MonoBehaviour
{
    [SerializeField] private SplineContainer splineHand;
    public List<CardHUD> allCardsInHand = new();

    public IEnumerator AddCard(CardHUD cardHUD)
    {
        allCardsInHand.Add(cardHUD);
        yield return UpdateCardsPosition(0.15f);
    }

    public CardHUD RemoveCard(Card card)
    {
        CardHUD cardHUD = GetCardHUD(card);
        if (cardHUD == null) return null;
        allCardsInHand.Remove(cardHUD);
        StartCoroutine(UpdateCardsPosition(0.15f));
        return cardHUD;
    }

    private CardHUD GetCardHUD(Card card)
    {
        return allCardsInHand.Where(cardHUD => cardHUD.Card == card).FirstOrDefault();
    }

    private IEnumerator UpdateCardsPosition(float duration)
    {
        if (allCardsInHand.Count == 0) yield break;
        float cardsSpacing = 1f / 10f;
        float firstCardPosition = 0.5f - (allCardsInHand.Count - 1) * cardsSpacing / 2;
        Spline spline = splineHand.Spline;

        for (int i = 0; i < allCardsInHand.Count; i++)
        {
            float p = firstCardPosition + i * cardsSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(-up, Vector3.Cross(-up, forward).normalized);
            allCardsInHand[i].transform.DOMove(splinePosition + transform.position + 0.01f * i * Vector3.back, duration);
            allCardsInHand[i].transform.DORotate(rotation.eulerAngles, duration);
        }
        yield return new WaitForSeconds(duration);
    }


}
