using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    void Awake() {
        if (instance != null){
            return;
        }
        instance = this;
    }
    public LevelGenerator levelGenerator;
    public OptionGenerator optionGenerator;
    public UIController uiController;
    private int currentLevel;
    [HideInInspector]
    public string playerAnswer;
    [HideInInspector]
    public string trueAnswer;
    void Start()
    {
        StartLevel(currentLevel);
    }
    void Update()
    {
        Debug.Log(playerAnswer + "/" + trueAnswer);
        if (playerAnswer == trueAnswer){
            StartLevel(currentLevel);
        }
    }
    public void StartLevel(int levelIndex)
    {
        LevelData levelData = levelGenerator.GenerateLevel(levelIndex);
        if (levelData != null)
        {
            //產生選項
            List<Sprite> optionImg = optionGenerator.GenerateOptions(levelData.answerImg);
            //清空+獲取答案
            playerAnswer = "";
            trueAnswer = levelData.pinyin.ToLower();
            //呈現關卡資料以及選項
            uiController.SetUp(levelData, optionImg);
            currentLevel++;
        }
    }
}
