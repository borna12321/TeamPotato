using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Building
{
    // Building ID for referencing the exact type of building
    public int buildingID;
    // Width X axis on the grid
    public int width = 0;
    // Length Z axis on the grid
    public int length = 0; 
    // Building functionality
    public ResourceType resourceType = ResourceType.Gold;
 public enum ResourceType
 {
     Co2,
     Gold,
     Food,

 }
    
}
