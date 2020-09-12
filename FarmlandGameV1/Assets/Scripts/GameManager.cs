using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]
    [Space(8)]
    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;

    public Transform tileHolder;

    private void Start() 
    {
        CreateLevel();
    }

    // Grid creation deepending on length and with

    public void CreateLevel()
    {
        for(int x=0; x<levelWidth;x++)
        {
             for(int z=0; z<levelLength;z++)
                {   
                    SpawnTile(x, z);
                }
        }
    }
    //Spawns and returns a tileObject
    //zPos = Position on the z axis in the world
    //xPos = Position on the x axis in the world






    TileObject SpawnTile(float xPos, float zPos)
    {
        //spawns the tile
        GameObject tmpTile = Instantiate(tilePrefab);

        tmpTile.transform.position = new Vector3(xPos,0,zPos); 
        tmpTile.transform.SetParent(tileHolder);

        return tmpTile.GetComponent<TileObject>();
    }
}
