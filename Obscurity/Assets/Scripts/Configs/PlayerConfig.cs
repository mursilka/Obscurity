using System.Collections.Generic;
using Obscuity;
using Obscuity.Player;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/" + nameof(PlayerConfig), order = 0)]
    public class PlayerConfig
    {
        [SerializeField] private PlayerCharacter player;

        public PlayerCharacter Player => player;
        
    }
}