using System.Collections;
using System.Collections.Generic;
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
    public string resourceType = null;

    void Awake()
    {
        resourceAmt = GenerateResourceAmount();
        this.tileSprite = Resources.Load<Sprite>("FlatlandsSprite");
    }

    //GenerateResourceAmount() used upon TileType instantiation to randomly
    // generate the amount of resources provided by this tileType
    static protected int GenerateResourceAmount()
    {
        return Random.Range(2, 11);
    }

    public int getResourceAmount()
    {
        return resourceAmt; 
    }

    public string getResourceType()
    {
        return resourceType;
    }
}
