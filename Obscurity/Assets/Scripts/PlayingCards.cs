
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

namespace Obscuity
{
    public class PlayingCards : MonoBehaviour
    {
        [SerializeField] private TextMeshPro manaCostText;
        [SerializeField] private TextMeshPro descriptionText;
        [SerializeField] private SpriteRenderer sprite;
        
        public void Initialize(CardDescription descriptionCard)
        {
            manaCostText.text = Convert.ToString(descriptionCard.ManaCost);
            descriptionText.text = Convert.ToString(descriptionCard.Description);
            sprite.sprite = descriptionCard.IkonSprite;
        }
      
    }
}