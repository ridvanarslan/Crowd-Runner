using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private LevelSO[] levelSO;
    
    private GameObject finishLine;

    public static ChunkManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GenerateLevel();

        finishLine = GameObject.FindWithTag("Finish");
    }

    private void GenerateLevel()
    {
        int currentLevel = GetLevel();

        currentLevel %= levelSO.Length;
        
        CreateLevel(levelSO[currentLevel].levelChunks);
    }

    private void CreateLevel(Chunk[] levelChunks)
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

    public float GetFinishZ() => finishLine.transform.position.z;

    public int GetLevel() => PlayerPrefs.GetInt("level");

    public void SetLevel() => PlayerPrefs.SetInt("level", GetLevel() + 1);
}
