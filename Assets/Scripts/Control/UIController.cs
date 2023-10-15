using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject image;
    public TextMeshProUGUI pinyin;
    public AudioSource soundBtn;
    public GameObject[] options;
    public void Display(LevelData levelData, OptionData[] optionDatas)
    {
        image.GetComponent<Image>().sprite = levelData.image;
        pinyin.text = levelData.pinyin;
        soundBtn.clip = levelData.audio;
        for (int i = 0; i < optionDatas.Length; i++)
        {
            options[i].GetComponent<Image>().sprite = optionDatas[i].image;
        }
    }
}
