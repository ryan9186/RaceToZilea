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
        this.selectedTileType = selectedTile.GetTileTypeName();
        this.selectedTileResourceType = selectedTile.getResourceType();
        this.selectedTileResourceAmount = selectedTile.getResourceAmount();
        currentUI.updateSelectedTilePanel();
    }

    public Rover getSelectedRover()
    {
        return selectedRover;
    }

    public void testFunction()
    {
        for (int i = 0; i < playersInGame; i++)
        {
            Debug.Log(players[i].name);
            Debug.Log(homeBaseTiles[i].name);
            players[i].homeBase = homeBaseTiles[i];
            homeBaseTiles[i].tileOwner = players[i];
            homeBaseTiles[i].setTileOwner(players[i]);
            homeBaseTiles[i].tileOwnerName = players[i].getPlayerName();
        }
    }

    public void spawnRover()
    {
        //GameObject go = Instantiate(this.Prefab, this.Position, this.Rotation);
        //go.AddComponent<NPC>().Setup(this);
        Tile currentPlayerHomeBase = currentPlayer.homeBase;
        Vector3 homeBaseLoc = currentPlayerHomeBase.transform.position;
        GameObject newRover = Instantiate(roverPrefab, homeBaseLoc, transform.rotation);
        newRover.GetComponent<Rover>().setupRover(this);
    }
}
