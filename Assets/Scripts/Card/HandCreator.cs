using DG.Tweening;
using UnityEngine;

public class HandCreator : Singleton<HandCreator>
{
    [SerializeField] private CardHUD cardTemplatePrefab;
    [SerializeField] private CardHand playerCardHand;

    public CardHUD CreateCard(Vector3 position, Quaternion rotation)
    {
        CardHUD newCard = Instantiate(cardTemplatePrefab, position, rotation);
        newCard.transform.localScale = Vector3.zero;
        newCard.transform.DOScale(Vector3.one, 0.15f);
        return newCard;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < 6; i++)
            {
                CreateHand();
            }
        }
    }

    public void CreateHand()
    {
        CardHUD newCard = Instance.CreateCard(transform.position, Quaternion.identity);
        StartCoroutine(playerCardHand.AddCard(newCard));
    }
}
