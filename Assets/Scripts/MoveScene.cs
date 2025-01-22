using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    //reference to the manager
    AppManager manager = AppManager.GetManager();
    [SerializeField]
    GameObject currentScreen;

    public void UpdateScreen(GameObject nextScreen)
    {
        manager.currentScreen = nextScreen.name;
    }
}
