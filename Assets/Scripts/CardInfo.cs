using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    AppManager manager;
    PetsHandler petsHandler;
    [SerializeField]
    GameObject expandedPrefab;

    [SerializeField]
    TextMeshProUGUI nameBox;
    [SerializeField]
    TextMeshProUGUI speciesBox;
    [SerializeField]
    TextMeshProUGUI breedBox;
    [SerializeField]
    TextMeshProUGUI sexBox;

    [SerializeField]
    Image petImage;
    [SerializeField]
    Sprite dogSprite;
    [SerializeField]
    Sprite catSprite;
    [SerializeField]
    Sprite birdSprite;

    public string cardSpecies;
    public string cardName;

    CardInfo expansionInfo;

    private void Start()
    {
        manager = AppManager.GetManager();
        petsHandler = manager.GetComponent<PetsHandler>();

        if (expandedPrefab != null )
        {
            expansionInfo = expandedPrefab.GetComponent<CardInfo>();
        }
    }

    public void RemoveButtonClick()
    {
        petsHandler.RemoveCard(gameObject);
    }

    public void SetCardName(string name)
    {
        nameBox.text = name;
        cardName = name;
    }

    public void SetCardBreed(string breed)
    {
        breedBox.text = breed;
    }

    public void SetCardSex(string sex)
    {
        sexBox.text = sex;
    }


    public void SetCardSpecies(string species)
    {
        speciesBox.text = species;
        cardSpecies = species;

        switch (species)
        {
            case "Dog":
                petImage.sprite = dogSprite;
                break;
            case "Cat":
                petImage.sprite = catSprite;
                break;
            case "Bird":
                petImage.sprite = birdSprite;
                break;
            default:
                Debug.Log("pet species not recognized");
                break;                
        }
    }

    public void ExpandCard()
    {
        if (expandedPrefab != null)
        {
            Debug.Log("Expanding card");
            TransferInfoToExpansion();
            GameObject expandedCard = Instantiate(expandedPrefab, petsHandler.petScreen.transform.position, Quaternion.identity, petsHandler.petScreen.transform);
            petsHandler.expandedCard = expandedCard;
            petsHandler.cardExpanded = true;
        }
        else
        {
            Debug.Log("No expanded prefab has been assigned");
        }
    }

    void TransferInfoToExpansion()
    {
        if (expansionInfo != null)
        {
            expansionInfo.SetCardName(nameBox.text);
            expansionInfo.SetCardSpecies(speciesBox.text);
            expansionInfo.SetCardBreed(breedBox.text);
            expansionInfo.SetCardSex(sexBox.text);
        }
        else
        {
            Debug.Log("Cardinfo for expansion was not found");
        }
    }
}
