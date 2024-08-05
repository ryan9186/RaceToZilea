using System.Collections;
using System.Collections.Generic;
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
public class TileType : MonoBehaviour
{
    public Tile attachedTo = null;
    public Sprite tileSprite = null;
    public string typeName = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //GenerateResourceAmount() used upon TileType instantiation to randomly
    // generate the amount of resources provided by this tileType
    static protected int GenerateResourceAmount()
    {
        return Random.Range(2, 11);
    }

    public Sprite getSprite()
    {
        return this.tileSprite;
    }

    public string getTileType()
    {
        return this.typeName; 
    }
}
