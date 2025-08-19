using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

//most basic renderer used for debugging only
public class TerrainRenderer_0_1 : TerrainRendererBase
{
    // x = left(+)/right(-)
    // y = up(+)/down(-)
    // z = forwards(+)/backwards(-)

    public GameObject cube;

    public override void renderTerrain(Dictionary<Vector3Int, string> terrainData, Vector3Int chunkDim)
    {
        Vector3Int[] neighbourDir =
        {
            new Vector3Int (-1,0,0),
            new Vector3Int (1,0,0),
            new Vector3Int (0,-1,0),
            new Vector3Int (0,1,0),
            new Vector3Int (0,0,-1),
            new Vector3Int (0,0,1)
        };

        //Debug.Log(dimensions.x + "," + dimensions.y + "," + dimensions.z);

        List<Vector3> Vertices = new List<Vector3>();
        List<int> Triangles = new List<int>();

        Vector3[] VertexPos = new Vector3[8]
        {
            //verticies from 0 - 7

            new Vector3(1, -1, -1),
            new Vector3(1, 1, -1),
            new Vector3(1, 1, 1),
            new Vector3(1, -1, 1),
            new Vector3(-1, -1, 1),
            new Vector3(-1, 1, 1),
            new Vector3(-1, 1, -1),
            new Vector3(-1, -1, -1),
        };

        int[][] faceVertices = new int[][]
        {
            new int[]{4, 5, 6, 7}, // right
            new int[]{0, 1, 2, 3}, // left
            new int[]{7, 0, 3, 4}, // down
            new int[]{1, 6, 5, 2}, // up
            new int[]{7, 6, 1, 0}, // backwards
            new int[]{3, 2, 5, 4}  // forwards
        };

        //int addquadcount = 0;

        //loop through voxel list
        for (int x = 0; x < chunkDim.x; x++)
        {
            for (int y = 0; y < chunkDim.y; y++)
            {
                for (int z = 0; z < chunkDim.z; z++)
                {
                    Vector3Int currentPosition = new Vector3Int(x, y, z);

                    if (currentPosition == new Vector3Int(10,15,31)) 
                    {
                        Console.WriteLine();
                    }

                    if (blockRegister.blockList[terrainData[currentPosition]].isSolid == true)
                    {
                        //check all adjacent voxels and generate mesh if side is visible

                        for (int n = 0; n < neighbourDir.Length; n++)
                        {   
                            try { 
                                if (blockRegister.blockList[terrainData[currentPosition + neighbourDir[n]]].isSolid == false)
                                {
                                    AddQuad(faceVertices[n] , Vertices.Count, currentPosition);
                                }
                            } catch
                            {
                                //AddQuad(faceVertices[n], Vertices.Count, currentPosition);
                            }
                        }
                        /*
                        //right
                        try
                        {
                            if (Voxels[x - 1, y, z] == (byte)0)
                            {
                                AddQuad(4, 5, 6, 7, Vertices.Count, new Vector3(x, y, z));
                            }
                        }
                        catch
                        {
                            AddQuad(4, 5, 6, 7, Vertices.Count, new Vector3(x, y, z));
                        }

                        //left
                        try
                        {
                            if (Voxels[x + 1, y, z] == (byte)0)
                            {
                                AddQuad(0, 1, 2, 3, Vertices.Count, new Vector3(x, y, z));
                            }
                        }
                        catch
                        {
                            AddQuad(0, 1, 2, 3, Vertices.Count, new Vector3(x, y, z));
                        }

                        //down 
                        try
                        {
                            if (Voxels[x, y - 1, z] == (byte)0)
                            {
                                AddQuad(7, 0, 3, 4, Vertices.Count, new Vector3(x, y, z));
                            }
                        }
                        catch
                        {
                            AddQuad(7, 0, 3, 4, Vertices.Count, new Vector3(x, y, z));
                        }


                        //up 
                        try
                        {
                            if (Voxels[x, y + 1, z] == (byte)0)
                            {
                                AddQuad(1, 6, 5, 2, Vertices.Count, new Vector3(x, y, z));
                            }
                        }
                        catch
                        {
                            AddQuad(1, 6, 5, 2, Vertices.Count, new Vector3(x, y, z));
                        }


                        //back 
                        try
                        {
                            if (Voxels[x, y, z - 1] == (byte)0)
                            {
                                AddQuad(7, 6, 1, 0, Vertices.Count, new Vector3(x, y, z));
                            }
                        }
                        catch
                        {
                            AddQuad(7, 6, 1, 0, Vertices.Count, new Vector3(x, y, z));
                        }


                        //front 
                        try
                        {
                            if (Voxels[x, y, z + 1] == (byte)0)
                            {
                                AddQuad(3, 2, 5, 4, Vertices.Count, new Vector3(x, y, z));
                            }
                        }
                        catch
                        {
                            AddQuad(3, 2, 5, 4, Vertices.Count, new Vector3(x, y, z));
                        }
                        */
                    }
                }
            }
        }

        worldObj.GetComponent<MeshFilter>().mesh = new Mesh()
        {
            vertices = Vertices.ToArray(),
            triangles = Triangles.ToArray()
        };

        void AddQuad(int[] VerticeNum, int i, Vector3 pos)
        {
            Vector3 a = (VertexPos[VerticeNum[0]] / 2) + pos;
            Vector3 b = (VertexPos[VerticeNum[1]] / 2) + pos;
            Vector3 c = (VertexPos[VerticeNum[2]] / 2) + pos;
            Vector3 d = (VertexPos[VerticeNum[3]] / 2) + pos;

            Vertices.AddRange(new List<Vector3>() { a, b, c, d });
            Triangles.AddRange(new List<int>() { i, i + 1, i + 2, i, i + 2, i + 3 });
        }
    }
}

