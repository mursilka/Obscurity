using Configs;
using UnityEngine;
using Obscuity.Player;

namespace Obscuity
{
    public class Game
    {
        private readonly PlayerConfig _playerCongfig;
        
        private readonly LevelsConfig _levelConfig;

        private Level _level;
        private PlayerCharacter _player;

        public Game(PlayerConfig playerCongfig,  LevelsConfig levelConfig)
        {
            _playerCongfig = playerCongfig;
            
            _levelConfig = levelConfig;
        }

        public void StartGame()
        {
            Level levelPrefab = _levelConfig.Level;
            _level = Object.Instantiate(levelPrefab);

            PlayerCharacter playerPrefab = _playerCongfig.Player;
            _player = Object.Instantiate(playerPrefab);
        }
    }
}