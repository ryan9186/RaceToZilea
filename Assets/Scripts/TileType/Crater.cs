using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Flatlands Crater is a resource type
 * Buildable generator is the Fishery variant
*/
public class Crater : ResourceTileType
{
    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.resourceType = "Food";
        this.typeName = "Crater";
        this.tileSprite = Resources.Load<Sprite>("CraterSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
