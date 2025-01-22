using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameBox;

    public void SetCardName(string name)
    {
        nameBox.text = name;
    }
}
