using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//most basic renderer used for debugging only
public class DebugRenderer : TerrainRendererBase
{
    public GameObject cube;

    public override void renderTerrain(Dictionary<Vector3Int, string> terrainData, Vector3Int chunkDim)
    {
        for (int x = 0; x < chunkDim.x; x++)
        {
            for (int y = 0; y < chunkDim.y; y++)
            {
                for (int z = 0; z < chunkDim.z; z++)
                {
                    if (blockRegister.blockList[terrainData[new Vector3Int(x, y, z)]].isSolid == true) {
                        Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
                    }
                }
            }
        }
    }
}
