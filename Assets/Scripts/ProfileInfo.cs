using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProfileInfo : MonoBehaviour
{
    [SerializeField]
    Image icon;
    [SerializeField]
    TextMeshProUGUI nameField;

    [SerializeField]
    Sprite dogIcon;
    [SerializeField]
    Sprite catIcon;
    [SerializeField]
    Sprite birdIcon;

    FormHandler formHandler;
    bool selected;

    private void OnEnable()
    {
        formHandler = GetComponentInParent<FormHandler>();
    }

    public void SetToDog()
    {
        icon.sprite = dogIcon;
    }

    public void SetToCat()
    {
        icon.sprite = catIcon;
    }

    public void SetToBird()
    {
        icon.sprite = birdIcon;
    }

    public void SetName(string name)
    {
        nameField.text = name;
    }

    public void Clicked()
    {
        if (nameField.color == Color.black)
        {
            formHandler.lastClickedProfile = gameObject;
            selected = true;
            formHandler.updateChecklist = true;
            nameField.color = Color.green;
        }
        else
        {
            formHandler.lastClickedProfile = null;
            selected = false;
            nameField.color = Color.black;
        }
    }

    private void Update()
    {
        if (formHandler.lastClickedProfile != gameObject && selected)
        {
            nameField.color = Color.black;
            selected = false;
        }
    }  

}
