using Configs;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = nameof(MainSettingsConfig), menuName = "Configs/" + nameof(MainSettingsConfig), order = 0)]
    public class MainSettingsConfig : ScriptableObject
    {
        [SerializeField] private LevelsConfig levelsConfig;
        [SerializeField] private PlayerConfig playerConfig;

        public LevelsConfig LevelsConfig => levelsConfig;
        public PlayerConfig PlayerConfig => playerConfig;
    }
}   