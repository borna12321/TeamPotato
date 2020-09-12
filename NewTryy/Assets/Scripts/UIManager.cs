using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    
    [Space(8)]

    /* References for our containers */
    public StandardUIReference woodUI;
    public StandardUIReference stoneUI;
    public StandardUIReference standardCUI;
    public StandardUIReference premiumCUI;

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
    public void UpdateWoodUI(int currentAmount, int maxAmount)
    {
        //Set the text in the UI.
        woodUI.currentUI.text = currentAmount.ToString();
        woodUI.maxUI.text = "MAX: " + maxAmount.ToString();

        //Set the slider
        woodUI.slider.maxValue = maxAmount;
        woodUI.slider.value = currentAmount;
    }

    /// <summary>
    /// Updates the Stone UI.
    /// </summary>
    /// <param name="currentAmount">sets the current amount of the slider and text</param>
    /// <param name="maxAmount">sets the maximum amount of the slider and text</param>
    public void UpdateStoneUI(int currentAmount, int maxAmount)
    {
        //Set the text in the UI.
        stoneUI.currentUI.text = currentAmount.ToString();
        stoneUI.maxUI.text = "MAX: " + maxAmount.ToString();

        //Set the slider
        stoneUI.slider.maxValue = maxAmount;
        stoneUI.slider.value = currentAmount;
    }

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

    /// <summary>
    /// Updates the premium currency UI.
    /// </summary>
    /// <param name="currentAmount">sets the current amount of the slider and text</param>
    /// <param name="maxAmount">sets the maximum amount of the slider and text</param>
    // public void UpdatePremiumCUI(int currentAmount, int maxAmount)
    // {
    //     //Set the text in the UI.
    //     premiumCUI.currentUI.text = currentAmount.ToString();
    //     premiumCUI.maxUI.text = "MAX: " + maxAmount.ToString();

    //     //Set the slider
    //     premiumCUI.slider.maxValue = maxAmount;
    //     premiumCUI.slider.value = currentAmount;
    // }

    void UpdateAll()
    {
        UpdateWoodUI(ResourceManager.Instance.Wood, ResourceManager.Instance.maxWood);
        UpdateStoneUI(ResourceManager.Instance.Stone, ResourceManager.Instance.maxStone);
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
