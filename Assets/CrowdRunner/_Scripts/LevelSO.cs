using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects / Create New Level", fileName = "Level")]
public class LevelSO : ScriptableObject
{
    [SerializeField] public Chunk[] levelChunks;
}
