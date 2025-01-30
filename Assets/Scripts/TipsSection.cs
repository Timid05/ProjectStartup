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
            case "Incontinence":
                textField.text = "Dog diapers are very effective in helping with your pet's cleanliness, but you need to monitor it frequently. So that they don't get overly dirty and don't cause infections. Finding one that fits might take some time. Once you found it make sure to check it frequently.";
                break;
            case "Diabetes":
                textField.text = "Something that really helps with regulating your pet's blood sugar is to leave eating for only a certain time a day. It might be easy to leave out food all day but the frequent snacking can cause a lot of fluctuation in your pet's blood sugar. Try to give it 2 to 3 controlled meals a day. ";
                break;
            case "Broken Bone":
                textField.text = "Step One:\r\n check if your pet has any other injury. If it has a clear wound cover it with a clean piece of cloth to reduce chance of infections. If it is bleeding try to control that with light pressure and again a piece of cloth. \r\n\r\nStep Two:\r\nTry to move your pet to a safe location. If their leg is broken make sure that they don't walk. And if you suspect that its spine is broken then move it using a flat surface so that its spine doesn't move.\r\n\r\nStep Three:\r\nCall your local veterinarian. Make an emergency appointment. Refrain from feeding your pet or giving it water before you have spoken with the vet.";
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
