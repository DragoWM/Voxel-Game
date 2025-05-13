using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainGenerator_0_1 : TerrainGenerationBase
{
    private int dimX;
    private int dimY;
    private int dimZ;

    private float[,] heightMap;

    public float scale; // How zoomed in perlin noise is
    public int octaves; // Number of noise layers
    public float persistence; // Amplitute reduction per layer
    public float lacunarity;  // Frequency increase per layer

    public override void GenerateTerrainData(int dimX, int dimY, int dimZ)
    {
        this.dimX = dimX;
        this.dimY = dimY;
        this.dimZ = dimZ;

        this.heightMap = new float[dimX, dimZ];

        System.Random rnd = new System.Random();

        terrainData = new Dictionary<Vector3Int, string>();

        generateHeightMap();
        normalizeHeightMap();
        calculateTerrainData();
    }

    private void generateHeightMap()
    {
        Vector2 offset = new Vector2(100f, 200f);

        for (int x = 0; x < dimX; x++)
        {
            for (int z = 0; z < dimZ; z++)
            {
                float amplitude = 1f;
                float frequency = 1f;
                float noiseHeight = 0f;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (x + offset.x) / scale * frequency;
                    float sampleY = (z + offset.y) / scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1; // Range: [-1, 1]
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistence;
                    frequency *= lacunarity;
                }

                heightMap[x, z] = noiseHeight;
            }
        }
    }

    private void normalizeHeightMap()
    {
        float min = float.MaxValue;
        float max = float.MinValue;

        // Find min and max
        foreach (float val in heightMap)
        {
            if (val < min) min = val;
            if (val > max) max = val;
        }

        // Normalize to [0,1]
        for (int x = 0; x < dimX; x++)
        {
            for (int z = 0; z < dimZ; z++)
            {
                heightMap[x, z] = Mathf.InverseLerp(min, max, heightMap[x, z]);
            }
        }
    }

    private void calculateTerrainData()
    {
        for (int x = 0; x < dimX; x++)
        {
            for (int z = 0; z < dimZ; z++)
            {
                int height = Mathf.FloorToInt(heightMap[x, z] * dimY);

                for (int y = 0; y <= dimY; y++)
                {
                    if (y <= height && y >= height - 3)
                        this.terrainData[new Vector3Int(x, y, z)] = "stone";
                    else
                        this.terrainData[new Vector3Int(x, y, z)] = "air";
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
                    Debug.Log(x.ToString() + y.ToString() + z.ToString() + terrainData[new Vector3Int(x, y, z)]);
                }
            }
        }
    }
}