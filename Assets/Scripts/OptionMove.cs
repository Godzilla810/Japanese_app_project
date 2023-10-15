using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMove : MonoBehaviour
{ 
    private string parent;
    void Start()
    {
        parent = gameObject.transform.parent.name;
    }
    public void ChangeParent(){
        if (gameObject.transform.parent == GameObject.Find(parent).transform)
        {
            gameObject.transform.SetParent(GameObject.Find("AnserArea").transform);  
        }
        else
        {
            gameObject.transform.SetParent(GameObject.Find(parent).transform);
        }
    }
}
