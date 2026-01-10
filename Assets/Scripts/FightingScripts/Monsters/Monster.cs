using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterDatas _monsterDatas;
    [SerializeField] private QuestManager _questManager;
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

    public void SetHealth()
    {
        _monsterDatas._health = 9;
    }

    public void Death()
    {
        _questManager.UpdateQuestState();
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
