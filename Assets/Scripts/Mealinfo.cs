using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mealinfo : MonoBehaviour
{
    AppManager Manager;
    MealHandler mealHandler;

    [SerializeField]
    TextMeshProUGUI nameBox;
    [SerializeField]
    TextMeshProUGUI calorieBox;
    [SerializeField]
    TextMeshProUGUI carbBox;
    [SerializeField]
    TextMeshProUGUI fatBox;
    [SerializeField]
    TextMeshProUGUI proteinBox;

    private void Start()
    {
        Manager = AppManager.GetManager();
        mealHandler = Manager.GetComponent<MealHandler>();
    }

    public void setMealName(string name)
    {
        nameBox.text = name;
    }
    public void setCardCalories(string calories) 
    {
        calorieBox.text = calories;
    }
    public void setCardCarbs(string carbs)
    {
        carbBox.text = carbs;
    }

    public void setCardFat(string fat)
    {
        fatBox.text = fat;
    }
    public void setCardProtein(string protein)
    {
        proteinBox.text = protein;
    }
}
