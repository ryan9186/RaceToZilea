using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class Rover : MonoBehaviour
{
    public GameHandler gameHandler;
    public Player roverOwner;
    public Tile tileOn;

    public int health = 10;
    public int troops = 5;
    public int moves = 2;
    public int attacks = 2;

    public void spawnRover(GameHandler gameHandler, Player player)
    {
        this.gameHandler = gameHandler;
        this.roverOwner = player;
        this.tileOn = player.homeBase;
        this.tileOn.roverOn = this;
        this.roverOwner.roverCount++;
        roverOwner.roverOwned.Add(this);

        /*
        Tile currentPlayerHomeBase = currentPlayer.homeBase;
        Vector3 homeBaseLoc = currentPlayerHomeBase.transform.position;
        GameObject newRover= Instantiate(roverPrefab, homeBaseLoc, transform.rotation);
        newRover.GetComponent<Rover>().setupRover(this);
        */
    }

    public void moveRover(Tile tile)
    {
        this.tileOn.roverOn = null;
        this.tileOn = tile;
        Vector3 movePosition = gameHandler.selectedTile.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, movePosition, 100);
        tile.roverOn = this;
        this.moves -= 1;
    }

    public void attackRover(Rover enemyRover)
    {
        enemyRover.health -= this.troops;
        this.attacks -= 1;
        if (enemyRover.health <= 0)
        {
            destroyRover(enemyRover);
        }
    }

    public void destroyRover(Rover deadRover)
    {
        this.roverOwner.roverOwned.Remove(deadRover);
        GameObject.Destroy(deadRover.gameObject);
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
        if(this.roverOwner == gameHandler.currentPlayer)
            gameHandler.setSelectedRover(this);
    }
}
