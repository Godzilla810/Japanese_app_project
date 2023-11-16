using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public Sprite image;
    public string pinyin;
    public bool isKatakana;
    public AudioClip audio;
    public List<string> answer { get; private set; }
    public List<Sprite> answerImg { get; private set; }
    public LevelData(Sprite image, string pinyin, bool isKatakana, AudioClip audio)
    {
        this.image = image;
        this.pinyin = pinyin;
        this.isKatakana = isKatakana;
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
        //建立N的特例
        bool encounterN = false;
        //建立抝音的特例
        string[] searchStrings = {"cha", "chu", "cho", "sha", "shu", "sho", "ja", "ju", "jo"};


        foreach (char character in standardString)
        {
            if (character == '-')
            {
                answer.Add("-");
            }
            //遇到N:先標記，如果接下來是子音，就結束片段
            else if (character == 'n')
            {
                currentSubString += character.ToString();
                encounterN = true;
            }
            //遇到母音:結束片段
            else if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
            {
                encounterN = false;
                currentSubString += character.ToString();
                //抝音
                if (currentSubString.Length > 2 && currentSubString != "shi" && currentSubString != "chi")
                {
                    string firstWord;
                    string secondWord = "ya";
                    if (searchStrings.Any(s => currentSubString.Contains(s)))
                    {
                        firstWord = currentSubString.Substring(0, currentSubString.Length - 1) + "i";
                    }
                    else
                    {
                        firstWord = currentSubString.Substring(0, currentSubString.Length - 2) + "i";
                    }
                    answer.Add(firstWord);
                    answer.Add(secondWord);
                }
                else
                {
                    answer.Add(currentSubString);
                }
                currentSubString = string.Empty;
            }
            //遇到子音:加入片段
            else
            {
                if (encounterN)
                {
                    encounterN = false;
                    answer.Add(currentSubString);
                    currentSubString = string.Empty;
                }
                currentSubString += character.ToString();
            }
        }
        //輸出句尾的N
        answer.Add(currentSubString);
    }
    private void SetAnswerImage()
    {
        string folderPath = isKatakana ? "JPChars/Katakana" : "JPChars/Hiragana";
        Sprite[] sprites = Resources.LoadAll<Sprite>(folderPath);
        foreach (string word in answer)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite.name == word)
                {
                    answerImg.Add(sprite);
                }
            }
        }
        
    }
}
