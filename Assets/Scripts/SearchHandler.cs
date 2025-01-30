using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SearchHandler : MonoBehaviour
{
    [SerializeField]
    GameObject contentHolder;
    [SerializeField]
    GameObject scrollView;
    [SerializeField]
    GameObject[] options;
    [SerializeField]
    GameObject searchBar;
    List<string> optionNames = new List<string>();

    int optionCount;
    TMP_InputField searchField;

    Vector3 firstOptionPosition = Vector3.zero;
    int activeOptionsCount = 0;

    void Start()
    {
        searchField = searchBar.GetComponent<TMP_InputField>();
        optionCount = contentHolder.transform.childCount;
        options = new GameObject[optionCount];

        for (int i = 0; i < optionCount; i++)
        {
            options[i] = contentHolder.transform.GetChild(i).gameObject;
            optionNames.Add(options[i].GetComponentInChildren<TextMeshProUGUI>().text);
        }

        ToggleScrollView();
    }

    public void ResetSearchBar()
    {
        searchField.text = string.Empty;
    }

    public void HideScrollView()
    {
        scrollView.SetActive(false);
    }

    public void ToggleScrollView()
    {

        if (scrollView.activeSelf)
        {
            scrollView.SetActive(false);
        }
        else
        {
            scrollView.SetActive(true);
        }
    }

    public void Search()
    {
        string searchText = searchField.text;
        int textLength = searchText.Length;

        if (firstOptionPosition == Vector3.zero)
        {
            firstOptionPosition = options[0].transform.localPosition;
            Debug.Log("position set to " + firstOptionPosition);
        }



        for (int i = 0; i < optionCount; i++)
        {
            if (searchText.Length <= optionNames[i].Length && searchText.Length != 0)
            {

                if (searchField.text.ToLower() == optionNames[i].Substring(0, searchText.Length).ToLower())
                {
                    options[i].SetActive(true);
                }
                else
                {
                    options[i].SetActive(false);
                }
            }

            if (searchText.Length == 0)
            {
                options[i].SetActive(true);
            }

        }

        foreach (var option in options)
        {
            if (option.activeSelf)
            {
                activeOptionsCount++;
                option.transform.localPosition = new Vector3(firstOptionPosition.x, firstOptionPosition.y - ((activeOptionsCount - 1) * 80), 0);
            }
        }

        activeOptionsCount = 0;
    }
}
