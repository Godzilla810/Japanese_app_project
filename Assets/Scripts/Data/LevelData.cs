using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public Sprite image;
    public string pinyin;
    public AudioClip audio;
    public List<string> answer { get; private set; }
    public List<Sprite> answerImg { get; private set; }
    public LevelData(Sprite image, string pinyin, AudioClip audio)
    {
        this.image = image;
        this.pinyin = pinyin;
        this.audio = audio;
        this.answer = new List<string>();
        this.answerImg = new List<Sprite>();
        SetAnswer();
        SetAnswerImage();
    }
    private void SetAnswer()
    {
        string standardString = pinyin.ToLower();
        //建立放小字串的空字串
        string currentSubString = string.Empty;
        foreach (char character in standardString)
        {
            //遇到母音:結束片段
            if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
            {
                currentSubString += character.ToString();
                answer.Add(currentSubString);
                currentSubString = string.Empty;
            }
            //遇到子音:加入片段
            else
            {
                currentSubString += character.ToString();
            }
        }
    }
    private void SetAnswerImage()
    {
        string folderPath = "JPChars";  //指定五十音資料夾路徑
        Sprite[] sprites = Resources.LoadAll<Sprite>(folderPath);
        // Debug.Log(sprites.Length);
        foreach (string word in answer)
        {
            foreach (Sprite sprite in sprites)
            {
                // Debug.Log(word);
                if (sprite.name == word)
                {
                    // Debug.Log(word + " find");
                    answerImg.Add(sprite);
                }
            }
        }
        
    }
}
