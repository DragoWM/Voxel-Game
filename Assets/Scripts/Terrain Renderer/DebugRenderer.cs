using UnityEngine;

public class DebugRenderer : TerrainRendererBase
{
    public override void renderTerrain()
    {
        Debug.Log("Debug render gen");
    }
}
