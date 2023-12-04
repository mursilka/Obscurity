using System;
using Obscuity;
using UnityEngine;

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
    private GameManager _gameManager;
    int index;
    
    public Action<float,int,int> OnHealthChangedEnemy;
    public Action OnDeadEnemy;
    public Action<int> OnArmor;

    public int Hp => hp;

    private void Awake()
    {
        
        _player = FindObjectOfType<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        _gameManager.OnStartGame += StartParametrsChanged;
        OnArmor?.Invoke(_currentArmor);
    }

    private void StartParametrsChanged()
    {
        _currentHp = hp;
        index = 0;

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
