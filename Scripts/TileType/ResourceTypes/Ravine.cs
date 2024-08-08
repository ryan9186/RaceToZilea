using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Ravine TileType is a resource type
 * Buildable generator is the O2 Extractor variant
*/
public class Ravine : ResourceTileType
{
    public int lithiumCost;
    public int ironCost;

    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.resourceType = "Oxygen";
        this.typeName = "Ravine";
        this.tileSprite = Resources.Load<Sprite>("RavineSprite");
        int buildCostAmt = resourceAmt * 1;
        lithiumCost = buildCostAmt;
        ironCost = buildCostAmt;
        buildCost = "Cost: " + buildCostAmt + " Lithium   " + buildCostAmt + " Iron";
    }

    public bool checkCanBuild()
    {
        Player currentPlayer = this.attachedTo.gameHandler.getCurrentPlayer();
        if (currentPlayer.iron >= this.lithiumCost && currentPlayer.oxygen >= this.ironCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
