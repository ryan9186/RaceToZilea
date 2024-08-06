using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/* TileMapGrid is responsible for generating the Board by instantiating the board
 * pieces 'Tile Pieces' from Tile prefab objects
 * Indexed each instantiated Tile object with a coordinate representing its location
 * within the board
 * 
 * */
public class TileMapGrid : MonoBehaviour
{
    public GameObject BoardTile;
    //public GameObject HexGridPoint;
    List<List<GameObject>> hexGridSystem;

    List<List<char>> templateGridSystem;

    int mapHeight = 4, mapWidth = 10;
    float scale = 0.6f, height, width;
    

    void Start()
    {
        height = (3 * 1.1547f) * scale;
        width = (2 * 1f) * scale; 
        hexGridSystem = new List<List<GameObject>>();
        for (int x = 0; x < mapWidth; x++)
        {
            hexGridSystem.Add(new List<GameObject>()); 
        }
        templateGridSystem = new List<List<char>>();

        for (int x = 0; x < mapWidth; x++)
        {
            templateGridSystem.Add(new List<char>());
            for (int y = 0; y < mapHeight; y++)
            {
                templateGridSystem[x].Add('v'); // 'v' is for a temperary variable.
            }
        }


        
        createHexGridSystem();

        //hexGridSystem[0][0].GetComponent<TileInfo>().changeResourceType(3);
        
        
        
    }

    void createHexGridSystem()
    {
        float tempX = 0;
        float tempY = 0;
        
        
        for (int x = 0; x < mapWidth; x += 2)                                                             
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3 tilePosition = new Vector3(tempX, tempY, 0);
                hexGridSystem[x].Add(Instantiate(selectTileType(), tilePosition, transform.rotation));
                hexGridSystem[x][y].name = "Tile(" + x + "," + y + ")";
                tempY += height;
            }
            tempY = 0;
            tempX += width;
        }
        tempX = width / 2;
        tempY = height / 2;
        for (int x = 1; x < mapWidth; x += 2)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3 tilePosition = new Vector3(tempX, tempY, 0);
                hexGridSystem[x].Add(Instantiate(selectTileType(), tilePosition, transform.rotation));
                hexGridSystem[x][y].name = "Tile(" + x + "," + y + ")";
                tempY += height;
            }
            tempY = height / 2;
            tempX += width;
        }

    }
    GameObject selectTileType()
    {   
        return BoardTile;
    } 

    private void populateTemplateHexGrid()
    {
        for (int x = 0; x < mapWidth; x++)
        {

        }


    }       
    
}

public class CheckMap
{

}





