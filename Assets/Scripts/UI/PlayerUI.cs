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
    public string playerShowingName;

    public Tile selectedTile;
    public Sprite selectedTileSprite;

    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //playerShowing = gameHandler.currentPlayer;
        //playerShowingName = playerShowing.playerName;

    }

    public void updateUI()
    {

    }

    public void updateSelectedTilePanel()
    {
        selectedTile = gameHandler.getSelectedTile();
        selectedTileSprite = selectedTile.getTileSprite();
        selectedTilePanel.tileOwnerField.SetText(selectedTile.getTileOwnerName());// change to owned player
        selectedTilePanel.stu.selectedTileImage.GetComponent<Image>().sprite = gameHandler.getSelectedTileSprite();
    }
}
