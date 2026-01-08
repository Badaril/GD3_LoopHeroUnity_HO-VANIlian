using UnityEngine;

[CreateAssetMenu(fileName = "MonsterDatas", menuName = "Scriptable Objects/MonsterDatas")]
public class MonsterDatas : ScriptableObject
{
    public float _health;
    public float _attack;
    public float _attackCooldown;
}
