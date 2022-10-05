using System;
using Obscuity.Ads;
using UnityEngine;

namespace Obscuity
{
    public class GameManager : MonoBehaviour
    {
        private UIManager _ui;
        private PlayerController _player;
        private EnemyController _enemy;
        private AdsInitializer _ads;

        public Action OnStartGame;
        public Action OnHandChanged;
        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            _enemy = FindObjectOfType<EnemyController>();
            _ui = FindObjectOfType<UIManager>();
            _ads = FindObjectOfType<AdsInitializer>();
        }

        private void Start()
        {
            _player.OnDead += Lost;
            _enemy.OnDeadEnemy += Win;
            _ads.OnButtonHealthChanged += PlayOn;
        }

        private void OnDestroy()
        {
            _player.OnDead -= Lost;
            _enemy.OnDeadEnemy -= Win;
            _ads.OnButtonHealthChanged -= PlayOn;
        }

        private void PlayOn()
        {
            _ui.ShowGameScreen();
        }

        private void Win()
        {
            _ui.ShowWinScreen();
        }

        private void Lost()
        {
           _ui.ShowFallScreen();
        }

        public void StartGame()
        {
            OnStartGame?.Invoke();
            _ui.ShowGameScreen();
        }

        public void MoveButton()
        {
            _enemy.EnemyMoves();
            OnHandChanged?.Invoke();
        }
    }
}