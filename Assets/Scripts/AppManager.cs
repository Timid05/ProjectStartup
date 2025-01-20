using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AppManager : MonoBehaviour
{
    [SerializeField]
    string currentScene;
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
    public void ChangeCurrentScene(string sceneName)
    {
        currentScene = sceneName;
    }

    //reads the input from the referenced field to the console
    public void ReadInputField(TMP_InputField field)
    {
        Debug.Log("Input: " + field.text);
    }
}
