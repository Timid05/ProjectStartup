using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AppManager : MonoBehaviour
{
    [SerializeField]
    Image mascotImage;
    public string currentScreen;
    public int tokenCount = 0;
    static AppManager manager = null;

    //singleton code, ensuring that there will only be one AppManager at a time
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(manager);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //method to reference the manager from anywhere
    public static AppManager GetManager()
    {
        return manager;
    }

    //for updating the current scene
    public void ChangeCurrentScreen(string screenName)
    {
        currentScreen = screenName;
    }

    //method to make sure the titlescreen doesn't slide in when starting the app
    public void EnableTitleAnim(Animator animator)
    {
        animator.SetBool("appStart", false);
    }

    //method to change the amount of tokens the user possesses
    public void AddTokens(int amount)
    {
        tokenCount = tokenCount + amount;
    }

    //Method for changing the image of the mascot on the homescreen
    public void ChangeMascot(Sprite newImage)
    {
        mascotImage.sprite = newImage;
    }
}
