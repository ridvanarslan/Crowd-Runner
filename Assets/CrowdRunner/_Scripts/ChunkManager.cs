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

    private void Start()
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
