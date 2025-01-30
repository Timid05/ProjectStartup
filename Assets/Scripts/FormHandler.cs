using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FormHandler : MonoBehaviour
{
    AppManager manager;
    [SerializeField]
    GameObject noPetsText;
    [SerializeField]
    GameObject vetPopup;
    [SerializeField]
    TextMeshProUGUI popupText;
    PetsHandler petsHandler;
    [SerializeField]
    GameObject profilePrefab;
    [SerializeField]
    GameObject backButton;
    ProfileInfo profileInfo;

    ChecklistHandler checklistHandler;

    List<GameObject> profiles = new List<GameObject>();
    int oldCardCount;
    public bool updateChecklist;

    public GameObject lastClickedProfile;

    void Start()
    {
        manager = AppManager.GetManager();
        
        checklistHandler = GetComponentInChildren<ChecklistHandler>();

        if (checklistHandler == null )
        {
            Debug.Log("checklisthandler not found");
        }

        if (manager != null)
        {
            petsHandler = manager.GetComponent<PetsHandler>();
        }
        else
        {
            Debug.Log("AppManager not found");
        }

        if (petsHandler == null)
        {
            Debug.Log("no petshandler found");
        }
        else
        {
            profileInfo = profilePrefab.GetComponent<ProfileInfo>();
            oldCardCount = petsHandler.cards.Count;
        }

        vetPopup.SetActive(false);
    }

    public void DisableBackButton()
    {
        backButton.SetActive(false);
    }

    public void EnableBackButton()
    {
        backButton.SetActive(true);
    }

    private void UpdateProfiles()
    {
        if (petsHandler != null)
        {
            for (int i = 0; i < profiles.Count; i++)
            {
                Destroy(profiles[i]);           
            }

            profiles.Clear();

            for (int i = 0; i < petsHandler.cards.Count; i++)
            {
                SetProfile(i);
                GameObject newProfile = Instantiate(profilePrefab, gameObject.transform.position + new Vector3(800 + i * 300, 700, 0), Quaternion.identity, gameObject.transform);             
                profiles.Add(newProfile);
                oldCardCount = petsHandler.cards.Count;
                Debug.Log("Added profile to form");
            }
        }
    }

    void SetProfile(int cardIndex)
    {
        CardInfo cardInfo = petsHandler.cards[cardIndex].GetComponent<CardInfo>();

        profileInfo.SetName(cardInfo.cardName);

        switch (cardInfo.cardSpecies)
        {
            case "Dog":
                profileInfo.SetToDog();
                break;
            case "Cat":
                profileInfo.SetToCat();
                break;
            case "Bird":
                profileInfo.SetToBird();
                break;
            default:
                Debug.Log("no valid input given");
                break;
        }
 
    }

    private void DisableProfiles()
    {
        foreach(var profile in profiles)
        {
            profile.SetActive(false);
        }
    }

    public void ResetPage()
    {
        EnableProfiles();
        vetPopup.SetActive(false);

    }

    public void EnableProfiles()
    {
        foreach (var profile in profiles)
        {
            profile.SetActive(true);
        }
        vetPopup.SetActive(false);
    }

    public void FormSubmitted()
    {         
        if (checklistHandler.symptomCount >= 2)
        {
            popupText.text = "Please go to the vet";
        }
        else
        {
            popupText.text = "You do not need to go to the vet";
        }
        DisableProfiles();
        vetPopup.SetActive(true);
        lastClickedProfile = null;
    }

    private void Update()
    {
        if (petsHandler.cards.Count != oldCardCount)
        {
            UpdateProfiles();
        }

        if (lastClickedProfile == null && checklistHandler.gameObject.activeSelf)
        {
            checklistHandler.gameObject.SetActive(false);
        }

        if (!checklistHandler.gameObject.activeSelf && lastClickedProfile != null)
        {
            checklistHandler.gameObject.SetActive(true);
        }

        if (petsHandler.cards.Count == 0 && !noPetsText.activeSelf)
        {
            noPetsText.SetActive(true);
        }

        if (petsHandler.cards.Count > 0 && noPetsText.activeSelf)
        {
            noPetsText.SetActive(false);
        }
    }
}
