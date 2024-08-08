using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionLogic : MonoBehaviour
{
    public GameHandler gameHandler;
    public PlayerActionPanel actionPanel;

    public Player currentPlayer;
    public Player selectedTileOwner;
    public Player selectedRoverOwner;
    public Player roverOnSelectedTileOwner;

    public Rover selectedRover;
    public Rover roverOnSelectedTile;

    public Tile selectedTile;
    public Tile selectedRoverTile;

    public TileType selectedTileType;
    //public bool selectedTileIsResource;



    public bool selectedTileOwned;
    public bool selectedTileEnemyOwned;

    public bool selectedRoverOwned;
    public bool selectedRoverEnemyOwned;
    public bool noSelectedRover;

    public bool roverOnSelectedTileIsOwned;
    public bool roverOnSelectedTileIsEnemy;
    public bool selectedTileIsEmpty;

    public bool selectedTileIsResource;
    public bool selectedTileIsHomeBase;



    public string actionState;

    private void Update()
    {
        //checkState();
    }
    public void checkState()
    {
        // Current Player
        this.currentPlayer = gameHandler.getCurrentPlayer();
        // Selected Rover
        this.selectedRover = gameHandler.getSelectedRover();
        // Selected Tile
        this.selectedTile = gameHandler.getSelectedTile();
        // Rover occupying the Selected Tile
        this.roverOnSelectedTile = selectedTile.getRoverOn();
        // Player who owns rover occupying Selected Tile
        this.roverOnSelectedTileOwner = roverOnSelectedTile.getRoverOwner();
        // Tile Type of Selected Tile
        this.selectedTileType = selectedTile.getTileType();
        // Player who owns Selected Tile
        this.selectedTileOwner = selectedTile.getTileOwner();
        // Player who owns Selected Rover
        this.selectedRoverOwner = selectedRover.getRoverOwner();
        // Tile the Selected Rover is on
        this.selectedRoverTile = selectedRover.getTileOn();

        
         selectedTileOwned = (currentPlayer == selectedTileOwner);
         selectedTileEnemyOwned = (currentPlayer != selectedTileOwner && selectedTileOwner != null);

         selectedRoverOwned = (currentPlayer == selectedRoverOwner);
         selectedRoverEnemyOwned = (currentPlayer != selectedRoverOwner);
         noSelectedRover = (selectedRoverOwner == null);

         roverOnSelectedTileIsOwned = (currentPlayer == roverOnSelectedTileOwner);
         roverOnSelectedTileIsEnemy = (currentPlayer != roverOnSelectedTileOwner);
        selectedTileIsEmpty = (roverOnSelectedTile == null);

        
        selectedTileIsHomeBase = (selectedTileType is HomeBase);
        
        //selectedTileIsResource = selectedTile.isResource;
        //Buildable
        //Player Owned rover on Selected Tile, Tile is a Resource Tile
        //Build Generator -> enabled if player has enough resources
        //End Turn
        if (roverOnSelectedTileIsOwned && selectedTileIsResource)
        {
            Debug.Log("Test1");
            actionState = "Buildable";
        }

        else if(selectedTileIsEmpty && selectedRoverOwned)
        {
            actionState = "Movable";
            Debug.Log("Test2");
        }

        else if(selectedRoverOwned && roverOnSelectedTileIsEnemy && selectedTileIsResource)
        {
            actionState = "AttackableRover";
            Debug.Log("Test3");
        }

        else if(selectedRoverOwned && selectedTileEnemyOwned)
        {
            actionState = "AttackableTile";
            Debug.Log("Test4");
        }

        else if(selectedTileIsHomeBase && noSelectedRover)
        {
            actionState = "Homebase";
            Debug.Log("Test5");
        }

        else
        {
            actionState = "NoActions";
            Debug.Log("Test6");
        }

        actionPanel.updateActionPanel();
        /*
        Homebase Tile
Selected Tile is Player owned Homebase Tile
	Build Rover -> enabled if Player has enough resources
	End Turn



        */


    }

}
