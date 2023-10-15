using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionData
{
    public Sprite image;
    public string name{get; private set;}
    public OptionData(Sprite image)
    {
        this.image = image;
        this.name = image.name;
    }
}
