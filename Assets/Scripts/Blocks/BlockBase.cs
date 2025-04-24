using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockBase
{
    public bool isSolid { get; set; }
    public string name { get; set; }
}

public class BasicBlock : BlockBase
{

}