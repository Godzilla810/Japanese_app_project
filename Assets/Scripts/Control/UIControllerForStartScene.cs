using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerForStartScene : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject information;
    public void ShowInformation()
    {
        startBtn.SetActive(false);
        information.SetActive(true);

    }
    public void HideInformation()
    {
        startBtn.SetActive(true);
        information.SetActive(false);
    }
}
