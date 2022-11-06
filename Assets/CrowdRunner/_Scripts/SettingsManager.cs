using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header(" ELEMETS ")] 
    [SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image hapticsButtonImage;

    [SerializeField] private AudioManager audioManager;

    [Header(" SETTINGS ")] 
    private bool soundState = true;
    private bool hapticState = true;

    private void Awake()
    {
        soundState = PlayerPrefs.GetInt("sounds",1) == 1;
        soundState = PlayerPrefs.GetInt("haptics",1) == 1;
    }

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        if (soundState)
        {
            EnableSounds();
        }
        else
        {
            DisableSounds();
        }
    }

    public void ChangeSoundsState()
    {
        if (soundState)
        {
            DisableSounds();
        }
        else 
            EnableSounds();

        soundState = !soundState;
        PlayerPrefs.SetInt("sounds", soundState ? 1 : 0);
    }

    private void EnableSounds()
    {
        soundsButtonImage.sprite = optionsOnSprite;
        audioManager.EnableSounds();
    }

    private void DisableSounds()
    {
        soundsButtonImage.sprite = optionsOffSprite;
        audioManager.DisableSounds();
    }
}
