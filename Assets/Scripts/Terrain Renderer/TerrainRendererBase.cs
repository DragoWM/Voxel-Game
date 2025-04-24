using UnityEngine;

//renderer base class, allows for modular management of renderer.
public abstract class TerrainRendererBase : MonoBehaviour
{
    public abstract void renderTerrain();
}

