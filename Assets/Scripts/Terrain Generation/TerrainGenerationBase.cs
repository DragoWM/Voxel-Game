using System.Collections.Generic;
using UnityEngine;

//base terrain generator class to allow for easy swapping out of terrain generators
public abstract class TerrainGenerationBase : MonoBehaviour
{
    public Dictionary<Vector3Int, int> terrainData;

    public abstract void GenerateTerrainData(int dimX, int dimY, int dimZ);

    public abstract void debugLogTerrainData();
}
