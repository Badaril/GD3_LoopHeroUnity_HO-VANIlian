using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterDatas _monsterDatas;
    private DamageComponent _damageComponent;
    public bool _isAttacking = false;

    private void Start()
    {
        _damageComponent = this.GetComponent<DamageComponent>();
        _damageComponent._monsterDatas = _monsterDatas;
    }

    public void Attack()
    {
        _isAttacking = true;
    }

    public void Death()
    {
        this.gameObject.SetActive(false); //avoir si on enleve
        Destroy(this.gameObject);
    }
}
