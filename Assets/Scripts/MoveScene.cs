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
    [SerializeField]
    Animator animator;
    [SerializeField]
    float delayTime;

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

    void Delay()
    {
        StartCoroutine(DelayRoutine());
    }

    IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(delayTime);
        
        yield return new WaitForSeconds(0.3f);
        animator.SetTrigger("symptoms_opened");
    }
}
