//basic block structure definition.
//will definitely be refactored once I get around to looking at block variations.
public abstract class BlockBase
{
    public bool isSolid { get; set; }
    public string name { get; set; }
}

public class BasicBlock : BlockBase
{

}