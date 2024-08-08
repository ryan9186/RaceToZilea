using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionPanel : MonoBehaviour
{
    public ActionLogic actionLogic;
    public GameHandler gameHandler;

    Vector3 tilePosition;
    Vector3 roverPosition;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;

    private void Start()
    {
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = true ;
        button5.interactable = false;
        button6.interactable = false;
        button7.interactable = false;
        button8.interactable = false;
    }
    private void Update()
    {
        //updateActionPanel();
    }
    public void AttackRover()
    {
        //gameHandler.selectedTile.roverOn.attackRover(gameHandler.selectedRover);
        gameHandler.selectedRover.attackRover(gameHandler.selectedTile.roverOn);
        button6.interactable = false;
        gameHandler.selectedTile = gameHandler.currentPlayer.homeBase;
    }
    public void MoveRover()
    {
        //button2
        gameHandler.selectedRover.moveRover(gameHandler.selectedTile);
        updateActionPanel();
    }
    public void BuildTile()
    {
        ResourceTileType temp = this.gameHandler.selectedTile.tileType as ResourceTileType;
        temp.claimTile(gameHandler.currentPlayer);
    }
    public void EndTurn()
    {
        this.gameHandler.playerEndTurn();
    }

    public void checkRover()
    {
        gameHandler.currentUI.checkInfoPanel.updateCheckInfoPanel(gameHandler.selectedRover);
    }

    public void checkTile()
    {
        gameHandler.currentUI.checkInfoPanel.updateCheckInfoPanel(gameHandler.selectedTile);
    }

    public void fortify()
    {

    }

    public void attackTile()
    {
        ResourceTileType temp = gameHandler.selectedTile.tileType as ResourceTileType;
        temp.attackEnemyTile(gameHandler.selectedRover, gameHandler.selectedTile);
        this.updateActionPanel();

    }

    public void buildRover()
    {

    }

    public void updateActionPanel()
    {
        if (gameHandler.selectedRover != null)
        {
            button7.interactable = true; // checkRover button enabled if selected rover not null
            tilePosition = gameHandler.selectedTile.transform.position;
            roverPosition = gameHandler.selectedRover.transform.position;
            float distance = Vector3.Distance(tilePosition, roverPosition);

            bool tileClose = (distance < 1.5 && distance != 0);
            bool tileCloseOrOn = (distance < 1.5);
            bool tileSafe = (gameHandler.selectedTile.tileOwner == gameHandler.currentPlayer
                || gameHandler.selectedTile.tileOwner == null);
            bool tileEmpty = (gameHandler.selectedTile.roverOn == null);
            bool hasMoves = (gameHandler.selectedRover.moves != 0);
            //bool isPlayersRover = (gameHandler.selectedRover.roverOwner == gameHandler.currentPlayer);
            bool tileEnemyRover = false;
            bool tileOn = (distance == 0);
            bool playerCanBuild = false;

            if (gameHandler.selectedTile.roverOn != null)
            {
                if (gameHandler.selectedTile.roverOn.roverOwner != gameHandler.currentPlayer)
                    tileEnemyRover = true;
            }


            if (tileClose && tileSafe && tileEmpty && hasMoves) // If tile is moveable to
            {
                Debug.Log("Tile Close " + tileClose);
                Debug.Log("Tile Safe " + tileSafe);
                Debug.Log("Tile Empty " + tileEmpty);
                button2.interactable = true;
            }
            else
            {
                Debug.Log("Tile Close " + tileClose);
                Debug.Log("Tile Safe " + tileSafe);
                Debug.Log("Tile Empty " + tileEmpty);
                button2.interactable = false;
            }

            if (tileClose && tileSafe && tileEnemyRover && gameHandler.selectedRover.attacks > 0) // if tile is unowned and has enemy rover
            {
                button5.interactable = true;
            }
            else
            {
                Debug.Log("Tile Close " + tileClose);
                Debug.Log("Tile Safe " + tileSafe);
                Debug.Log("Tile EnemyRover" + tileEnemyRover);
                button5.interactable = false;
            }

            if (tileClose && !tileSafe && gameHandler.selectedRover.attacks > 0) // if tile is enemy owned
            {
                button6.interactable = true;
            }
            else
            {
                button6.interactable= false;
            }

            if (tileCloseOrOn)
            {
                button8.interactable = true;
            }
            else
            {
                button8.interactable= false;
            }
            if (tileOn && gameHandler.selectedTile.tileType is ResourceTileType)
            {
                TileType temp = gameHandler.selectedTile.tileType;
                if(temp is Mountain)
                {
                    Mountain tempCast = (Mountain)temp;
                    playerCanBuild = tempCast.checkCanBuild();
                }
                else if (temp is Crater)
                {
                    Crater tempCast = (Crater)temp;
                    playerCanBuild = tempCast.checkCanBuild();
                }
                else if (temp is Fissure)
                {
                    Fissure tempCast = (Fissure)temp;
                    playerCanBuild = tempCast.checkCanBuild();
                }
                else if (temp is Flatlands)
                {
                    Flatlands tempCast = (Flatlands)temp;
                    playerCanBuild = tempCast.checkCanBuild();
                }
                else if (temp is Ravine)
                {
                    Ravine tempCast = (Ravine)temp;
                    playerCanBuild = tempCast.checkCanBuild();
                }
                button1.interactable = playerCanBuild;
            }
            else
            {
                button1.interactable = false;
            }
        }
        else
        {
            button7.interactable = false; // check rover disabled if selected rover null
        }
    }
}
