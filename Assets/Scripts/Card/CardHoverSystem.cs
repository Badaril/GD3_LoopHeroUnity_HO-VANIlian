using UnityEngine;

public class CardHoverSystem : Singleton<CardHoverSystem>
{
    [SerializeField] private CardHUD hoveredCardDisplay;

    public void Show(Card card, Vector3 position)
    {
        if (card.CanBeHover)
        {
            hoveredCardDisplay.gameObject.SetActive(true);
            hoveredCardDisplay.SetupCard(card);
            hoveredCardDisplay.transform.position = position;
        }
    }

    public void Hide() 
    {
        hoveredCardDisplay.gameObject.SetActive(false);
    }
}
