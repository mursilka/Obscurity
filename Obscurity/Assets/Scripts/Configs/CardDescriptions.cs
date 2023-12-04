using System.Collections.Generic;
using Obscuity;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(CardDescriptions), menuName = "Configs/" + nameof(CardDescriptions), order = 0)]
    public class CardDescriptions : ScriptableObject
    {
        [SerializeField] private List<CardDescription> listCards;

        public List<CardDescription> ListCards => listCards;
    }
}