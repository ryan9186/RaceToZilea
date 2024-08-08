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
public class GeneratorTileType : TileType
{
    public int mobility = 3;
    public int health = 20;

    public int resourcesPerTurn;
    public string resourceType = null;

    void Awake()
    {

    }

    public int getResourceAmount()
    {
        return resourcesPerTurn;
    }

    public string getResourceType()
    {
        return resourceType;
    }
}
