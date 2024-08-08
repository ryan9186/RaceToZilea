using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Mountain TileType is a resource type
 * Buildable generator is the Mine variant
*/
public class Mountain : ResourceTileType
{
    public int ironCost;
    public int oxygenCost;

    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.resourceType = "Iron";
        this.typeName = "Mountain";
        this.tileSprite = Resources.Load<Sprite>("MountainSprite");
        int buildCostAmt = resourceAmt * 1;
        ironCost = buildCostAmt;
        oxygenCost = buildCostAmt;
        buildCost = "Cost: " + buildCostAmt + " Iron   " + buildCostAmt + " Oxygen";
    }

    public bool checkCanBuild()
    {
        Player currentPlayer = this.attachedTo.gameHandler.getCurrentPlayer();
        if (currentPlayer.iron >= this.ironCost && currentPlayer.oxygen >= this.oxygenCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
