using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Dynamic;
using Unity.Collections.LowLevel.Unsafe;

public class MealHandler : MonoBehaviour
{
    [SerializeField]
    GameObject mealScreen;
    
    [SerializeField]
    GameObject mealCardPrefab;
    GameObject mealOverview;
    GameObject addMealScreen;
    Mealinfo mealInfo;

    public List<GameObject> meals;

    string mealName;
    string calorieCount;
    string carbCount;
    string fatCount;
    string proteinCount;

    bool nameHasContent;
    bool calorieHasContent;
    bool carbHasContent;
    bool fatHasContent;
    bool proteinHasContent;

    int mealCount = 0;

    GameObject noMealText;
    GameObject makeMealButton;

    
    public TextMeshProUGUI calorieCounter;
    public TextMeshProUGUI carbCounter;
    public TextMeshProUGUI fatCounter;
    public TextMeshProUGUI proteinCounter;


    private void Awake()
    {

        noMealText = GameObject.FindGameObjectWithTag("noMeal");
        makeMealButton = GameObject.FindGameObjectWithTag("makeMealButton");
        mealOverview = GameObject.FindGameObjectWithTag("mealOverview");
        addMealScreen = GameObject.FindGameObjectWithTag("addMealScreen");
    }

    void Start()
    {
        meals = new List<GameObject>();
        mealInfo = mealCardPrefab.GetComponent<Mealinfo>();

        if (mealScreen != null) 
        {
            


            if(mealScreen == null) 
            {
                Debug.Log("no mealscreen found");
            }
            if(noMealText == null)
            {
                Debug.Log("no meal text not found");
            }
            if(makeMealButton == null)
            {
                Debug.Log("no make meal button present");
            }
            else
            {
                addMealScreen.SetActive(false);
            }

            if(mealOverview == null)
            {
                Debug.Log("no overview found");
            }
            

        }
    }

    public void CardMakerOn()
    {
        mealOverview.SetActive(false);
        addMealScreen.SetActive(true);
        
    }

    public void ReturnToOverview()
    {
        addMealScreen.SetActive(false);
        mealOverview.SetActive(true);
    }

    public void NameInput(TMP_InputField nameBox)
    {
        if (!string.IsNullOrEmpty(nameBox.text))
        {
            mealName = nameBox.text;
            Debug.Log("Name set to: " + mealName);
            nameHasContent = true;
        }
        else
        {
            nameHasContent = false;
            Debug.Log("no info");

        }
    }

    public void CalorieInput(TMP_InputField calorieBox)
    {
        if (!string.IsNullOrEmpty(calorieBox.text))
        {
            calorieCount = calorieBox.text;
            Debug.Log("Calorie set to: " + calorieCount);
            calorieHasContent = true;
            
        }
        else
        {
            calorieHasContent = false;
        }
    }

    public void CarbInput(TMP_InputField carbBox)
    {
        if (!string.IsNullOrEmpty(carbBox.text))
        {
            carbCount = carbBox.text;
            Debug.Log("Carb set to: " + carbCount);
            carbHasContent = true;
        }
        else
        {
            carbHasContent = false;
        }
    }

    public void FatInput(TMP_InputField fatBox)
    {
        if (!string.IsNullOrEmpty(fatBox.text))
        {
            fatCount = fatBox.text;
            Debug.Log("Fat set to: " + fatCount);
            fatHasContent = true;
        }
        else
        {
            fatHasContent = false;
        }
    }

    public void ProteinInput(TMP_InputField proteinBox)
    {
        if (!string.IsNullOrEmpty(proteinBox.text))
        {
            proteinCount = proteinBox.text;
            Debug.Log("Protein set to: " + proteinCount);
            proteinHasContent = true;
        }
        else
        {
            proteinHasContent = false;
        }
    }

    public void MakeMeal()
    {
        if (mealCount < 3 && AllInfoGiven())
        {
            
            mealInfo.setMealName(mealName);
            mealInfo.setCardCalories(calorieCount);
            mealInfo.setCardCarbs(carbCount);
            mealInfo.setCardFat(fatCount);
            mealInfo.setCardProtein(proteinCount);

            GameObject newMeal = Instantiate(mealCardPrefab, new Vector3(mealScreen.transform.position.x, (mealScreen.transform.position.y + 450) - (mealCount * 550), 0), new Quaternion(0, 0, 0, 0), mealOverview.transform);
            meals.Add(newMeal);
            mealCount++;
            
            
                int totalCalories = int.Parse(calorieCounter.text);
                int addedCalories = int.Parse(calorieCount);
                totalCalories = totalCalories + addedCalories;
                calorieCounter.text = totalCalories.ToString();

                int totalCarbs = int.Parse(carbCounter.text);
                int addedCarbs = int.Parse(carbCount);
                totalCarbs = totalCarbs + addedCarbs;
                carbCounter.text = totalCarbs.ToString();

                int totalFat = int.Parse(fatCounter.text);
                int addedFat = int.Parse(fatCount);
                totalFat = totalFat + addedFat;
                fatCounter.text = totalFat.ToString();

                int totalProtein = int.Parse(proteinCounter.text);
                int addedProtein = int.Parse(proteinCount);
                totalProtein = totalProtein + addedProtein;
                proteinCounter.text = totalProtein.ToString();
                

            
            ReturnToOverview();


            Debug.Log("cards: " + meals.Count);
            
        }
    }

    bool AllInfoGiven()
    {
        if (nameHasContent && calorieHasContent && carbHasContent && fatHasContent && proteinHasContent)
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

        if (mealCount > 0)
        {
            noMealText.SetActive(false);
        }
        else
        {
            noMealText.SetActive(true);
        }

        if (AllInfoGiven())
        {
            makeMealButton.SetActive(true);
        }
        else
        {
            makeMealButton.SetActive(false);
        }
        


    }
}
