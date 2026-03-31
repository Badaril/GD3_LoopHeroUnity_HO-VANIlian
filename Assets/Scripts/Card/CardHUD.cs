using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CardHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private SpriteRenderer cardPicture;
    [SerializeField] private GameObject cardRef;

    public Card Card {  get; private set; }

    public void SetupCard(Card card)
    {
        Card = card;
        title.text = card.Title;
        cardPicture.sprite = card.Image;
    }

    void OnMouseEnter()
    {
        cardRef.SetActive(false);
        Vector3 pos = new(transform.position.x, transform.position.y + 2, 0);
        CardHoverSystem.Instance.Show(Card, pos);
    }

    private void OnMouseExit()
    {
        CardHoverSystem.Instance.Hide();
        cardRef.SetActive(true);
    }
}
