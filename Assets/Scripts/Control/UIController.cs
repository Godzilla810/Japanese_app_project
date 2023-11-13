using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject slider;
    public GameObject image;
    public GameObject pinyin;
    public GameObject soundBtn;
    public GameObject correct;
    public GameObject wrong;
    public GameObject goodEnd;
    public GameObject badEnd;
    public GameObject[] options;
    public float limitedTime = 10.0f;
    public bool isTimesUp = false;
    public bool isReset = false;
    private void Start() {
        //學習模式
        if (!GlobalData.mode)
        {
            slider.SetActive(false);
        }
        //挑戰模式
        else{
            slider.SetActive(true);
            slider.GetComponent<Slider>().minValue = 0.0f;
            slider.GetComponent<Slider>().maxValue = limitedTime;
            slider.GetComponent<Slider>().value = limitedTime;
            //基礎題
            if (GlobalData.chapter <= 8)
            {
                image.SetActive(false);
                soundBtn.SetActive(false);
            }
            //進階題
            else
            {
                pinyin.SetActive(false);
                soundBtn.SetActive(false);
            }
        }
    }
    public IEnumerator StartTimer()
    {
        float currentTime = limitedTime;
        while (currentTime > 0.0f)
        {
            currentTime -= Time.deltaTime;
            slider.GetComponent<Slider>().value = currentTime;
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
        image.GetComponent<Image>().sprite = levelData.image;
        pinyin.GetComponent<TextMeshProUGUI>().text = levelData.pinyin;
        soundBtn.GetComponent<AudioSource>().clip = levelData.audio;
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
    public void HideFeedBack()
    {
        correct.SetActive(false);
        wrong.SetActive(false);
        goodEnd.SetActive(false);
        badEnd.SetActive(false);
    }
}
