using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputReset : MonoBehaviour
{
    TMP_InputField inputField;

    private void Start()
    {       
        inputField = GetComponent<TMP_InputField>();
    }

    private void OnDisable()
    {
        if (inputField != null)
        {
            inputField.text = string.Empty;
        }
    }
}
