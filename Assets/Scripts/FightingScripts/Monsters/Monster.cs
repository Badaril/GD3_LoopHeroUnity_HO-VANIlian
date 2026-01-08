using UnityEngine;
using System.Collections;


public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterDatas _monsterDatas;
    private DamageComponent _damageComponent;
    public bool _isAttacking = false;
    private float _timer;
    

    private void Start()
    {
        _damageComponent = this.GetComponent<DamageComponent>();
        _damageComponent._monsterDatas = _monsterDatas;
    }

    public bool GetIsAttacking()
    {
        return _isAttacking;
    }

    public void Attack()
    {
        _isAttacking = true;
    }

    /*IEnumerator AttackCooldown(float duration)
    {
        _isAttacking = false;
        yield return new WaitForSeconds(duration);
        _isAttacking = true;
        Attack();
    }*/

    public void Death()
    {
        this.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        /*_timer += Time.fixedDeltaTime;
        if (_isAttacking)
        {
            Debug.Log(_timer);
            _timer -= _monsterDatas._attackSpeed;
            Debug.Log("fin attaque");
            Debug.Log(_timer);
            _isAttacking = false;
            
        }*/
    }
}
