using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameHandler gameHandler;
    public string playerName = "Player's Name";

    public List<Tile> tilesOwned = new List<Tile>();
    public Tile homeBase = null;

    public List<Rover> roverOwned = new List<Rover>();
    public int roverCount = 0;

    public Boolean isTurn = false;
    public Boolean isDead = false;

    public Tile selectedTile = null;


    public int troops = 0;
    public int troopsPerTurn = 1;

    public int food = 0;
    public int foodPerTurn = 1;

    public int iron = 0;
    public int ironPerTurn = 1;

    public int lithium = 0;
    public int lithiumPerTurn = 1;

    public int oxygen = 0;
    public int oxygenPerTurn = 1;

    
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
