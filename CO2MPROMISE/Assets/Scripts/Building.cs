using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    //Building ID for referencing the exact type of building.
    public int buildingID;

    //Width X Axis that will be used inside the grid.
    public int width = 0;

    //Length Z Axis that will be used inside the grid
    public int length = 0;

    //Visual of the building.
    public GameObject buildingModel;

    //Small padding in case the building is clipping through the floor.
    public float yPadding = 0;

    //Type of functionality of the building
    public ResourceType resourceType = ResourceType.None;

    

    //[HideInInspector]
    public BuildingObject refOfBuilding;

    public enum ResourceType
    {
        None,
        Standard,
        Food,
        CO2
    }


}
