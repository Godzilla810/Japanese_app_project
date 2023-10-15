using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public LevelData[] levelDatas;
    public LevelData GenerateLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelDatas.Length)
        {
            return levelDatas[levelIndex];
        }
        else
        {
            Debug.LogError("Invalid level index.");
            return null;
        }
    }
}
