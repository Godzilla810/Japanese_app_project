using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public LevelGenerator levelGenerator;
    public OptionGenerator optionGenerator;
    public UIController uiController;

    [HideInInspector]
    public string playerAnswer;
    [HideInInspector]
    public string trueAnswer;

    public float limitedTime = 10.0f;
    public int levelCount = 5;

    private bool isLearn;
    private int currentLevelIndex;
    private int error = 0;
    private bool isPause = false;
    private bool isInterrupt = false;
    private bool isTimesUp = false;

    void Start()
    {
        Initialize();
        StartLevel();
    }

    void Update()
    {
        Debug.Log(playerAnswer + "/" + trueAnswer);

        if (isLearn && playerAnswer == trueAnswer)
        {
            playerAnswer = "";
            uiController.ShowCorrect();
            StartCoroutine(WaitAndStartLevel());
        }
        else if (!isLearn && playerAnswer == trueAnswer)
        {
            isInterrupt = true;
            playerAnswer = "";
            uiController.ShowCorrect();
            StartCoroutine(WaitAndStartLevel());
        }
        else if (!isLearn && isTimesUp)
        {
            isTimesUp = false;
            error++;
            playerAnswer = "";
            uiController.ShowWrong();
            StartCoroutine(WaitAndStartLevel());
        }
    }

    void Initialize()
    {
        Time.timeScale = 1f;
        if (!GlobalData.mode)
        {
            isLearn = true;
            uiController.SetUpLearnModeUI();
        }
        else
        {
            isLearn = false;
            uiController.SetUpChallengeModeUI();
            SetTopicUI();
        }
    }
    
    void SetTopicUI()
    {
        if (GlobalData.chapter < 9)
            uiController.SetUpBasicTopicUI();
        else
            uiController.SetUpAdvancedTopicUI();
    }

    void BuildLevel(LevelData levelData)
    {
        List<Sprite> optionImg = optionGenerator.GenerateOptions(levelData.answerImg);
        trueAnswer = string.Join("", levelData.answer);
        uiController.SetUp(levelData, optionImg);
    }

    void StartLevel()
    {
        if (isLearn)
            StartSequentialLevel();
        else
            StartRandomLevel();
    }

    void StartSequentialLevel()
    {
        LevelData levelData = levelGenerator.GenerateLevel(currentLevelIndex);

        if (levelData != null)
        {
            BuildLevel(levelData);
            currentLevelIndex++;
        }
        else
        {
            uiController.ShowGoodEnd();
        }
    }

    void StartRandomLevel()
    {
        int levelIndex = Random.Range(0, levelGenerator.GetChapterLength());
        LevelData levelData = levelGenerator.GenerateLevel(levelIndex);

        if (currentLevelIndex < levelCount)
        {
            BuildLevel(levelData);
            StartCoroutine(StartTimer());
            currentLevelIndex++;
        }
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
        StartLevel();
    }

    IEnumerator StartTimer()
    {
        float currentTime = limitedTime;
        uiController.slider.GetComponent<Slider>().maxValue = limitedTime;
        uiController.slider.GetComponent<Slider>().value = limitedTime;

        while (currentTime > 0.0f)
        {
            currentTime -= Time.deltaTime;
            uiController.slider.GetComponent<Slider>().value = currentTime;
            yield return null;

            if (isInterrupt)
            {
                isInterrupt = false;
                yield break;
            }
        }

        isTimesUp = true;
    }
    
    public void Pause()
    {
        isPause = !isPause;
        if (isPause)
        {
            uiController.ShowPause();
            Time.timeScale = 0f; // 將時間流逝速度設為0，達到暫停效果
        }
        else
        {
            uiController.HideFeedBack();
            Time.timeScale = 1f; // 恢復正常時間流逝速度
        }
    }
}
