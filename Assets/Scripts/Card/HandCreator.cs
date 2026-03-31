using DG.Tweening;
using UnityEngine;

public class HandCreator : Singleton<HandCreator>
{
    [SerializeField] private CardHUD cardTemplatePrefab;
    [SerializeField] private CardHand playerCardHand;
    [SerializeField] private CardDatas esquiveData;
    [SerializeField] private CardDatas panData;
    [SerializeField] private CardDatas attenteData;

    public CardHUD CreateCard(Card card, Vector3 position, Quaternion rotation)
    {
        CardHUD newCard = Instantiate(cardTemplatePrefab, position, rotation);
        newCard.transform.localScale = Vector3.zero;
        newCard.transform.DOScale(Vector3.one, 0.15f);
        newCard.SetupCard(card);
        return newCard;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CreateHand(panData);

            CreateHand(esquiveData);
            CreateHand(esquiveData);
            
            CreateHand(attenteData);
            CreateHand(attenteData);
            CreateHand(attenteData);
        }
    }

    public void CreateHand(CardDatas type)
    {
        Card card = new(type);
        CardHUD newCard = Instance.CreateCard(card, transform.position, Quaternion.identity);
        StartCoroutine(playerCardHand.AddCard(newCard));
    }
}
