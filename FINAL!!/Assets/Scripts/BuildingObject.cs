using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingObject : MonoBehaviour
{
    public Building data;

    [Header("Resource Generation")]
    [Space(8)]

    //This will be the resource that has been created by this building.
    public float resource = 0;

    //Limit that this building can generate or do.
    public float resourceLimit = 100;

    //Speed that the resource is generated.
    public float generationSpeed = 5;


    [Header("UI")]
    [Space(8)]

    public GameObject canvasObject;
    public Slider progressSlider;

    Coroutine buildingBehaviour;

    private void Start()
    {
        if(data.resourceType == Building.ResourceType.Standard)
            {buildingBehaviour = StartCoroutine(CreateResource());}


     
        if (data.resourceType == Building.ResourceType.Food)
        {
            buildingBehaviour = StartCoroutine(CreateResource());
        }
    }

    private void OnMouseDown()
    {
        if (data.resourceType == Building.ResourceType.Food)
        {
            ResourceManager.Instance.AddFood((int)resource);  

        }
        switch (data.resourceType)
        {
            case Building.ResourceType.CO2:
           
                ResourceManager.Instance.RemoveCO2(15);
            
                break;

            case Building.ResourceType.Standard:

                ResourceManager.Instance.AddStandardC((int)resource);
                ResourceManager.Instance.RemoveFood((int)resource/5);

                break;



        }
       
       


        

        EmptyResource();
        
    }

    void EmptyResource()
    {
        resource = 0;
    }

    // void IncreaseMaxStorage()
    // {
    //     switch (data.storageType)
    //     {
    //         case Building.StorageType.Wood:
    //             ResourceManager.Instance.IncreaseMaxWood((int)resource);
    //             break;
    //         case Building.StorageType.Stone:
    //             ResourceManager.Instance.IncreaseMaxStone((int)resource);
    //             break;
    //     }
    // }

    IEnumerator CreateResource()
    {
        //It will create resources infinitely
        while (true)
        {
            if (resource < resourceLimit)
            {
                resource += generationSpeed * Time.deltaTime;
            }
            else
            {
                resource = resourceLimit;
            }

            UpdateUI(resource, resourceLimit);

            yield return null;
        }
    }

    public void UpdateUI(float current, float maxValue)
    {
        progressSlider.value = current;
        progressSlider.maxValue = maxValue;
    }

}
