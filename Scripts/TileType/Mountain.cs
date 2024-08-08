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
    public int lithiumCost;

    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.ironCost = this.resourceAmt * 2;
        this.lithiumCost = this.resourceAmt * 2;

        this.resourceType = "Iron";
        this.typeName = "Mountain";
        this.tileSprite = Resources.Load<Sprite>("MountainSprite");
    }

    /*
    public bool claimTile(Player player)
    {
        int cost = this.resourceAmt * 2;
        if (player.iron > cost && player.lithium > cost)
        {
            player.iron -= cost;
            player.lithium -= cost;
            return true;
        }
        else
            return false;
    }
    */
    public bool checkCanBuild()
    {
        Player currentPlayer = this.attachedTo.gameHandler.getCurrentPlayer();
        if (currentPlayer.iron >= this.ironCost && currentPlayer.lithium >= this.lithiumCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
