using System.Collections.Generic;
using UnityEngine;

namespace Obscuity
{
    [CreateAssetMenu(fileName = "ConfigCardDescriptions", menuName = "ConfigCardDescriptions", order = 0)]
    public class CardDescriptions : ScriptableObject
    {
        [SerializeField] private List<CardDescription> listCards;

        public List<CardDescription> ListCards => listCards;
    }
}