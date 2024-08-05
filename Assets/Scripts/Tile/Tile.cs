using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * This file, "Tile.cs" is the script used on the Tile prefab object. 
 * This Tile class represents the "physical" component of the gameboard,
 * such as it's location on the board, player selection functionality, and
 * the Sprite of the tileType that is currently located on a particular Tile piece
 * Most interactions within the game are interfaced through the Tile one way or another.
 * 
 * The TileMapGrid uses this Tile class to generate the board,
 * composed of "Tile Pieces". Within this class exists
 * the functionality for randomly generating and initializing all the board pieces with
 * the different TileTypes i.e. the mountains, craters, etc. 
 * 
 * Pending functionality additions include: a reference to the player who currently
 * controls this specific instance of Tile (a Tile board piece).
 * A reference to any Rover piece on this Tile (a max of one Rover can be on a specific
 * Tile)
 * A list of players that this Tile piece is currently visible too depending on the
 * 'visibility' gameplay mechanic
 */ 
public class Tile : MonoBehaviour
{
    // This Tile piece's Sprite renderer
    public SpriteRenderer tileRenderer;
    // Name of the TileType currently currently located on this Tile piece
    public string currentTileType = null;
    // TileType object currently located on this Tile piece
    public TileType tileType = null;
    
    // Awake called on instantiation
    void Awake()
    {
        initializeTile();
    }
    // Start called before first update
    // updateTile function located in Start() so as to initialize Tile object's
    // variables after tileType instantiation in Awake()
    void Start()
    {
        updateTile();
    }

    // initializeTile function by Tile object to choose itself a random tileType
    // to instantiate during Tile object instantiation. Also instantiates
    // it's own SpriteRenderer component
    public void initializeTile()
    {
        
        tileRenderer = GetComponent<SpriteRenderer>();
        int tileTypeGen = Random.Range(1, 6);

        // if tree that randomly chooses a tileType for this Tile object
        if (tileTypeGen == 1)
        {
            this.tileType = gameObject.AddComponent<Mountain>();
            this.tileType.attachedTo = this;
        }
        else if (tileTypeGen == 2)
        {
            this.tileType = gameObject.AddComponent<Crater>();
            this.tileType.attachedTo = this;
        }
        else if (tileTypeGen == 3)
        {
            this.tileType = gameObject.AddComponent<Ravine>();
            this.tileType.attachedTo = this;
        }
        else if (tileTypeGen == 4)
        {
            this.tileType = gameObject.AddComponent<Fissure>();
            this.tileType.attachedTo = this;
        }
        else if (tileTypeGen == 5)
        {
            this.tileType = gameObject.AddComponent<Flatlands>();
            this.tileType.attachedTo = this;
        }
    }

    //updateTile function is used any time a Tile object's tileType changes, which
    //will mostly take place during gameplay when a player chooses to build a genererator
    //on a resource Tile or when a generator is destroyed during player combat
    public void updateTile()
    {
        tileRenderer.sprite = tileType.getSprite();
        currentTileType = tileType.getTileType();
    }

    // selectTile() used in gameplay for a player to select a Tile piece.
    public void selectTile()
    {
        Debug.Log(this.currentTileType);
    }

    // onMouseDown() to provide input functionality
    private void OnMouseDown()
    {
        Debug.Log(this.currentTileType);
    }
}
