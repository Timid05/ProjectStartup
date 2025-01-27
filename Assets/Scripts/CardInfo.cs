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

    private void Start()
    {
        manager = AppManager.GetManager();
        petsHandler = manager.GetComponent<PetsHandler>();
    }

    public void RemoveButtonClick()
    {
        petsHandler.RemoveCard(gameObject);
    }

    public void SetCardName(string name)
    {
        nameBox.text = name;
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
}
