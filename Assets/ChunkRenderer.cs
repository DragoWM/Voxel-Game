using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkRenderer : MonoBehaviour
{
    public GameObject world;

    private void Start()
    {
        generateChunk(new Vector3Int(0, 0, 0));
    }


    public void generateChunk(Vector3Int worldPos)
    {
        ChunkMesh chunkMesh = new ChunkMesh(worldPos, this.world, 16, 100);
    }
}

public class ChunkMesh
{
    public Vector3Int worldPosition;
    public int chunkSize;
    public int chunkHeight;

    //mesh directions looking at object from front
    public GameObject meshParent;

    // each side has a seperate gameobject to store the different sides of the mesh 
    // seperately, which helps with optimisation later on.
    public GameObject meshLeft;
    public GameObject meshRight;
    public GameObject meshFront;
    public GameObject meshBack;
    public GameObject meshUp;
    public GameObject meshDown;

    public List<GameObject> meshList;


    public ChunkMesh(Vector3Int worldPos, GameObject world, int chunkSize, int chunkHeight)
    {
        this.worldPosition = worldPos;
        this.chunkSize = chunkSize;
        this.chunkHeight = chunkHeight;

        generateMeshObjects(worldPos, world);
        
        
    }

    public void generateMeshObjects(Vector3Int worldPos, GameObject world)
    {
        this.meshParent = new GameObject("meshParent" + worldPos);
        this.meshParent.transform.SetParent(world.transform, false);
        this.meshParent.transform.position = worldPos;

        this.meshLeft = new GameObject("meshLeft");
        this.meshRight = new GameObject("meshRight");
        this.meshFront = new GameObject("meshFront");
        this.meshBack = new GameObject("meshBack");
        this.meshUp = new GameObject("meshUp");
        this.meshDown = new GameObject("meshDown");

        meshList = new List<GameObject>
        {
            this.meshLeft,
            this.meshRight,
            this.meshFront,
            this.meshBack,
            this.meshUp,
            this.meshDown
        };

        foreach (GameObject mesh in meshList) {
            mesh.transform.SetParent(this.meshParent.transform);
            mesh.AddComponent<MeshFilter>();
        }
    }

    public void generateMesh()
    {
        Vector3[] VertexPos = new Vector3[8] //definitions of verticies
        {
            //verticies from 0 - 7

            new Vector3(1,-1,-1),
            new Vector3(1,1,-1),
            new Vector3(1,1,1),
            new Vector3(1,-1,1),
            new Vector3(-1,-1,1),
            new Vector3(-1,1,1),
            new Vector3(-1,1,-1),
            new Vector3(-1,-1,-1)
        };
    }
}
