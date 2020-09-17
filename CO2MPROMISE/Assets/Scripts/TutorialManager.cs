using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialManager : MonoBehaviour

{
    public GameObject[] popUps;
    private int popUpIndex;
    
    public GameObject yourButton;

   public void Start ()
    {
        Button btn = yourButton.GetComponent<Button>();
    }

 public void TaskOnClick()
    {
        Debug.Log ("clicked");
        popUpIndex = 5;
        for (int i = 0; i<popUps.Length; i++)
        {
            popUps[i].SetActive(false);
        }
        
        yourButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

      SetItActive();

      

    }
    public void SetItActive()
    {
          for (int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true); //shows that index only
            }
            else
            {
                popUps[i].SetActive(false); //hides other index's
            }
        }
    }
   public void ButtonOne()
   {
       popUpIndex=0;
   
   }
    public void ButtonTwo()
    {
        popUpIndex=1;
    }
    public void ButtonThree()
    {
       popUpIndex=2;
    }
    public void ButtonFour()
    {
        popUpIndex=3;
    }
    public void ButtonFive()
    {
        popUpIndex=4;
    }
    public void LastButton()
    {
        popUpIndex = 5;
        for (int i = 0; i<popUps.Length; i++)
        {
            popUps[i].SetActive(false);
        }
        
        yourButton.SetActive(false);
    }
}