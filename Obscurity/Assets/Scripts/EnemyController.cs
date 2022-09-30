using System;
using Obscuity;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    [SerializeField] private int armor;

    private PlayingCards _cards;
    private int _currentHp;

    private void Awake()
    {
        _currentHp = hp;
    }

    public void Health(int damageHP)
    {
        _currentHp = _currentHp-damageHP;
        Debug.Log(_currentHp);
    }
}
