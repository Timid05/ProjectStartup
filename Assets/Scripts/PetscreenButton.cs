using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetscreenButton : MonoBehaviour
{
    PetsHandler handler;
    Button button;

    private void Start()
    {
        handler = AppManager.GetManager().GetComponent<PetsHandler>();
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (button.interactable && handler.cardExpanded)
        {
            button.interactable = false;
        }

        if (!button.interactable && !handler.cardExpanded)
        {
            button.interactable = true;
        }
    }

}
