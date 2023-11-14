using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    //物件
    public GameObject slider;
    public GameObject image;
    public GameObject pinyin;
    public GameObject soundBtn;
    public GameObject correct;
    public GameObject wrong;
    public GameObject goodEnd;
    public GameObject badEnd;
    public GameObject pausePanel;
    public GameObject[] options;
    //參數
    public float limitedTime = 10.0f;
    public bool isTimesUp = false;
    public bool isReset = false;
    //控制元件
    private Slider sliderTimer;
    private Sprite imageSprite;
    private TextMeshProUGUI pinyinText;
    private AudioSource soundAudio;
    private void Awake() 
    {
        sliderTimer = slider.GetComponent<Slider>();
        imageSprite = image.GetComponent<Image>().sprite;
        pinyinText = pinyin.GetComponent<TextMeshProUGUI>();
        soundAudio = soundBtn.GetComponent<AudioSource>();
    }
    public void SetUpLearnModeUI()
    {
        slider.SetActive(false);
    }
    public void SetUpChallengeModeUI(){
            slider.SetActive(true);
            sliderTimer.minValue = 0.0f;
            sliderTimer.maxValue = limitedTime;
            sliderTimer.value = limitedTime;
    }
    public void SetUpBasicTopicUI(){
        image.SetActive(false);
        soundBtn.SetActive(false);
    }
    public void SetUpAdvancedTopicUI(){
        pinyin.SetActive(false);
        soundBtn.SetActive(false);
    }
    public IEnumerator StartTimer()
    {
        float currentTime = limitedTime;
        while (currentTime > 0.0f)
        {
            currentTime -= Time.deltaTime;
            sliderTimer.value = currentTime;
            yield return null;
            if (isReset)
            {
                isReset = false;
                yield break;
            }
        }
        isTimesUp = true;
        Debug.Log("end");
    }
    public void SetUp(LevelData levelData, List<Sprite> optionImg)
    {
        //LevelData
        imageSprite = levelData.image;
        pinyinText = levelData.pinyin;
        soundAudio = levelData.audio;
        //OptionData
        for (int i = 0; i < optionImg.Count; i++)
        {
            options[i].GetComponent<Option>().ChangeParentToOptionArea();
            options[i].GetComponent<Image>().sprite = optionImg[i];
        }
    }
    public void ShowCorrect()
    {
        correct.SetActive(true);
    }
    public void ShowWrong()
    {
        wrong.SetActive(true);
    }
    public void ShowGoodEnd()
    {
        goodEnd.SetActive(true);
    }
    public void ShowBadEnd()
    {
        badEnd.SetActive(true);
    }
    public void ShowPause()
    {
        pausePanel.SetActive(true);
    }
    public void HideFeedBack()
    {
        correct.SetActive(false);
        wrong.SetActive(false);
        goodEnd.SetActive(false);
        badEnd.SetActive(false);
        pausePanel.SetActive(false);
    }
}
