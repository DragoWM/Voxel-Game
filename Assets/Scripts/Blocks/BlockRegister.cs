using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRegister : MonoBehaviour
{
    // dictionary that works off of a simple int as the ID and stores the custom BlockBase object
    // int as the ID may be replaced in the future by int2,int3 or a float to make block variations/rotations easier to store
    // will be refactored when adding block variations.
    public Dictionary<int, BlockBase> blockList = new Dictionary<int, BlockBase>();

    void Start()
    {
        //register all block types, with their properties.
        //will need to be refactored in the future, by loading data from a file for easier maintainence.
        registerBlock(-1, false, "Error");
        registerBlock(0, false, "Air");
        registerBlock(1, true, "Stone");
    }

    private void registerBlock(int id, bool isSolid, string name)
    {
        //create block instance
        BasicBlock block = new BasicBlock();

        //assign variables
        block.isSolid = isSolid;
        block.name = name;

        //check if id is already assigned
        if (blockList.ContainsKey(id)) //cant assign block with identical id
        {
            Debug.Log("Key already exists. Cant register " + block.name);
        } else
        {
            //add block to dictionary
            this.blockList.Add(id, block);
        }
    }

    //basic function to return block instance
    public BlockBase returnBlock(int id)
    {
        BlockBase block = blockList[id];

        //add a check to see if block exists and if not, return -1 (error block)

        return block;
    }
}
