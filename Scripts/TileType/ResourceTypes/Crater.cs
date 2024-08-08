using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Flatlands Crater is a resource type
 * Buildable generator is the Fishery variant
*/
public class Crater : ResourceTileType
{
    public int foodCost;
    public int oxygenCost;
    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.resourceType = "Food";
        this.typeName = "Crater";
        this.tileSprite = Resources.Load<Sprite>("CraterSprite");
        int buildCostAmt = resourceAmt * 1;
        foodCost = buildCostAmt;
        oxygenCost = buildCostAmt;
        buildCost = "Cost: " + buildCostAmt + " Food   " + buildCostAmt + " Oxygen";
    }
    public bool checkCanBuild()
    {
        Player currentPlayer = this.attachedTo.gameHandler.getCurrentPlayer();
        if (currentPlayer.iron >= this.foodCost && currentPlayer.oxygen >= this.oxygenCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
