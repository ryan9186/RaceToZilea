using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


public class GameHandler : MonoBehaviour
{
    public List<Player> players;
    public List<Tile> homeBaseTiles;

    public Player currentPlayer;
    public string currentPlayerName;

    int playersInGame = 4;
    public int playersTurn = 0;
    public int turnCount = 0;

    public Tile selectedTile;
    public Rover selectedRover;

    public string selectedTileType;
    public string selectedTileResourceType;
    public int selectedTileResourceAmount;

    public GameObject roverPrefab;

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

    void Start()
    {
        currentPlayer = players[playersTurn];
        currentPlayer.isTurn = true;
        currentPlayerName = currentPlayer.playerName;
        StartCoroutine(gameInializing());
        selectedTile = currentPlayer.homeBase;
        currentUI.playerActionPanel.updateActionPanel();
    }

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
        for (int i = 0; i < currentPlayer.roverOwned.Count; i++)
        {
            currentPlayer.roverOwned[i].moves = 2;
        }

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
        this.selectedTile = currentPlayer.homeBase;
        if (currentPlayer.roverOwned.Count > 0)
        {
            selectedRover = currentPlayer.roverOwned[0];
        }
        else
        {
            selectedRover = null;
        }
        for(int i = 0; i < currentPlayer.roverOwned.Count; i++)
        {
            currentPlayer.roverOwned[i].attacks = 2;
        }
        currentUI.updateUI();
        currentUI.checkInfoPanel.clearPanel();
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
        this.selectedTileType = selectedTile.GetTileTypeName();
        this.selectedTileResourceType = selectedTile.getResourceType();
        this.selectedTileResourceAmount = selectedTile.getResourceAmount();
        //currentUI.updateSelectedTilePanel();
        currentUI.updateUI();
    }

    public void setSelectedRover (Rover selectedRover)
    {
        this.selectedRover = selectedRover;
    }

    public Rover getSelectedRover()
    {
        return selectedRover;
    }

    public void setupGame()
    {
        for (int i = 0; i < playersInGame; i++)
        {
            Debug.Log(players[i].name);
            Debug.Log(homeBaseTiles[i].name);
            players[i].homeBase = homeBaseTiles[i];
            homeBaseTiles[i].tileOwner = players[i];
            homeBaseTiles[i].setTileOwner(players[i]);
            homeBaseTiles[i].tileOwnerName = players[i].getPlayerName();
            Vector3 homeBaseLoc = homeBaseTiles[i].transform.position;
            GameObject newRover = Instantiate(roverPrefab, homeBaseLoc, transform.rotation);
            newRover.GetComponent<Rover>().spawnRover(this, players[i]);
            selectedTile = currentPlayer.homeBase;
            selectedRover = currentPlayer.roverOwned[0];
        }
    }

    public void spawnRover()
    {
        Tile currentPlayerHomeBase = currentPlayer.homeBase;
        Vector3 homeBaseLoc = currentPlayerHomeBase.transform.position;
        GameObject newRover = Instantiate(roverPrefab, homeBaseLoc, transform.rotation);
        newRover.GetComponent<Rover>().spawnRover(this, currentPlayer);
    }


    IEnumerator gameInializing()
    {
        yield return new WaitForSeconds(0.1f);
        setupGame();
    }
}
