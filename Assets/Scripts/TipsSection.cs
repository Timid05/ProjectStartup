using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipsSection : MonoBehaviour
{
    TextMeshProUGUI textField;

    private void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
    }

    public void EditText(string conditionName)
    {
        switch (conditionName)
        {
            case "Diabetes":
                textField.text = "Girl how much sugar you been giving that poor thing my god";
                break;
            case "Broken Bone":
                textField.text = "Literally what do you want me to say go to the fat stupid ass";
                break;
            case "Incontinence":
                textField.text = "Invest in waterproof floors xoxo";
                break;
            default:
                Debug.Log("Condition not registered");
                break;
        }
    }

    public void ResetText()
    {
        textField.text = string.Empty;
    }
}
