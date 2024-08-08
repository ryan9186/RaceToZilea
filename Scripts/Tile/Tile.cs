using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
    public GameHandler gameHandler;
    // This Tile piece's Sprite renderer
    public SpriteRenderer tileRenderer;

    // Name of the TileType currently currently located on this Tile piece
    public string currentTileType = null;

    // TileType object currently located on this Tile piece
    public TileType tileType = null;

    public int tileResource;

    public Rover roverOn;
    public Player tileOwner = null;
    public string tileOwnerName = "Unowned";

    public bool isResource;
    
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
        int tileTypeGen = UnityEngine.Random.Range(1, 6);

        Vector3 corner1 = new Vector3(0, 0, 0);
        Vector3 corner2 = new Vector3(4.8f, 0, 0);
        Vector3 corner3 = new Vector3(5.4f, 7.274611f, 0);
        Vector3 corner4 = new Vector4(0.6f, 7.274611f, 0);
        Vector3 thisTileLoc = this.transform.position;

        if (corner1 == thisTileLoc || corner2 == thisTileLoc || corner3 == thisTileLoc || corner4 == thisTileLoc)
        {
            this.tileType = gameObject.AddComponent<HomeBase>();
            this.tileType.attachedTo = this;
            isResource = false;
            gameHandler.homeBaseTiles.Add(this);
        }
        // if tree that randomly chooses a tileType for this Tile object
        else
        {
            if (tileTypeGen == 1)
            {
                this.tileType = gameObject.AddComponent<Mountain>();
                this.tileType.attachedTo = this;
                isResource = true;
            }
            else if (tileTypeGen == 2)
            {
                this.tileType = gameObject.AddComponent<Crater>();
                this.tileType.attachedTo = this;
                isResource = true;
            }
            else if (tileTypeGen == 3)
            {
                this.tileType = gameObject.AddComponent<Ravine>();
                this.tileType.attachedTo = this;
                isResource = true;
            }
            else if (tileTypeGen == 4)
            {
                this.tileType = gameObject.AddComponent<Fissure>();
                this.tileType.attachedTo = this;
                isResource = true;
            }
            else if (tileTypeGen == 5)
            {
                this.tileType = gameObject.AddComponent<Flatlands>();
                this.tileType.attachedTo = this;
                isResource = true;
            }
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


    public TileType getTileType()
    {
        return this.tileType;
    }

    public Rover getRoverOn()
    {
        return this.roverOn;
    }
    // onMouseDown() to provide input functionality
    private void OnMouseDown()
    {
        gameHandler.setSelectedTile(this);
        Debug.Log("Tile Clicked");
    }
    /*
    public void claimTile()
    {
        if (tileType is ResourceTileType)
        {
            ResourceTileType tempRtt = (ResourceTileType)tileType;
            int resourceTemp = tempRtt.getResourceAmount();

            if (this.tileType is Mountain)
            {
                Mountain temp = (Mountain)tileType;
                if (temp.claimTile(gameHandler.currentPlayer) == true)
                {
                    // change this Tile to mines with this mountains iron amount and update
                    Barracks bTemp = (Barracks)tileType;
                    bTemp.resourcesPerTurn = resourceTemp;
                }
                Debug.Log("Not Enough!");
            }
        }
        //... continue if else tree for all resource types
    }
    */
    public Sprite getTileSprite()
    {
        return this.tileType.getSprite();
    }

    public Player getTileOwner() 
    {   
        return this.tileOwner; 
    }

    public void setTileOwner(Player player)
    {
        this.tileOwner = player;
    }

    public string getTileOwnerName()
    {
        return this.tileOwnerName;
    }

    public string GetTileTypeName() 
    {
        return this.tileType.typeName;
    }

    public string getResourceType()
    {
        if (this.tileType is ResourceTileType)
        {
            ResourceTileType temp = (ResourceTileType)this.tileType;
            return temp.getResourceType();
        }
        else if (this.tileType is GeneratorTileType)
        {
            GeneratorTileType temp = (GeneratorTileType)this.tileType;
            return temp.getResourceType();
        }
        else
            return null;
    }

    public int getResourceAmount()
    {
        if (this.tileType is ResourceTileType)
        {
            ResourceTileType temp = (ResourceTileType)this.tileType;
            return temp.getResourceAmount();
        }
        else if (this.tileType is GeneratorTileType)
        {
            GeneratorTileType temp = (GeneratorTileType)this.tileType;
            return temp.getResourceAmount();
        }
        else
            return 0;
    }
}
