using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownReset : MonoBehaviour
{
    [SerializeField]
    string defaultText;
    [SerializeField]
    TMP_Dropdown dropdown;

    bool defaultIn;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        if (dropdown != null)
        {
            dropdown.captionText.text = defaultText;
            if (!defaultIn)
            {
                dropdown.options.Insert(0, new TMP_Dropdown.OptionData(defaultText));
                defaultIn = true;
            }
        }
        else
        {
            Debug.LogError("Object does not contain dropdown component");
        }

        if (defaultText == null)
        {
            Debug.LogWarning("Please set dropdown default textField");
        }
    }

    private void OnEnable()
    {
        if (dropdown != null && !defaultIn)
        {
            dropdown.options.Insert(0, new TMP_Dropdown.OptionData(defaultText)); 
            defaultIn = true;
        }
        dropdown.captionText.text = defaultText;
    }

    public void RemoveDefault()
    {
        if (dropdown != null && defaultIn)
        {
            dropdown.options.RemoveAt(0);            
            defaultIn = false;
            dropdown.value--;
            dropdown.RefreshShownValue();
        }
    }

}
