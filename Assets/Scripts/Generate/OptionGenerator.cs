using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionGenerator : MonoBehaviour
{
    public static int optionNumber = 9;
    public OptionData[] optionDatas = new OptionData[optionNumber];
    public Sprite[] all50;

    public OptionData[] GenerateOptions(LevelData levelData)
    {
        int answerNumber = levelData.answerImg.Length;
        //添加答案陣列
        for (int i = 0 ;i < answerNumber; i++)
        {
            //建立optionData資料
            Sprite img = levelData.answerImg[i];
            OptionData optionData = new OptionData(img);
            optionDatas[i] = optionData;
        }
        //添加非答案陣列
        for (int i = answerNumber ;i < optionNumber; i++)
        {
            OptionData optionData;
            do{
                int randomInt = Random.Range(1, all50.Length);
                Sprite img = all50[randomInt];
                optionData = new OptionData(img);
            } while(Repeat(optionData, optionDatas, i));
            optionDatas[i] = optionData;
        }
        //打亂陣列
        Shuffle();
        return optionDatas;
    }

    public bool Repeat(OptionData optionData , OptionData[] optionDatas, int currentIndex)
    {
        bool isRepeat = false;
        for (int i = 0; i < currentIndex; i++)
        {
            if (optionData.name == optionDatas[i].name)
            {
                isRepeat = true;
            }
        }
        return isRepeat;
    }
    public void Shuffle()
    {
        int n = optionDatas.Length;
        for (int i = 0; i < n; i++)
        {
            int randomIndex = Random.Range(i, n);

            // 交换元素
            OptionData temp = optionDatas[i];
            optionDatas[i] = optionDatas[randomIndex];
            optionDatas[randomIndex] = temp;
        }
    }
}
