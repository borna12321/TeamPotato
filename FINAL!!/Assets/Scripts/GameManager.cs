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
    public Transform tilesHolder;
    public float tileSize = 1;
    public float tileEndHeight = 1;

    [Space(8)]

    //This is the grid that directly stores all of the information.
    public TileObject[,] tileGrid = new TileObject[0, 0]; 

    [Header("Resources")]

    [Space(8)]

    public GameObject woodPrefab;
    public GameObject rockPrefab;
    public Transform resourcesHolder;

    [Range(0, 1)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;

    [Space(8)]

    //Debug method (the selected building).
    public BuildingObject buildingToPlace;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CreateLevel();
    }

    /// <summary>
    /// Create our grid depending on our level width and length.
    /// </summary>
    public void CreateLevel()
    {
        List<TileObject> visualGrid = new List<TileObject>();

        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //Directly spawns a tile.
                TileObject spawnedTile = SpawnTile(x * tileSize, z * tileSize);

                //Sets the TileObject world space data.
                spawnedTile.xPos = x;
                spawnedTile.zPos = z;

                //Checks whenever we can spawn an obstacle inside a tile, using the bounds parameters.
                if (x < xBounds || z < zBounds || z >= (levelLength - zBounds) || x >= (levelWidth - xBounds))
                {
                    //We can spawn an obstacle in there.
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;

                    if (spawnObstacle)
                    {
                        spawnedTile.data.SetOccupied(Tile.ObstacleType.Resource);

                        ObstacleObject tmpObstacle = SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);
                        tmpObstacle.SetTileReference(spawnedTile);
                    }
                }

                //Adds the spawned visual tileobject inside the list.
                visualGrid.Add(spawnedTile);

            }
        }

        CreateGrid(visualGrid);
    }

    /// <summary>
    /// Spawns and returns a tileObject
    /// </summary>
    /// <param name="xPos">X Position inside the world</param>
    /// <param name="zPos">Z position inside the world</param>
    /// <returns></returns>
    TileObject SpawnTile(float xPos,  float zPos)
    {
        //This will spawn the tile
        GameObject tmpTile = Instantiate(tilePrefab);

        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);

        tmpTile.name = "Tile " + xPos + " - " + zPos;

        //Check if the tile is able to hold an obstacle.

        //TODO: Make this to not get a component.
        return tmpTile.GetComponent<TileObject>();
    }

    /// <summary>
    /// Will spawn a resource obstacle directly in the coordinates
    /// </summary>
    /// <param name="xPos">X Position of the obstacle</param>
    /// <param name="zPos">Z Position of the obstacle</param>
    ObstacleObject SpawnObstacle(float xPos, float zPos)
    {
        //It has a 50% percent of spawning a wood obstacle
        bool isWood = Random.value <= 0.5f;

        GameObject spawnedObstacle = null;

        //Check whether we spawn a wood obstacle or a stone obstacle
        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
            spawnedObstacle.name = "Wood " + xPos + " - " + zPos;
        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefab);
            spawnedObstacle.name = "Stone " + xPos + " - " + zPos;
        }

        //Sets the position and the parent of the spawned resource.
        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
        spawnedObstacle.transform.SetParent(resourcesHolder);

        return spawnedObstacle.GetComponent<ObstacleObject>();
    }

    /// <summary>
    /// Create tile grid to add buildings.
    /// </summary>
    public void CreateGrid(List<TileObject> refVisualGrid)
    {
        //Set the size of our tile grid.
        tileGrid = new TileObject[levelWidth, levelLength];

        //Iterates through all of the tile grid
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //Connects the tile grid directly to the visual grid.
                tileGrid[x, z] = refVisualGrid.Find(v => v.xPos == x && v.zPos == z);
                //Debug.Log(tileGrid[x, z].gameObject.name);
            }
        }
    }

    /// <summary>
    /// Handles the placing system of the building.
    /// </summary>
    /// <param name="building">Building to place</param>
    /// <param name="tile">Tile to place the building to</param>
    public void SpawnBuilding(BuildingObject building, List<TileObject> tiles)
    {
        GameObject spawnedBuilding = Instantiate(building.gameObject);
        float sumX = 0;
        float sumZ = 0;

        //Sum value of X positions of all tiles.
        //Sum value of the Z positions of all the tiles.
        for (int i = 0; i < tiles.Count; i++)
        {
            sumX += tiles[i].xPos;
            sumZ += tiles[i].zPos;

            tiles[i].data.SetOccupied(Tile.ObstacleType.Building, spawnedBuilding.GetComponent<BuildingObject>());
            //Debug.Log("placed building in " + tiles[i].xPos + " - " + tiles[i].zPos);

        }

        //Sets the correct position.
        Vector3 position = new Vector3( (sumX / tiles.Count), building.data.yPadding, (sumZ / tiles.Count));
       if (building.data.resourceType == Building.ResourceType.Food)
       {
           ResourceManager.Instance.AddCO2(30);
       }


        spawnedBuilding.transform.position = position;

        
    }

    public void SelectBuilding(int id)
    {
        for (int i = 0; i < BuildingsDatabase.Instance.buildingsDatabase.Count; i++)
        {
            if (BuildingsDatabase.Instance.buildingsDatabase[i].buildingID == id)
            {
                buildingToPlace = BuildingsDatabase.Instance.buildingsDatabase[i].refOfBuilding;
            }
        }
    }
}
