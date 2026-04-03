using UnityEngine;

[CreateAssetMenu(fileName = "CardDatas", menuName = "Scriptable Objects/CardDatas")]
public class CardDatas : ScriptableObject
{
    [field: SerializeField] public Sprite Image {  get; private set; }
    [field: SerializeField] public int Value { get; private set; }

}
