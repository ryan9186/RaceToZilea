using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameHandler gameHandler;
    //public SelectedTilePanel stp;
    public string playerName = "Player's Name";
    public List<Tile> tilesOwned = new List<Tile>();
    public int roverCount = 0;
    public Boolean isTurn = false;
    public Boolean isDead = false;
    public Tile selectedTile = null;
    public Tile homeBase = null;

    public int troops = 0;
    public int food = 0;
    public int iron = 0;
    public int lithium = 0;
    public int oxygen = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSelectedTile(Tile selectedTile)
    { 
        this.selectedTile = selectedTile;
    }

    public Sprite getSelectedTileSprite()
    {
        return this.selectedTile.getTileSprite();
    }

    public string getPlayerName()
    {
        return this.playerName;
    }
}
