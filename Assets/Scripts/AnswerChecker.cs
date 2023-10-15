using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour
{
    string correctAnswer;
    public void SetAnswer(string answer)
    {
        correctAnswer = answer;
    }
    public bool CheckAnswer()
    {
        string playerAnswer = GetPlayerAnswer();
        if (correctAnswer == playerAnswer)
            return true;
        else
            return false;
    }
    public string GetPlayerAnswer()
    {
        string playerAnswer = "";
        int childNumber = this.transform.childCount;
        Transform[] childObject = new Transform[childNumber];
        for (int i = 0; i < childNumber; i++)
        {
            childObject[i] = this.transform.GetChild(i);
            playerAnswer += childObject[i].GetComponent<Image>().sprite.name;
        }
        Debug.Log(playerAnswer);
        return playerAnswer;
    }
}
