using UnityEngine;
using System.Collections;


public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterDatas _monsterDatas;
    private DamageComponent _damageComponent;
    public bool _isAttacking;
    

    private void Start()
    {
        _damageComponent = this.GetComponent<DamageComponent>();
        _damageComponent.SetHealth(9);
        _damageComponent.SetAttack(1);
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
        _isAttacking = false;
        yield return new WaitForSeconds(duration);
        _isAttacking = true;
        Attack();
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        //Debug.Log(_isAttacking);
    }
}
