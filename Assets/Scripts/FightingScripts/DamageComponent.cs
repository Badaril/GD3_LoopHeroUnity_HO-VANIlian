using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private FightController _fightController;
    private float _health;
    private float _initialHealth;
    private float _attack;
    private float _initialAttack;

    void Start()
    {
        Debug.Log(_health);
        Debug.Log(_attack);
    }

    public void SetHealth(float value)
    {
        _health = value;
    }

    public void SetAttack(float value)
    {
        _attack = value;
    }
    

    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Death();
        }
    }

    public void DealDamage(GameObject target)
    {
        var other = target.GetComponent<DamageComponent>();
        if (other != null)
        {
            other.TakeDamage(_attack);
        }
    }

    private void Death()
    {
        _fightController.FightOver();
    }
}
