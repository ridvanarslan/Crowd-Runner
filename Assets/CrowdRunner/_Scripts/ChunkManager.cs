using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkManager : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private Chunk[] chunkPrefabs;
    [SerializeField] private Chunk[] levelChunks;

    private void Start()
    {
        CreateOrderedLevel();
    }

    private void CreateOrderedLevel()
    {
        var chunkPos = Vector3.zero;

        for (int i = 0; i < levelChunks.Length; i++)
        {
            var chunkToCreate = levelChunks[i];
            if (i>0)
            {
                chunkPos.z += chunkToCreate.GetLenght() / 2;
            }
            var chunkInstance = Instantiate(chunkToCreate, chunkPos,quaternion.identity,transform);
            chunkPos.z += chunkInstance.GetLenght() / 2;
        }
    }

    private void CreateRandomLevel()
    {
        var chunkPos = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            var chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
            if (i>0)
            {
                chunkPos.z += chunkToCreate.GetLenght() / 2;
            }
            var chunkInstance = Instantiate(chunkToCreate, chunkPos,quaternion.identity,transform);
            chunkPos.z += chunkInstance.GetLenght() / 2;
        }
    }
}
