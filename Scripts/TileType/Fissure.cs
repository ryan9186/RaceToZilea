using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Fissure TileType is a resource type
 * Buildable generator is the Lithium Elevator variant
*/
public class Fissure : ResourceTileType
{

    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.resourceType = "Lithium";
        this.typeName = "Fissure";
        this.tileSprite = Resources.Load<Sprite>("FissureSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
