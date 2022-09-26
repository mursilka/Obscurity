using System;
using UnityEngine;

namespace Obscuity
{
    [Serializable]
    public class CardDescription
    {
        [SerializeField] private string name;
        [SerializeField] private string description;
        [SerializeField] private int damage;
        [SerializeField] private int hp;
        [SerializeField] private int armor;
        [SerializeField] private int manaCost;
        [SerializeField] private Sprite ikonSprite;

        public string Name => name;

        public string Description => description;

        public int Damage => damage;

        public int Hp => hp;

        public int Armor => armor;

        public int ManaCost => manaCost;

        public Sprite IkonSprite
        {
            get => ikonSprite;
            set => ikonSprite = value;
        }
    }
}