using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShop : MonoBehaviour
{
    public GameObject Panel;

    public void TogglePanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
    // public void ClosePanel()

    // {
    //     if (Panel = null)
    //     {
    //         Panel.SetActive(false);
    //     }
    // }
}
