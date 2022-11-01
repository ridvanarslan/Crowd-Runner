using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform runnersParent;
    [Header(" Settings ")]
    [SerializeField] private float angle;
    [SerializeField] private float radius;
    private void Update()
    {
        PlaceRunners();
    }

    private void PlaceRunners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            var childLocalPos = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPos;
        }
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float xPos = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float zPos = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(xPos, 0, zPos);
    }

    public float GetCrowdRadius => radius * Mathf.Sqrt(runnersParent.childCount);
}
