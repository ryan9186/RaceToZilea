using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionPanel : MonoBehaviour
{
    public ActionLogic actionLogic;
    public GameHandler gameHandler;

    public string actionState;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public void updateActionPanel()
    {
        actionState = actionLogic.actionState;
    }
    public void button1Click()
    {
        gameHandler.testFunction();
    }
    public void button2Click()
    {
        gameHandler.spawnRover();
    }
    public void button3Click()
    {
        gameHandler.selectedRover.moveRover(gameHandler.selectedTile);
    }
    public void button4Click()
    {
        Debug.Log("Button 4 Clicked in PAP");
        this.gameHandler.playerEndTurn();
    }
}
