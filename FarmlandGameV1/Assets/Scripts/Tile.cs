using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Tile 
{
    // Building reference 
    public Building buildingRef;
    // Tile occupied
    public bool isOccupied;
    // Type that is occupying
    public OccupationType occupationType;
    public enum OccupationType
    {
        None,
        Resource,
        Building


    }
    public void SetOccupied(OccupationType t, Building b)
    {
        isOccupied= true;
        occupationType = t;

        buildingRef = b;
    }
    public void CleanTile()
    {
        occupationType = OccupationType.None;
        isOccupied = false;
    }
}
