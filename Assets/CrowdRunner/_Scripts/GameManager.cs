using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    private GameState _gameState;

    public static GameManager Instance;
    public static Action<GameState> onGameStateChanged;

    public GameState GameState
    {
        get => _gameState;
        set => _gameState = value;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        print(_gameState);
    }

    public void SetGameState(GameState gameState)
    {
        _gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }
}

public enum GameState
{
    Menu,
    Game,
    LevelComplete,
    GameOver
}