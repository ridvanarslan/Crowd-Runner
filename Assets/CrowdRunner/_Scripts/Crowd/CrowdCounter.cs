using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    [Header(" SETTINGS ")] [SerializeField]
    private int crowdCount;
    
    [Header(" Elements ")] 
    [SerializeField] private TextMeshPro crowdCounterText;
    [SerializeField] private Transform runnersParent;

    public static Action<int> onCrowdCountChanged;

    private void OnEnable() => onCrowdCountChanged += UpdateCrowdAmount;

    private void OnDisable() => onCrowdCountChanged -= UpdateCrowdAmount;

    private void Start() => UpdateCrowdAmount(runnersParent.childCount);
    
    private void UpdateCrowdAmount(int count)
    {
        crowdCount += count;
        if (crowdCount <= 0)
        {
            GameManager.Instance.SetGameState(GameState.GameOver);
        }
        crowdCounterText.text = crowdCount.ToString();
    }
}
