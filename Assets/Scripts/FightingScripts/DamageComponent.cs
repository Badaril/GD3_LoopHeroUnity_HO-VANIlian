using Unity.VisualScripting;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public FightController _fightController;
    public PlayerDatas _playerDatas;
    public MonsterDatas _monsterDatas;

    [SerializeField] private Pawn _playerPawn;
    [SerializeField] private Monster _monster;

    public bool _attackCooldown;
    private float _timer;

    public void TakeDamage(float amount)
    {
        if (this.CompareTag("Player"))
        {
            _playerDatas._health -= amount;
            if (_playerDatas._health <= 0)
            {
                Death();
            }
        }
        else
        {
            _monsterDatas._health -= amount;
            if (_monsterDatas._health <= 0)
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
                    other.TakeDamage(_playerDatas._attack);
                    
                }
                else
                {
                    other.TakeDamage(_monsterDatas._attack);
                }
                _attackCooldown = true;
            }
        }
    }

    public float GetHealth()
    {
        if (this.CompareTag("Player"))
        {
            return _playerDatas._health;
        }
        else
        {
            return _monsterDatas._health;
        }
    }


    private void Death()
    {
        _fightController.FightOver();
        if (this.CompareTag("Player"))
        {
            _playerPawn.Death();
        }
        else 
        { 
            _monster.Death();
        }
    }

    private void FixedUpdate()
    {
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

    public void SetMonster(Monster monster)
    {
        _monster = monster;
    }
}
