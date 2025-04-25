using UnityEngine;

//base terrain generator class to allow for easy swapping out of terrain generators
public abstract class TerrainGenerationBase : MonoBehaviour
{
    public abstract void GenerateTerrainData();
}
