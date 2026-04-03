using TMPro;
using UnityEngine;


public class CardHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private SpriteRenderer cardPicture;
    [SerializeField] private GameObject cardRef;
    [SerializeField] private LayerMask dropAreaLayerMask;

    private Vector3 dragStartPosition;
    private Quaternion dragStartRotation;

    public Card Card {  get; private set; }

    public void SetupCard(Card card)
    {
        Card = card;
        title.text = card.Title;
        cardPicture.sprite = card.Image;
    }

    void OnMouseEnter()
    {
        if (!InteractionManager.Instance.PlayerCanHover()) return;
        if (Card.CanBeHover)
        {
            cardRef.SetActive(false);
            Vector3 pos = new(transform.position.x, transform.position.y + 2, 0);
            CardHoverSystem.Instance.Show(Card, pos);
        }
    }

    private void OnMouseExit()
    {
        if (!InteractionManager.Instance.PlayerCanHover()) return;

        if (Card.CanBeHover)
        {
            CardHoverSystem.Instance.Hide();
            cardRef.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (!InteractionManager.Instance.PlayerCanInteract()) return;
        InteractionManager.Instance.PlayerIsDragging = true;
        
        cardRef.SetActive(true);
        CardHoverSystem.Instance.Hide();
        if (Card.CanBeHover)
        {
            dragStartPosition = transform.position;
            dragStartRotation = transform.rotation;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
    }

    private void OnMouseUp()
    {
        if (!InteractionManager.Instance.PlayerCanInteract()) return;
        if (Physics.Raycast(transform.position, Vector3.back, out RaycastHit hit, 10f, dropAreaLayerMask)
            && hit.collider.TryGetComponent<IDropCardArea>(out IDropCardArea cardDropArea))
        {
            Card.CanBeHover = false;
            cardDropArea.OnCardDrop(this);            
        }
        else
        {
            Card.CanBeHover = true;
            transform.position = dragStartPosition;
            transform.rotation = dragStartRotation;
            
        }
        InteractionManager.Instance.PlayerIsDragging = false;
    }

    private void OnMouseDrag()
    {
        if (!InteractionManager.Instance.PlayerCanInteract()) return;
        transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
    }

    private void Update()
    {
        //Debug.Log(dragStartPosition);
    }
}
