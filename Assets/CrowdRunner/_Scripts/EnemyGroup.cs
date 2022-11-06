using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header(" ELEMENTS ")] 
    [SerializeField] private Enemy enemyPrefab;    
    
    [Header(" SETTINGS ")] 
    [SerializeField] private int amount;
    [SerializeField] private float angle;
    [SerializeField] private float radius;

    private void Start()
    {
        CreateEnemies();
    }

    private void CreateEnemies()
    {
        for (int i = 0; i < amount; i++)
        {
            var enemyLocalPosition = GetRunnerLocalPosition(i);
            var enemyWorldPosition = transform.TransformPoint(enemyLocalPosition);
            Instantiate(enemyPrefab, enemyWorldPosition, quaternion.identity,this.transform);
        }
    }
    private Vector3 GetRunnerLocalPosition(int index)
    {
        float xPos = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float zPos = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(xPos, 0, zPos);
    }
}
