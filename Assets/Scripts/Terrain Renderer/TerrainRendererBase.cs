using System.Collections.Generic;
using UnityEngine;

//renderer base class, allows for modular management of renderer.
public abstract class TerrainRendererBase : MonoBehaviour
{
    public BlockRegister blockRegister;
    public abstract void renderTerrain(Dictionary<Vector3Int, string> terrainData, Vector3Int chunkDim);
}

