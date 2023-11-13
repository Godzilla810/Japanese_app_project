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
    private int error = 0;

    void Start()
    {
        StartLevel(currentLevel);
    }
    void Update()
    {
        Debug.Log(playerAnswer + "/" + trueAnswer);
        //檢查正確
        if (playerAnswer == trueAnswer)
        {
            uiController.isReset = true;
            playerAnswer = "";
            uiController.ShowCorrect();
            StartCoroutine(WaitAndStartLevel());
        }
        //檢查錯誤
        else if (uiController.isTimesUp)
        {
            uiController.isTimesUp = false;
            error++;
            playerAnswer = "";
            uiController.ShowWrong();
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
            if (GlobalData.mode)
            {
                //計時
                StartCoroutine(uiController.StartTimer());
            }
            currentLevel++;
        }
        //章節結束
        else
        {
            if (error < 3)
                uiController.ShowGoodEnd();
            else
                uiController.ShowBadEnd();
        }
    }
    IEnumerator WaitAndStartLevel()
    {
        yield return new WaitForSeconds(0.5f);
        uiController.HideFeedBack();
        StartLevel(currentLevel);
    }
}
