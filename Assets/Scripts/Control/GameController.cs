using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public LevelGenerator levelGenerator;
    public OptionGenerator optionGenerator;
    public AnswerChecker answerChecker;
    public UIController uiController;
    private int currentLevel;
    private bool isAnswerCorrect;
    void Start()
    {
        StartLevel(currentLevel);
    }
    void Update()
    {
        isAnswerCorrect = answerChecker.CheckAnswer();
        if (isAnswerCorrect)
        {
            Debug.Log("right");
        }
    }
    public void StartLevel(int levelIndex)
    {
        LevelData level = levelGenerator.GenerateLevel(levelIndex);
        if (level != null)
        {
            //產生選項
            OptionData[] options = optionGenerator.GenerateOptions(level);
            //送答案
            answerChecker.SetAnswer(level.pinyin);
            //呈現關卡資料以及選項
            uiController.Display(level, options);
            currentLevel++;
        }
    }
}
