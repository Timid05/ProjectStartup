using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FormHandler : MonoBehaviour
{
    AppManager manager;
    PetsHandler petsHandler;
    [SerializeField]
    GameObject profilePrefab;

    List<GameObject> profiles = new List<GameObject>();

    [SerializeField]
    int oldCardCount;

    void Start()
    {
        manager = AppManager.GetManager();
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
            oldCardCount = petsHandler.cards.Count;
        }
    }

    private void UpdateProfiles()
    {
        if (petsHandler != null)
        {
            for (int i = 0; i < petsHandler.cards.Count; i++)
            {
                GameObject newProfile = Instantiate(profilePrefab, new Vector3(885, 770, 0), Quaternion.identity, gameObject.transform);
                profiles.Add(newProfile);
                Debug.Log("Added profile to form");
            }
        }
    }

    private void OnDisable()
    {
        if (petsHandler.cards.Count != oldCardCount)
        {
            UpdateProfiles();
        }
    }
}
