using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]

    [Space(8)]

    //Sets the max amount of wood
    public int maxWood;
    int wood = 0;

    //Sets the max amount of stone
    public int maxStone;
    int stone = 100;

    //Sets the max amount of premium currency
    public int maxPremiumCurrency;
    int premiumC = 0;

    //Sets the max amount of standard currency
    public int maxStandardCurrency;
    int standardC = 0;

    public static ResourceManager Instance;

    public bool debugBool = false;

    public int Wood
    {
        get
        {
            return wood;
        }

        set
        {
            wood = value;
        }
    }

    public int Stone
    {
        get
        {
            return stone;
        }

        set
        {
            stone = value;
        }
    }

    public int PremiumC
    {
        get
        {
            return premiumC;
        }

        set
        {
            premiumC = value;
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
    public bool AddWood(int amount)
    {
        if ((wood + amount) <= maxWood)
        {
            Wood += amount;

            //Updates the corresponding UI.
            UIManager.Instance.UpdateWoodUI(Wood, maxWood);

            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void IncreaseMaxWood(int amount)
    {
        maxWood += amount;

        UIManager.Instance.UpdateWoodUI(wood, maxWood);
    }

    /// <summary>
    /// Adds more stone to the inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing stone</param>
    public bool AddStone(int amount)
    {
        if ((stone - amount) <= maxStone)
        {
            Stone -= amount;

            //Updates the corresponding UI.
            UIManager.Instance.UpdateStoneUI(Stone, maxStone);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncreaseMaxStone(int amount)
    {
        maxStone += amount;

        UIManager.Instance.UpdateStoneUI(stone, maxStone);
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
    public bool AddPremiumC(int amount)
    {
        if ((PremiumC + amount) <= maxPremiumCurrency)
        {
            PremiumC += amount;

            //Updates the corresponding UI.
           // UIManager.Instance.UpdatePremiumCUI(PremiumC, maxPremiumCurrency);

            return true;
        }
        else
        {
            return false;
        }
    }

    

    void PrintCurrentResources()
    {
        // Debug.Log("wood " + Wood);
        // Debug.Log("stone " + Stone);
        // Debug.Log("standard " + StandardC);
        // Debug.Log("premium " + PremiumC);
    }
}
