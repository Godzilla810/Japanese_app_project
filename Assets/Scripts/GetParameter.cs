using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetParameter : MonoBehaviour
{
    public void SetMode(bool _mode){
        GlobalData.mode = _mode;
    }
    public void SetLevel(int _level){
        GlobalData.level = _level;
    }
}
