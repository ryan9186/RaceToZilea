using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Fissure TileType is a resource type
 * Buildable generator is the Lithium Elevator variant
*/
public class Fissure : TileType
{
    public int lithium;
    public int mobility = 2;
    // Start is called before the first frame update

    void Awake()
    {
        lithium = GenerateResourceAmount();
        this.typeName = "Fissure";
        this.tileSprite = Resources.Load<Sprite>("FissureSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
