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

    }
}