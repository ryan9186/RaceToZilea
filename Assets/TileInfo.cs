using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileInfo : MonoBehaviour
{
    public int mainResource = 1, subResourceType;
    public int mainResourcePoints, subResourcePoints;
    public int xHexPosition, yHexPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        mainResourcePoints = Random.Range(4, 8);
        subResourcePoints = 8 - mainResourcePoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeResourceType(int type)
    {
        mainResource = type;
    }
}
