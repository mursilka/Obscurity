
using Unity.VisualScripting;
using UnityEngine;

namespace Obscuity
{
    public class PlayingCards : MonoBehaviour
    {
        private int _value;


        public int Value => _value;



        public bool IsInDeck { get; set; } = true;



    }
}