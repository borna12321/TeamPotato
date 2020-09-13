using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int resourceAmount = 10;

    TileObject refTile;

    /// <summary>
    /// This is a method that it is called whenever the item has been clicked or tapped.
    /// Works on Mobile and PC.
    /// </summary>
    private void OnMouseDown()
    {
        //Debug.Log("Clicked on " + gameObject.name);

        //OnClick Event
        bool usedResource = false;

        //We can call directly the method that adds the resource
        switch (obstacleType)
        {
            case ObstacleType.Wood:

                usedResource = ResourceManager.Instance.AddFood(resourceAmount);

                break;
            case ObstacleType.Rock:

                usedResource = ResourceManager.Instance.RemoveCO2(resourceAmount);

                break;
        }

        if (usedResource)
        {
            refTile.data.CleanTile();
            Destroy(gameObject);
        }
       // else
           // Debug.Log("could not destroy cause inventory is full");
        
    }

    public void SetTileReference(TileObject obj)
    {
        refTile = obj;
    }

    public enum ObstacleType
    {
        Wood,
        Rock
    }
}
