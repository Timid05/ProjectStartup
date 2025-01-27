using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenText : MonoBehaviour
{
    AppManager manager;
    TextMeshProUGUI tokenText;
    int oldTokenCount;

    void Start()
    {
        manager = AppManager.GetManager();
        tokenText = GetComponent<TextMeshProUGUI>();

        if (tokenText == null )
        {
            Debug.Log("Did not find TextMeshProUGUI component");
        }

        if (manager == null)
        {
            Debug.Log("Could not find AppManager");
        }
        else
        {
            oldTokenCount = manager.tokenCount;
        }
    }

    void Update()
    {
        if (manager.tokenCount != oldTokenCount)
        {
            tokenText.text = "Tokens: " + manager.tokenCount;
            oldTokenCount = manager.tokenCount;
        }
    }
}
