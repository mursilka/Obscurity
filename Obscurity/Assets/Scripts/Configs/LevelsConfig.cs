using Obscuity;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(LevelsConfig), menuName = "Configs/" + nameof(LevelsConfig), order = 0)]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private Level level;
    
    

        public Level Level => level;
        
    }
}
