using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/* TileType represents the gameplay aspects and logic for each Tile piece,
 * such as resource generation and combat mechanics
 * 
 * Parent class to all TileTypes
 * Contains variables for all values and object references shared
 * by all TileTypes
 * 
 * Pending changes include: further abstraction from this class for the three 
 * TileType categories
 * Generalizing variables from child TileType classes to this class
 * 
 * TileTypes include three categories (Homebase, Resource, Generator)
*/
public class ResourceTileType : TileType
{
    public int mobility = 2;
    public int resourceAmt;
    public int health;
    public string resourceType = null;
    public string buildCost;

    void Awake()
    {
        resourceAmt = GenerateResourceAmount();
        this.attachedTo.tileResource = resourceAmt;
        //this.tileSprite = Resources.Load<Sprite>("FlatlandsSprite");
    }

    //GenerateResourceAmount() used upon TileType instantiation to randomly
    // generate the amount of resources provided by this tileType
    static protected int GenerateResourceAmount()
    {
        return UnityEngine.Random.Range(2, 11);
    }

    public int getResourceAmount()
    {
        return resourceAmt; 
    }

    public string getResourceType()
    {
        return resourceType;
    }
    
    public void claimTile(Player player)
    {
        this.attachedTo.setTileOwner(player);
        player.tilesOwned.Add(this.attachedTo);
        this.attachedTo.tileOwnerName = player.playerName;
        this.health = 20;
        if (this is Mountain)
        {
            player.ironPerTurn += this.resourceAmt;
            this.typeName = "Mines";
            this.tileSprite = Resources.Load<Sprite>("FissureSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;
        }
        else if (this is Crater)
        {
            player.foodPerTurn += this.resourceAmt;
            this.typeName = "Fishery";
            this.tileSprite = Resources.Load<Sprite>("FissureSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;

        }
        else if (this is Fissure)
        {
            player.lithiumPerTurn += this.resourceAmt;
            this.typeName = "Lithium Elevator";
            this.tileSprite = Resources.Load<Sprite>("FissureSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;


        }
        else if (this is Flatlands)
        {
            player.troopsPerTurn += this.resourceAmt;
            this.typeName = "Barracks";
            this.tileSprite = Resources.Load<Sprite>("FissureSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;


        }
        else if (this is Ravine)
        {
            player.oxygenPerTurn += this.resourceAmt;
            this.typeName = "Oxygen Extractor";
            this.tileSprite = Resources.Load<Sprite>("FissureSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;
        }
    }

    public void attackEnemyTile(Rover playerRover, Tile enemyTile)
    {
        ResourceTileType temp = enemyTile.tileType as ResourceTileType;
        temp.health -= playerRover.troops;
        playerRover.attacks -= 1;
        if (temp.health <= 0)
        {
            temp.destroyGenerator();
        }
    }

    public void destroyGenerator()
    {
        Player tempPlayer = this.attachedTo.tileOwner;
        this.attachedTo.tileOwner.tilesOwned.Remove(this.attachedTo);
        this.attachedTo.setTileOwner(null);
        this.attachedTo.tileOwnerName = "Unowned";
        if (this is Mountain)
        {
            tempPlayer.ironPerTurn -= this.resourceAmt;
            this.typeName = "Mountain";
            this.tileSprite = Resources.Load<Sprite>("MountainSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;
        }
        else if (this is Crater)
        {
            tempPlayer.foodPerTurn += this.resourceAmt;
            this.typeName = "Crater";
            this.tileSprite = Resources.Load<Sprite>("CraterSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;

        }
        else if (this is Fissure)
        {
            tempPlayer.lithiumPerTurn += this.resourceAmt;
            this.typeName = "Fissure";
            this.tileSprite = Resources.Load<Sprite>("FissureSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;
        }
        else if (this is Flatlands)
        {
            tempPlayer.troopsPerTurn += this.resourceAmt;
            this.typeName = "Flatlands";
            this.tileSprite = Resources.Load<Sprite>("FlatlandsSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;
        }
        else if (this is Ravine)
        {
            tempPlayer.oxygenPerTurn += this.resourceAmt;
            this.typeName = "Ravine";
            this.tileSprite = Resources.Load<Sprite>("RavineSprite");
            this.attachedTo.tileRenderer.sprite = this.tileSprite;
        }
    }
}
