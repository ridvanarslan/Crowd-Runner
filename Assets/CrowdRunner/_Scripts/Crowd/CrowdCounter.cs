using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private TextMeshPro crowdCounterText;
    [SerializeField] private Transform runnersParent;

    private void Update()
    {
        crowdCounterText.text = runnersParent.childCount.ToString();
    }
}
