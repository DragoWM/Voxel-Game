using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private BlockRegister blockList;
    private TerrainGenerationBase terrainGenerator;
    private TerrainRendererBase terrainRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //ini scripts
        getScriptReferences();

        //generate terrain
        if (terrainGenerator == null)
        {
            Debug.Log("Terrain Gen Missing!");
            return;
        }

        terrainGenerator.GenerateTerrainData();

        //render terrain
        terrainRenderer.renderTerrain();

    }

    void getScriptReferences()
    {
        //ini scripts
        Transform child = transform.Find("BlockRegister");
        if (child != null)
        {
            blockList = child.GetComponent<BlockRegister>();
        }

        child = transform.Find("TerrainGenerator");
        if (child != null)
        {
            terrainGenerator = child.GetComponent<TerrainGenerationBase>();
        }

        child = transform.Find("TerrainRenderer");
        if (child != null)
        {
            terrainRenderer = child.GetComponent<TerrainRendererBase>();
        }
    }
}


