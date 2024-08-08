using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckInfoPanel : MonoBehaviour
{
    public GameHandler gameHandler;
    public TextMeshProUGUI field1;
    public TextMeshProUGUI field2;
    public TextMeshProUGUI field3;
    public TextMeshProUGUI field4;

    public void updateCheckInfoPanel(Rover selectedRover)
    {
        if (selectedRover == null)
        {
            field1.text = string.Empty;
            field2.text = string.Empty;
            field3.text = string.Empty;
            field4.text = string.Empty;
        }

        field1.text = selectedRover.roverOwner.playerName + "'s Rover";
        field2.text = "Moves Remaining: " + selectedRover.moves;
        field3.text = "Health Remaining: " + selectedRover.health;
        field4.text = "Troops On Board: " + selectedRover.troops;
    }

    public void updateCheckInfoPanel(Tile selectedTile)
    {
        field1.text = selectedTile.tileOwnerName + "'s " + selectedTile.currentTileType;
        if(selectedTile.tileType is ResourceTileType)
        {
            ResourceTileType temp = selectedTile.tileType as ResourceTileType;
            field2.text = "Resource Type: " + temp.resourceType;
            field3.text = "Resource Per Turn: " + temp.resourceAmt;
            field4.text = temp.buildCost;
        }
    }

    public void clearPanel()
    {
        field1.text = string.Empty;
        field2.text = string.Empty;
        field3.text = string.Empty;
        field4.text = string.Empty;
    }
}
