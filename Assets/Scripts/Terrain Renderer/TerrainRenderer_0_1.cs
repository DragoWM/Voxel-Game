using JetBrains.Annotations;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

//most basic renderer used for debugging only
public class TerrainRenderer_0_1 : TerrainRendererBase
{
    // x = left(+)/right(-)
    // y = up(+)/down(-)
    // z = forwards(+)/backwards(-)

    public GameObject cube;

    public override void renderTerrain(Dictionary<Vector3Int, string> terrainData, Vector3Int chunkDim)
    {
        Vector3Int[] neighbourDir =
        {
            new Vector3Int (0,0,1),
            new Vector3Int (0,0,-1),
            new Vector3Int (0,1,0),
            new Vector3Int (0,-1,0),
            new Vector3Int (1,0,0),
            new Vector3Int (-1,0,0),
        };

        for (int x = 0; x < chunkDim.x; x++)
        {
            for (int y = 0; y < chunkDim.y; y++)
            {
                for (int z = 0; z < chunkDim.z; z++)
                {
                    Vector3Int currentPosition = new Vector3Int(x, y, z);

                    if (blockRegister.blockList[terrainData[currentPosition]].isSolid == true)
                    {
                        //check if bounding edge, if so, instantiate cube

                        if (currentPosition.x == 0 || currentPosition.x == chunkDim.x - 1)
                        {
                            Instantiate(cube, currentPosition, Quaternion.identity);
                            continue;
                        }

                        if (currentPosition.y == 0 || currentPosition.y == chunkDim.y - 1)
                        {
                            Instantiate(cube, currentPosition, Quaternion.identity);
                            continue;
                        }

                        if (currentPosition.z == 0 || currentPosition.z == chunkDim.z - 1)
                        {
                            Instantiate(cube, currentPosition, Quaternion.identity);
                            continue;
                        }

                        foreach (Vector3Int neighbour in neighbourDir)
                        {
                            Vector3Int neighbourPos = currentPosition + neighbour;

                            if (blockRegister.blockList[terrainData[neighbourPos]].isSolid == false) {
                                Instantiate(cube, currentPosition, Quaternion.identity);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

