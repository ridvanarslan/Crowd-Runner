using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState _gameState;

    public static Action<GameState> onGameStateChanged;

    public void SetGameState(GameState gameState)
    {
        this._gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }
}
public enum GameState { Menu, Game,LevelComplete,GameOver}
