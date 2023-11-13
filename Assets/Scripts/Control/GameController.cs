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
    //彙整腳本
    public LevelGenerator levelGenerator;
    public OptionGenerator optionGenerator;
    public UIController uiController;
    //檢查答案
    [HideInInspector]
    public string playerAnswer;
    [HideInInspector]
    public string trueAnswer;
    //變數
    private int currentLevel;
    private bool mode;
    private int chapter;

    void Start()
    {
        // mode = GlobalData.mode;
        // chapter = GlobalData.chapter;
        StartLevel(currentLevel);
    }
    void Update()
    {
        Debug.Log(playerAnswer + "/" + trueAnswer);
        if (playerAnswer == trueAnswer)
        {
            playerAnswer = "";
            uiController.ShowCorrect();
            StartCoroutine(WaitAndStartLevel());
        }
    }
    public void StartLevel(int levelIndex)
    {
        LevelData levelData = levelGenerator.GenerateLevel(levelIndex);
        if (levelData != null)
        {
            //產生關卡選項
            List<Sprite> optionImg = optionGenerator.GenerateOptions(levelData.answerImg);
            //獲取正確答案
            trueAnswer = levelData.pinyin.ToLower();
            //呈現關卡資料
            uiController.SetUp(levelData, optionImg);

            currentLevel++;
        }
    }
    IEnumerator WaitAndStartLevel()
    {
        yield return new WaitForSeconds(0.5f);
        uiController.HideFeedBack();
        StartLevel(currentLevel);
    }
}
