using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //丟level資料
    public LevelData[] levelDatas;
    public LevelData GenerateLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelDatas.Length)
        {
            LevelData levelData = new LevelData(levelDatas[levelIndex].image, 
            levelDatas[levelIndex].pinyin, levelDatas[levelIndex].audio);
            return levelData;
        }
        else
        {
            Debug.LogError("Invalid level index.");
            return null;
        }
    }
}
