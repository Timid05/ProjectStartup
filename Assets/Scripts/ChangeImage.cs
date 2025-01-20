using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    //the image that needs to be changed
    public Image img;

    //changes selected img to the given sprite
    public void EditImage(Sprite sprite)
    {
        if (sprite != null)
        {
            img.sprite = sprite;
        }
        else
        {
            Console.WriteLine("Could not find sprite");
        }
    }

    //changes img color 
    private void ColorApply(Color color)
    {
        img.color = color;
    }

    //changes the affected image
    public void SetImage(Image newImage)
    {
        if (newImage != null)
        {
            img = newImage;
        }
        else
        {
            Debug.Log("New sprite was not set");
        }
    }

}
