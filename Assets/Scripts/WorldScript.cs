using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private BlockRegister blockRegister;
    private TerrainGenerationBase terrainGenerator;
    private TerrainRendererBase terrainRenderer;

    [SerializeField] public int chunkSizeX;
    [SerializeField] public int chunkSizeY;
    [SerializeField] public int chunkSizeZ;

    // Start is called before the first frame update
    void Start()
    {
        //ini scripts
        getScriptReferences();

        //generate terrain
        terrainGenerator.blockRegister = blockRegister;
        terrainGenerator.GenerateTerrainData(chunkSizeX, chunkSizeY, chunkSizeZ);
        terrainGenerator.debugLogTerrainData();

        //render terrain
        terrainRenderer.blockRegister = blockRegister;
        terrainRenderer.renderTerrain(terrainGenerator.terrainData, new Vector3Int(chunkSizeX, chunkSizeY, chunkSizeZ));

    }

    void getScriptReferences()
    {
        //ini scripts
        //Block register script is responsible for loading and storing all blocks used in the game.
        Transform child = transform.Find("BlockRegister");
        if (child != null)
        {
            blockRegister = child.GetComponent<BlockRegister>();
        }

        //Terrain generator generates the terrain and stores the data into the world script
        child = transform.Find("TerrainGenerator");
        if (child != null)
        {
            terrainGenerator = child.GetComponent<TerrainGenerationBase>();
        }

        //Terrain renderer will take the data from the generator and render it to the screen for the player to see
        child = transform.Find("TerrainRenderer");
        if (child != null)
        {
            terrainRenderer = child.GetComponent<TerrainRendererBase>();
        }
    }
}


