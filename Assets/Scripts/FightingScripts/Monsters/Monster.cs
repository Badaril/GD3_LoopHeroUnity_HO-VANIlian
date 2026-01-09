using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterDatas _monsterDatas;
    [SerializeField] private GameManager _gameManager;
    private DamageComponent _damageComponent;
    public bool _isAttacking = false;

    private void Start()
    {
        _damageComponent = this.GetComponent<DamageComponent>();
        //_damageComponent._monster = this;
    }

    public void Attack()
    {
        _isAttacking = true;
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
        _gameManager._monstersKilled += 1;
        _gameManager.CheckLevel1();
        Destroy(this.gameObject);
    }
}
