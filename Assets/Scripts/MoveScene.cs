using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    //reference to the manager
    AppManager manager;
    [SerializeField]
    GameObject currentScreen;

    private void Start()
    {
        manager = AppManager.GetManager();
        manager.ChangeCurrentScene(SceneManager.GetActiveScene().name);
    }

    //method to load the desired scene
    public void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        manager.ChangeCurrentScene(sceneName);
    }

    public void TransitionIntoScreen(GameObject nextScreen)
    {
        nextScreen.SetActive(true);
        currentScreen.SetActive(false);
        currentScreen = nextScreen;
    }
}
