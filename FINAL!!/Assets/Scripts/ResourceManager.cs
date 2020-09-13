using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]

    [Space(8)]


    public int minCO2;
    public int maxCO2;
    int CO2 = 0;
    //Sets the max amount of wood
    public int minFood = 0;
    public int maxFood;
    public static int food = 0;

 
  

    //Sets the max amount of standard currency
    public int maxStandardCurrency;
    int standardC = 0;

    public static ResourceManager Instance;

    public bool debugBool = false;

    public int Co2
    {
        get
        {
            return CO2;
        }
        set 
        {
            CO2 = value;
        }
    }
    public int Food
    {
        get
        {
            return food;
        }

        set
        {
            food = value;
        }
    }


   

    public int StandardC
    {
        get
        {
            return standardC;
        }

        set
        {
            standardC = value;
        }
    }

    private void Awake()
    {
        //Initializing the singleton pattern (not for production)
        Instance = this;
    }

    private void Update()
    {
        if (debugBool)
        {
            PrintCurrentResources();
            debugBool = false;
        }
    }

    /// <summary>
    /// Adds more wood to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing wood</param>
    public bool AddCO2(int amount)
    {
        if ((CO2+amount)<= maxCO2)
        {
            CO2+=amount;
            UIManager.Instance.UpdateCO2UI(Co2,maxCO2);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool RemoveCO2(int amount)
    {
        if((CO2+amount)<= minCO2)
        {
            CO2 -= amount;
            UIManager.Instance.UpdateCO2UI(Co2, maxCO2);
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool RemoveFood(int amount)
    {
        
        if ((food - amount )>=minFood)
        {
            food-=amount;
            UIManager.Instance.UpdateFoodUI(Food,maxFood);
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool AddFood(int amount)
    {
        if ((food + amount) <= maxFood)
        {
            food += amount;

            //Updates the corresponding UI.
            UIManager.Instance.UpdateFoodUI(Food, maxFood);

            return true;
        }
        else
        {
            return false;
        }
        
    }

  

    /// <summary>
    /// Adds more StandardC to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing StandardC</param>
    public bool AddStandardC(int amount)
    {
        if ((standardC + amount) <= maxStandardCurrency)
        {
            standardC += amount;

            //Updates the corresponding UI.
            UIManager.Instance.UpdateStandardCUI(StandardC, maxStandardCurrency);

            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Adds more PremiumC to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing PremiumC</param>
  

    

    void PrintCurrentResources()
    {
        // Debug.Log("wood " + Wood);
        // Debug.Log("stone " + Stone);
        // Debug.Log("standard " + StandardC);
        // Debug.Log("premium " + PremiumC);
    }
}
