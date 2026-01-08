using UnityEngine;
using System.Collections;

public class DamageComponent : MonoBehaviour
{
    public FightController _fightController;
    private float _health;
    private float _initialHealth;
    private float _attack;
    //private float _initialAttack;

    public void SetHealth(float value)
    {
        _health = value;
        _initialHealth = value;
    }

    public void SetAttack(float value)
    {
        _attack = value;
    }
    

    public void TakeDamage(float amount)
    {
        Debug.Log("take damage");
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

    public float GetHealth() 
    {
        return _health; 
    }

    /*public void InFight()
    {
        StartCoroutine(Fighting(1f));
    }

    IEnumerator Fighting(float duration)
    {
        yield return new WaitForSeconds(duration);
    }*/

    private void Death()
    {
        _fightController.FightOver();
    }

    private void FixedUpdate()
    {
        //Debug.Log(_health);
    }
}
