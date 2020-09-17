using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    
    [Space(8)]

    /* References for our containers */
    public StandardUIReference foodUI;
    public StandardUIReference CO2UI;
  
    public StandardUIReference standardCUI;
   

    //Instance handling for singleton
    public static UIManager Instance;

    private void Awake()
    {
        //Initializing the singleton pattern (not for production)
        Instance = this;
    }

    private void Start()
    {
        UpdateAll();
    }

    /// <summary>
    /// Updates the wood UI.
    /// </summary>
    /// <param name="currentAmount">sets the current amount of the slider and text</param>
    /// <param name="maxAmount">sets the maximum amount of the slider and text</param>
    public void UpdateFoodUI(int currentAmount, int maxAmount)
    {
        //Set the text in the UI.
        foodUI.currentUI.text = currentAmount.ToString();
        foodUI.maxUI.text = "MAX: " + maxAmount.ToString();

        //Set the slider
        foodUI.slider.maxValue = maxAmount;
        foodUI.slider.value = currentAmount;
    }
    public void UpdateCO2UI(int currentAmount, int maxAmount)
    {
        
        CO2UI.currentUI.text = currentAmount.ToString();
        CO2UI.maxUI.text = "Max: " + maxAmount.ToString();


        CO2UI.slider.maxValue = maxAmount;
        CO2UI.slider.value = currentAmount;




    }
    /// <summary>
    /// Updates the Stone UI.
    /// </summary>
    /// <param name="currentAmount">sets the current amount of the slider and text</param>
    /// <param name="maxAmount">sets the maximum amount of the slider and text</param>
  

    /// <summary>
    /// Updates the standard currency UI.
    /// </summary>
    /// <param name="currentAmount">sets the current amount of the slider and text</param>
    /// <param name="maxAmount">sets the maximum amount of the slider and text</param>
    public void UpdateStandardCUI(int currentAmount, int maxAmount)
    {
        //Set the text in the UI.
        standardCUI.currentUI.text = currentAmount.ToString();
        standardCUI.maxUI.text = "MAX: " + maxAmount.ToString();

        //Set the slider
        standardCUI.slider.maxValue = maxAmount;
        standardCUI.slider.value = currentAmount;
    }



    void UpdateAll()
    {
        UpdateFoodUI(ResourceManager.Instance.Food, ResourceManager.Instance.maxFood);
        UpdateCO2UI(ResourceManager.Instance.Co2, ResourceManager.Instance.maxCO2);
        UpdateStandardCUI(ResourceManager.Instance.StandardC, ResourceManager.Instance.maxStandardCurrency);
       // UpdatePremiumCUI(ResourceManager.Instance.PremiumC, ResourceManager.Instance.maxPremiumCurrency);
    }
}

//Main class for setting up the containers.
[System.Serializable]
public class StandardUIReference
{
    public Slider slider;
    public Text maxUI;
    public Text currentUI;
}
