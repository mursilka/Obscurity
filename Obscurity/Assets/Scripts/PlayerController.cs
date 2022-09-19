using System;
using UnityEngine;

namespace Obscuity
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private int startHp;

        [SerializeField] private int startArmor;


        private int _damage;
        private int _currentArmor;
        private int _currentHp;

        private void Awake()
        {
            _currentHp = startHp;
            _currentArmor = startArmor;
        }

        public int DealingDamage(int damage)
        {
            damage += _damage;
            return damage;
        }

        public int Healing(int hp)
        {
            if (hp + _currentHp < startHp)
            {
                _currentHp = hp + _currentHp;
                return _currentHp;
            }
            else
            {
                return startHp;
            }
        }

        public void Protection(int armor)
        {
            _currentArmor += armor;
            
        }

        public void TakingDamage(int damage)
        {
            if (_currentArmor > 0 && _currentArmor>=damage)
            {
                _currentArmor = _currentArmor - damage;
            }
            
            if (_currentArmor > 0 && _currentArmor<damage)
            {
                _currentHp = _currentHp-(_currentArmor-damage); 
                _currentArmor = 0;
                
            }
        }
    }
}