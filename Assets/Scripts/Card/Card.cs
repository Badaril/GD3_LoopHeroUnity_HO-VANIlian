using UnityEngine;

public class Card
{
    public string Title => data.name;
    public Sprite Image => data.Image;
    private CardDatas data;

    public Card(CardDatas cardData)
    {
        data = cardData;
    }
}
