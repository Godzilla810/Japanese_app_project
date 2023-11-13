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
    public GameObject[] options;
    private void Start() {
        //學習模式
        if (!GlobalData.mode)
        {
            slider.SetActive(false);
        }
        //挑戰模式
        else{
            slider.SetActive(true);
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
    public void HideFeedBack()
    {
        correct.SetActive(false);
    }
}
