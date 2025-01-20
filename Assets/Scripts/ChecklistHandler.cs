using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChecklistHandler : MonoBehaviour
{
    List<string> symptoms = new List<string>();

    //call on this method if you want the symptoms list written in the console
    public void PrintSymptoms()
    {
        Debug.Log("Symptoms: " + string.Join(", ", symptoms));
    }

    //method that edits the symptoms list
    public void ToggleChange(Toggle toggle)
    {
        Text label = toggle.GetComponentInChildren<Text>();

        //if the toggle is checked, add the corresponding symptom to the list
        if(toggle.isOn)
        {
            symptoms.Add(label.text);
            Debug.Log("Added " + label.text + " to the symptoms list");
        }
        else
        {
            //if unchecked, look if the symptom exists inside the list and remove it
            for(int i = 0; i < symptoms.Count; i++)
            {
                if (symptoms[i] == label.text)
                {
                    symptoms.Remove(label.text);
                    Debug.Log("Removed " + label.text + " from the symptoms list");
                }
            }
        }
    }
}
