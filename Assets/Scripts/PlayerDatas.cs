using TMPro;
using UnityEngine;

[System.Serializable]
public struct PlayerData
{
    public int _cellNumber;
    public float _health;
    public float _attack;
    public float _attackCooldown;
    public float _stamina;

    public bool _isInMiniGame;
    public int _miniGameNumber;
}

[CreateAssetMenu(fileName = "PlayerDatas", menuName = "Scriptable Objects/PlayerDatas")]
public class PlayerDatas : ScriptableObject
{
    public PlayerData _data;
    
}
