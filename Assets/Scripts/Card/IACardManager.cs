using UnityEngine;

public class IACardManager : MonoBehaviour
{
    [SerializeField] private HandCreator handCreator;
    [SerializeField] private CardHand hand;

    [SerializeField] private CardDatas esquiveData;
    [SerializeField] private CardDatas panData;
    [SerializeField] private CardDatas attenteData;

    [SerializeField] private GameObject cardDropAreaForIA;

    public int indexOfCardPlay = -1;

    public void PlayCard()
    {
        int var = hand.allCardsInHand.Count;
        indexOfCardPlay = Random.Range(0, var);
        hand.allCardsInHand[indexOfCardPlay].transform.position = cardDropAreaForIA.transform.position;
        hand.allCardsInHand[indexOfCardPlay].transform.rotation = Quaternion.Euler(0, 0, 0);
        //return hand.allCardsInHand[indexOfCardPlay].Card.Value;
    }

    public int GetPlayCardValue()
    {
        return hand.allCardsInHand[indexOfCardPlay].Card.Value;
    }

    public void ClearDropZone()
    {
        hand.allCardsInHand.RemoveAt(indexOfCardPlay);

        // Remove card 
        // hand.RemoveCard()
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            PlayCard();
        }
    }
}
