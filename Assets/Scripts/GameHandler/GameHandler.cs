using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


public class GameHandler : MonoBehaviour
{
    public List<Player> players;
    public Player currentPlayer;
    public string currentPlayerName;

    int playersInGame = 4;
    public int playersTurn = 0;
    public int turnCount = 0;

    public Tile selectedTile;
    public PlayerUI currentUI;


    private void Awake()
    {
        players = new List<Player>();
        //players = new List<GameObject>();
        for (int i = 0; i < playersInGame; i++)
        {
            players.Add(gameObject.AddComponent<Player>());
            players[i].gameHandler = this;

            {
                if (i == 0)
                {
                    players[i].playerName = "Tristan";
                }
                else if (i == 1)
                    players[i].playerName = "Ryan";
                else if (i == 2)
                    players[i].playerName = "Silas";
                else if (i == 3)
                    players[i].playerName = "Sean";
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = players[playersTurn];
        currentPlayer.isTurn = true;
        currentPlayerName = currentPlayer.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Player getCurrentPlayer()
    {
        return currentPlayer; 
    }

    public void playerEndTurn()
    {
        Debug.Log("PlayerEndTurn");
        currentPlayer.isTurn = false;
        turnCount++;
        nextTurn();
    }

    public void nextTurn()
    {
        playersTurn = turnCount % playersInGame;
        while (players[playersTurn].isDead)
            playersTurn++;
        currentPlayer = players[playersTurn];
        currentPlayer.isTurn = true;
        currentPlayerName = currentPlayer.getPlayerName();
    }


    public Sprite getSelectedTileSprite()
    {
            return selectedTile.getTileSprite();
    }

    public Tile getSelectedTile()
    {
        return selectedTile; 
    }

    public void setSelectedTile (Tile selectedTile)
    {
        this.selectedTile = selectedTile;
        currentUI.updateSelectedTilePanel();
    }
}
