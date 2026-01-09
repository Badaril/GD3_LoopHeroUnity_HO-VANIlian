using Unity.VisualScripting;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public FightController _fightController;
    public PlayerDatas _playerPawn;
    public MonsterDatas _monster;
    public bool _attackCooldown;
    private float _timer;

    public void TakeDamage(float amount)
    {
        if (this.CompareTag("Player"))
        {
            _playerPawn._health -= amount;
            if (_playerPawn._health <= 0)
            {
                Death();
            }
        }
        else
        {
            _monster._health -= amount;
            if (_monster._health <= 0)
            {
                Death();
            }
        }
    }

    public void DealDamage(GameObject target)
    {
        if (!(_attackCooldown))
        {
            var other = target.GetComponent<DamageComponent>();
            if (other != null)
            {
                if (this.CompareTag("Player"))
                {
                    other.TakeDamage(_playerPawn._attack);
                    
                }
                else
                {
                    other.TakeDamage(_monster._attack);
                }
                _attackCooldown = true;
            }
        }
    }

    public float GetHealth()
    {
        if (this.CompareTag("Player"))
        {
            return _playerPawn._health;
        }
        else
        {
            return _monster._health;
        }
    }


    private void Death()
    {
        _fightController.FightOver();
        if (this.CompareTag("Player"))
        {
            //_playerDatas.GetComponent<Pawn>().Death();
        }
        else 
        { 
            _monster.GetComponent<Monster>().Death();
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(_playerPawn);
        Debug.Log(_monster);
        if (_attackCooldown)
        {
            _timer += Time.fixedDeltaTime;
        }

        if (_timer >= 1f) 
        {
            _timer -= 1f;
            _attackCooldown = false;
        }

    }
}
