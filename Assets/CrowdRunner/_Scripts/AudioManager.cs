using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header(" SOUNDS ")] 
    [SerializeField] private AudioSource doorHit;
    [SerializeField] private AudioSource die;
    [SerializeField] private AudioSource levelComplete;
    [SerializeField] private AudioSource gameOver;
    [SerializeField] private AudioSource button;

    private void OnEnable()
    {
        PlayerDetection.onDoorsHitSound += PlayDoorHitSound;
        GameManager.onGameStateChanged += GameStateChangedCallback;
        Enemy.onRunnerDie += PlayDieSound;
    }

    private void OnDisable()
    {
        PlayerDetection.onDoorsHitSound -= PlayDoorHitSound;
        GameManager.onGameStateChanged -= GameStateChangedCallback;
        Enemy.onRunnerDie -= PlayDieSound;
    }

    private void GameStateChangedCallback(GameState state)
    {
        if (state == GameState.LevelComplete)
        {
            PlayLevelComplateSound();
        }
        else if (state == GameState.GameOver)
        {
            PlayGameOverSound();
        }
    }

    private void PlayDoorHitSound() => doorHit.Play();

    private void PlayDieSound() => die.Play();
    private void PlayLevelComplateSound() => levelComplete.Play();
    private void PlayGameOverSound() => gameOver.Play();

    public void DisableSounds()
    {
        doorHit.volume = 0;
        die.volume = 0;
        levelComplete.volume = 0;
        gameOver.volume = 0;
        button.volume = 0;
    }

    public void EnableSounds()
    {
        doorHit.volume = 1;
        die.volume = 1;
        levelComplete.volume = 1;
        gameOver.volume = 1;
        button.volume = 1;
    }
}