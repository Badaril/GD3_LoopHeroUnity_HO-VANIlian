using DG.Tweening;
using UnityEngine;

public class HandCreator : Singleton<HandCreator>
{
    [SerializeField] private CardHUD cardTemplatePrefab;
    [SerializeField] private CardHand playerCardHand;
    [SerializeField] private CardHand IAHand;
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
            CreateHand(panData, playerCardHand);

            CreateHand(esquiveData, playerCardHand);
            CreateHand(esquiveData, playerCardHand);
            
            CreateHand(attenteData, playerCardHand);
            CreateHand(attenteData, playerCardHand);
            CreateHand(attenteData, playerCardHand);

            CreateHand(panData, IAHand);

            CreateHand(esquiveData, IAHand);
            CreateHand(esquiveData, IAHand);

            CreateHand(attenteData, IAHand);
            CreateHand(attenteData, IAHand);
            CreateHand(attenteData, IAHand);
        }
    }

    public void CreateHand(CardDatas type, CardHand hand)
    {
        Card card = new(type);
        CardHUD newCard = /*Instance.*/CreateCard(card, transform.position, Quaternion.identity);
        StartCoroutine(hand.AddCard(newCard));
        //StartCoroutine(IAHand.AddCard(newCard));
    }

    public void CreateAllHAnds()
    {
        CreateHand(panData, playerCardHand);

        CreateHand(esquiveData, playerCardHand);
        CreateHand(esquiveData, playerCardHand);

        CreateHand(attenteData, playerCardHand);
        CreateHand(attenteData, playerCardHand);
        CreateHand(attenteData, playerCardHand);

        CreateHand(panData, IAHand);

        CreateHand(esquiveData, IAHand);
        CreateHand(esquiveData, IAHand);

        CreateHand(attenteData, IAHand);
        CreateHand(attenteData, IAHand);
        CreateHand(attenteData, IAHand);
    }
}
