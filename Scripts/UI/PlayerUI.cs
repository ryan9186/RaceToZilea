using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Player playerShowing;
    public GameHandler gameHandler;
    public SelectedTilePanel selectedTilePanel;
    public PlayerActionPanel playerActionPanel;
    public CheckInfoPanel checkInfoPanel;
    public string playerShowingName;

    public Tile selectedTile;
    public Sprite selectedTileSprite;

    public void updateUI()
    {
        updateSelectedTilePanel();
        playerActionPanel.updateActionPanel();
    }

    public void updateSelectedTilePanel()
    {
        selectedTile = gameHandler.getSelectedTile();
        selectedTileSprite = selectedTile.getTileSprite();
        selectedTilePanel.tileOwnerField.SetText(selectedTile.getTileOwnerName());
        selectedTilePanel.stu.selectedTileImage.GetComponent<Image>().sprite = gameHandler.getSelectedTileSprite();
    }
}
