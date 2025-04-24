using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRegister : MonoBehaviour
{
    public Dictionary<int, BlockBase> blockList = new Dictionary<int, BlockBase>();

    void Start()
    {
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

    public BlockBase returnBlock(int id)
    {
        BlockBase block = blockList[id];

        return block;
    }
}
