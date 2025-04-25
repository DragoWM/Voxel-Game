using UnityEngine;

//most basic renderer used for debugging only
public class DebugRenderer : TerrainRendererBase
{
    public override void renderTerrain()
    {
        Debug.Log("Debug render gen");

        //implement looping through data set and creating solid block where block exists by initiating cube object
        //this is meant to be an inneficient process meant for debugging only.
    }
}
