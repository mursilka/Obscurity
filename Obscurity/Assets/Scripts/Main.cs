using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Configs;
using Obscuity;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private MainSettingsConfig mainSettingsConfig;
    private Game _game;

    private void Start()
    {
        _game = new Game(mainSettingsConfig.PlayerConfig, mainSettingsConfig.LevelsConfig);
        StartGame();
        
    }

    private void Update()
    {
        _game.Update();
    }

    public void StartGame() 
    {
        _game.StartGame();
    }
}
