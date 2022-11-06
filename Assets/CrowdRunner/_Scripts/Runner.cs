using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] private bool isTargeted;
    public bool IsTargeted
    {
        get => isTargeted;
        set => isTargeted = value;
    }

    private void OnDisable()
    {
        if (isTargeted)
        {
            CrowdCounter.onCrowdCountChanged?.Invoke(-1);
        }
    }
}
