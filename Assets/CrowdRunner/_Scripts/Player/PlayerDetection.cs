using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private CrowdSystem crowdSystem;

    [Header(" Events ")] 
    public static Action onDoorsHitSound;

    private void Update()
    {
        if (GameManager.Instance.GameState == GameState.Game)
        {
            DetectDoors();
        }
    }

    private void DetectDoors()
    {
        var detectedColliders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent<Doors>(out var door))
            {
                var bonusAmount = door.GetBonusAmount(this.transform.position.x);
                var bonusType = door.GetBonusType(this.transform.position.x);
                
                door.Disable();
                crowdSystem.ApplyBonus(bonusType, bonusAmount);
                onDoorsHitSound?.Invoke();
            }
            else if (detectedColliders[i].CompareTag("Finish"))
            {
                GameManager.Instance.SetGameState(GameState.LevelComplete);
                print(ChunkManager.Instance.GetLevel());
                ChunkManager.Instance.SetLevel();
            }
        }
    }
}