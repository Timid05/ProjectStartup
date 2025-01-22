using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetsHandler : MonoBehaviour
{
    [SerializeField]
    GameObject petScreen;
    [SerializeField]
    GameObject cardPrefab;
    CardInfo cardInfo;
    GameObject cardMaker;
    GameObject overview;

    string petName;
    int cardsCount = 0;
    bool nameHasContent;

    GameObject cardButton;
    GameObject noPetsText;

    private void Start()
    {
        cardInfo = cardPrefab.GetComponent<CardInfo>();

        if (petScreen != null)
        {
            cardMaker = GameObject.FindGameObjectWithTag("cardmaker");
            overview = GameObject.FindGameObjectWithTag("petoverview");
            cardButton = GameObject.FindGameObjectWithTag("cardconfirm");
            noPetsText = GameObject.FindGameObjectWithTag("nopets");

            if (cardMaker == null)
            {
                Debug.LogError("Pet screen does not contain cardmaker");
            }
            else
            {
                cardMaker.SetActive(false);
            }

            if (overview == null)
            {
                Debug.LogError("Pet screen does not contain overview");
            }
        }
    }

    public void CardMakerOn()
    {
        overview.SetActive(false);
        cardMaker.SetActive(true);
    }

    public void ReturnToOverview()
    {
        cardMaker.SetActive(false);
        overview.SetActive(true);
    }

    public void NameInput(TMP_InputField namefield)
    {
        if (!string.IsNullOrEmpty(namefield.text))
        {
            petName = namefield.text;
            Debug.Log("pet name saved as: " + petName);
            nameHasContent = true;
        }
        else
        {
            nameHasContent = false;
        }
    }

    public void MakeCard()
    {
        if (cardsCount < 3 && nameHasContent)
        {
            cardInfo.SetCardName(petName);
            Instantiate(cardPrefab, new Vector3(petScreen.transform.position.x, (petScreen.transform.position.y + 700) - (cardsCount * 550), 0), new Quaternion(0, 0, 0, 0), overview.transform);
            cardsCount++;
            ReturnToOverview();
        }
    }

    private void Update()
    {
        if (cardsCount > 0)
        {
            noPetsText.SetActive(false);
        }
        else
        {
            noPetsText.SetActive(true);
        }

        if (nameHasContent)
        {
            cardButton.SetActive(true);
        }
        else
        {
            cardButton.SetActive(false);
        }
    }
}
