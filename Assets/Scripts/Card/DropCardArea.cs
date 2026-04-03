using UnityEngine;

public class DropCardArea : MonoBehaviour, IDropCardArea
{
    [SerializeField] private Collider col;
    [SerializeField] private DuelManager duelManager;
    public void OnCardDrop(CardHUD card)
    {
        if (col.enabled)
        {
            card.transform.position = transform.position;
            duelManager.CheckDuelState(card);

            //col.enabled = false;
        }
        else
        {
            //card.transform.position = transform.position;
            //col.enabled = true;
        }
    }
}
