using System.Collections.Generic;
using UnityEngine;

//renderer base class, allows for modular management of renderer.
public abstract class TerrainRendererBase : MonoBehaviour
{
    public BlockRegister blockList;
    public abstract void renderTerrain(Dictionary<Vector3Int, int> terrainData, Vector3Int chunkDim);
}

