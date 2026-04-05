using System.Collections;
using UnityEngine;

public class IACardManager : MonoBehaviour
{
    [SerializeField] public CardHand hand;
    [SerializeField] private GameObject cardDropAreaForIA;

    public int indexOfCardPlay = -1;

    public void PlayCard()
    {
        
        while (TryGetCard())
        {
            TryGetCard();
        }
        hand.allCardsInHand[indexOfCardPlay].transform.position = cardDropAreaForIA.transform.position;
        hand.allCardsInHand[indexOfCardPlay].transform.rotation = Quaternion.Euler(0, 0, 0);
        //yield return new WaitForFixedUpdate();
        //return hand.allCardsInHand[indexOfCardPlay].Card.Value;
    }

    private bool TryGetCard()
    {
        int var = hand.allCardsInHand.Count;
        indexOfCardPlay = Random.Range(0, var);
        Debug.Log(indexOfCardPlay);
        return hand.allCardsInHand[indexOfCardPlay] == null;
    }

    public int GetPlayCardValue()
    {
        return hand.allCardsInHand[indexOfCardPlay].Card.Value;
    }

    public CardHUD GetIACard()
    {
        return hand.allCardsInHand[indexOfCardPlay];
    }

    public CardHand GetIAHand()
    {
        return hand;
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
