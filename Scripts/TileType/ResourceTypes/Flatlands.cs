using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Flatlands TileType is a resource type
 * Buildable generator is the Barracks variant
*/
public class Flatlands : ResourceTileType
{
	public int ironCost;
	public int foodCost;

	void Awake()
	{
		this.resourceAmt = GenerateResourceAmount();
		this.resourceType = "Troops";
		this.typeName = "Flatlands";
		this.tileSprite = Resources.Load<Sprite>("FlatlandsSprite");
        int buildCostAmt = resourceAmt * 1;
		ironCost = buildCostAmt;
		foodCost = buildCostAmt;
        buildCost = "Cost: " + buildCostAmt + " Iron   " + buildCostAmt + " Food";
    }

    public bool checkCanBuild()
    {
        Player currentPlayer = this.attachedTo.gameHandler.getCurrentPlayer();
        if (currentPlayer.iron >= this.foodCost && currentPlayer.oxygen >= this.ironCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
