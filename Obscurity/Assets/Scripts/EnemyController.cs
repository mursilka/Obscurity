using System;
using Obscuity;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    [SerializeField] private int armor;
    [SerializeField] private int damage1;
    [SerializeField] private int armor1;

    private PlayingCards _cards;
    private int _currentHp;
    private int _currentArmor=0;
    private PlayerController _player;
    
    int index = 0;
    
    public Action<float,int,int> OnHealthChangedEnemy;
    public Action OnDeadEnemy;
    public Action<int> OnArmor;

    public int Hp => hp;

    private void Awake()
    {
        _currentHp = hp;
        _player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        OnArmor?.Invoke(_currentArmor);
    }

    public void Health(int damageHP)
    {
        if (_currentArmor >= damageHP)
        {
            _currentArmor -= damageHP;
            OnArmor?.Invoke(_currentArmor);
        }
        else
        {
            _currentHp = _currentHp + _currentArmor - damageHP;
            _currentArmor = 0;
            OnArmor?.Invoke(_currentArmor);
            if (_currentHp < 0)
            {
                OnDeadEnemy?.Invoke();
            }
            else
            {
                float _currentHealthAsPercantage = (float)_currentHp / hp;
                OnHealthChangedEnemy?.Invoke(_currentHealthAsPercantage, _currentHp, hp);
            }
        }
    }

    private void ArmorChanged(int armorChanged)
    {
        _currentArmor += armorChanged;
        OnArmor?.Invoke(_currentArmor);
    }
    
    public void EnemyMoves()
    {
        Debug.Log(index);
        
        if (index==2)
        {
            _player.HealthChange(damage1);
            ArmorChanged(armor1);
            index = -1;
        }
        if (index==1)
        {
            ArmorChanged(armor); 
        }

        if (index == 0)
        {
            _player.HealthChange(damage);
        }
        index += 1;
    }
}
