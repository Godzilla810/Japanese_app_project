using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public float scaleFactor = 0.8f;
    private string parent;
    private GameController gameController;
    void Start()
    {
        parent = this.transform.parent.name;
        gameController = GameController.instance;
    }
    public void ChangeParent(){
        if (this.transform.parent == GameObject.Find(parent).transform)
        {
            gameController.playerAnswer += this.GetComponent<Image>().sprite.name;
            ChangeParentToAnswerArea();
        }
        else
        {
            gameController.playerAnswer = gameController.playerAnswer.Replace(this.GetComponent<Image>().sprite.name, "");
            ChangeParentToOptionArea();
        }
    }
    public void ChangeParentToAnswerArea(){
        this.transform.SetParent(GameObject.Find("AnswerArea").transform);  
        this.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
    public void ChangeParentToOptionArea(){
        if (parent != null){
            this.transform.SetParent(GameObject.Find(parent).transform);
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
