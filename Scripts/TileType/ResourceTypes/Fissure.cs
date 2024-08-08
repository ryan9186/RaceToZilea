using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Fissure TileType is a resource type
 * Buildable generator is the Lithium Elevator variant
*/
public class Fissure : ResourceTileType
{
    public int lithiumCost;
    public int ironCost;
    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.resourceType = "Lithium";
        this.typeName = "Fissure";
        this.tileSprite = Resources.Load<Sprite>("FissureSprite");
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
