using UnityEngine;

public class Card
{
    public string Title => data.name;
    public Sprite Image => data.Image;
    private CardDatas data;

    public bool CanBeHover = true;

    public int Value => data.Value;

    public Card(CardDatas cardData)
    {
        data = cardData;
    }
}
