using UnityEngine;
using System.Collections;


public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterDatas _monsterDatas;
    [SerializeField] private DamageComponent _damageComponent;
    private bool _isAttacking;
    

    private void Start()
    {
        _damageComponent.SetHealth(_monsterDatas._health);
        _damageComponent.SetAttack(_monsterDatas._attack);
    }

    public bool Attack()
    {
        if (_isAttacking)
        {
            StartCoroutine(AttackCooldown(_monsterDatas._attackSpeed));
        }
        return _isAttacking;
    }

    IEnumerator AttackCooldown(float duration)
    {
        _isAttacking = true;
        yield return new WaitForSeconds(duration);
        _isAttacking = false;
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
    }
}
