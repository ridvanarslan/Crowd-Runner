using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header(" ELEMENTS ")] 
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private Text levelText;

    private void Start()
    {
        progressBar.value = 0;

        levelText.text = $"Level {ChunkManager.Instance.GetLevel()}";
    }
    
    private void OnEnable() => GameManager.onGameStateChanged += GameStateChangedCallback;

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GameOver:
                ShowGameOverPanel();
                break;
            case GameState.LevelComplete:
                ShowLevelComplete();
                break;
        }
    }

    private void OnDisable() => GameManager.onGameStateChanged -= GameStateChangedCallback;

    private void Update()
    {
        if (GameManager.Instance.GameState == GameState.Game)
        {
            UpdateProgressBar();
        }
    }

    public void PlayButtonPressed()
    {
        GameManager.Instance.SetGameState(GameState.Game);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void RetryButtonPressed()
    {
        GameManager.Instance.SetGameState(GameState.Game);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void ShowLevelComplete()
    {
        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }
    public void ShowGameOverPanel()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void UpdateProgressBar()
    {
        float progress = player.transform.position.z / ChunkManager.Instance.GetFinishZ();
        progressBar.value = progress;
    }

    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}