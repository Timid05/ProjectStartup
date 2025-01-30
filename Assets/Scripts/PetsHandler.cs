using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetsHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject petScreen;
    [SerializeField]
    GameObject cardPrefab;
    [SerializeField]
    GameObject expansionReturnButton;
    [SerializeField]
    GameObject mealScreen;
    CardInfo cardInfo;
    GameObject cardMaker;
    GameObject overview;

    public GameObject expandedCard;

    public List<GameObject> cards;

    string petName;
    string petSpecies;
    string petBreed;
    string petSex;
    int cardsCount = 0;
    bool nameHasContent;
    bool speciesSelected;
    bool breedHasContent;
    bool sexSelected;
    public bool cardExpanded;

    GameObject cardButton;
    GameObject noPetsText;

    private void Start()
    {
        cards = new List<GameObject>();
        cardInfo = cardPrefab.GetComponent<CardInfo>();

        if (petScreen != null)
        {
            cardMaker = GameObject.FindGameObjectWithTag("cardmaker");
            overview = GameObject.FindGameObjectWithTag("petoverview");
            cardButton = GameObject.FindGameObjectWithTag("cardconfirm");
            noPetsText = GameObject.FindGameObjectWithTag("nopets");

            if (noPetsText == null)
            {
                Debug.Log("Petshandler didn't find 'no pets textField'");
            }

            if (cardButton == null)
            {
                Debug.Log("Petshandler didn't find 'Make card button'");
            }

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

            mealScreen.SetActive(false);
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
        mealScreen.SetActive(false);
        overview.SetActive(true);
    }

    public void MoveToMeals()
    {
        overview.SetActive(false);
        mealScreen.SetActive(true);
    }

    public void NameInput(TMP_InputField namefield)
    {
        if (!string.IsNullOrEmpty(namefield.text))
        {
            petName = namefield.text;
            Debug.Log("Name set to: " + petName);
            nameHasContent = true;
        }
        else
        {
            nameHasContent = false;
        }
    }

    public void DestroyExpansion()
    {
        Destroy(expandedCard);
        cardExpanded = false;
    }

    public void SpeciesInput(TMP_Dropdown speciesField)
    {
        if (speciesField.captionText.text == "Dog" || speciesField.captionText.text == "Cat" || speciesField.captionText.text == "Bird")
        {
            petSpecies = speciesField.captionText.text;
            speciesSelected = true;
            Debug.Log("Species set to: " + petSpecies + ", " + speciesSelected);
        }
        else
        {
            speciesSelected = false;
            Debug.Log("species false");
        }
    }

    public void BreedInput(TMP_InputField breedField)
    {
        if (!string.IsNullOrEmpty(breedField.text))
        {
            petBreed = breedField.text;
            Debug.Log("Breed set to: " + petBreed);
            breedHasContent = true;
        }
        else
        {
            breedHasContent = false;
        }
    }

    public void SexInput(TMP_Dropdown sexField)
    {
        if (sexField.captionText.text == "Male" || sexField.captionText.text == "Female")
        {
            petSex = sexField.captionText.text;
            Debug.Log("Sex set to: " + petSex);
            sexSelected = true;
        }
        else
        {
            sexSelected = false;
        }
    }

    public void MakeCard()
    {
        if (cardsCount < 3 && AllInfoGiven())
        {
            cardInfo.SetCardName(petName);
            cardInfo.SetCardSpecies(petSpecies);
            cardInfo.SetCardBreed(petBreed);
            cardInfo.SetCardSex(petSex);

            GameObject newCard = Instantiate(cardPrefab, new Vector3(petScreen.transform.position.x, (petScreen.transform.position.y + 800) - (cardsCount * 550), 0), new Quaternion(0, 0, 0, 0), overview.transform);
            cards.Add(newCard);
            cardsCount++;
            ReturnToOverview();

            Debug.Log("cards: " + cards.Count);
        }
    }

    public void RemoveCard(GameObject card)
    {
        cards.Remove(card);
        Destroy(card);
        cardsCount--;
        Debug.Log("cards: " + cards.Count);
        UpdateCardPositions();
    }

    public void ExpandCard(CardInfo info)
    {

    }

    void UpdateCardPositions()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.position = new Vector3(petScreen.transform.position.x, (petScreen.transform.position.y + 700) - (i * 550), 0);
        }
    }

    bool AllInfoGiven()
    {
        if (nameHasContent && speciesSelected && breedHasContent && sexSelected)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FixedUpdate()
    {

        if (cardsCount > 0)
        {
            noPetsText.SetActive(false);
        }
        else
        {
            noPetsText.SetActive(true);
        }

        if (AllInfoGiven())
        {
            cardButton.SetActive(true);
        }
        else
        {
            cardButton.SetActive(false);
        }

        if (!expansionReturnButton.activeSelf && cardExpanded)
        {
            expansionReturnButton.SetActive(true);
        }

        if (expansionReturnButton.activeSelf && !cardExpanded)
        {
            expansionReturnButton.SetActive(false);
        }


    }
}
