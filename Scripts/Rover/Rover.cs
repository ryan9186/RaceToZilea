using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Rover : MonoBehaviour
{
    public GameHandler gameHandler;
    public Player roverOwner;
    public Tile tileOn;

    public int health = 10;
    public int troops = 5;

    public void setupRover(GameHandler gameHandler)
    {
        this.gameHandler = gameHandler;
        this.roverOwner = gameHandler.currentPlayer;
        this.tileOn = roverOwner.homeBase;
        roverOwner.roverCount++;
        roverOwner.roverOwned.Add(this);
        tileOn.roverOn = this;
    }

    public void moveRover(Tile tile)
    {
        transform.position = Vector3.MoveTowards(transform.position, tile.transform.position, 100);
    }

    public Player getRoverOwner()
    {
        return roverOwner;
    }

    public Tile getTileOn()
    {
        return tileOn;
    }
    public void OnMouseDown()
    {
        gameHandler.selectedRover = this;
    }
}
