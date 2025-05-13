using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class DebugTerrainGen : TerrainGenerationBase
{
    private int dimX;
    private int dimY;
    private int dimZ;

    public override void GenerateTerrainData(int dimX, int dimY, int dimZ)
    {
        this.dimX = dimX;
        this.dimY = dimY;
        this.dimZ = dimZ;

        System.Random rnd = new System.Random();

        terrainData = new Dictionary<Vector3Int, int>();

        for (int x = 0; x < dimX; x++)
        {
            for (int y = 0; y < dimY; y++)
            {
                for (int z = 0; z < dimZ; z++)
                {
                    terrainData.Add(new Vector3Int(x, y, z), rnd.Next(0,2));
                }
            }
        }
    }

    public override void debugLogTerrainData()
    {
        for (int x = 0; x < dimX; x++)
        {
            for (int y = 0; y < dimY; y++)
            {
                for (int z = 0; z < dimZ; z++)
                {
                    Debug.Log(x.ToString() + y.ToString() + z.ToString() + terrainData[new Vector3Int(x, y, z)].ToString());
                }
            }
        }
    }
}

