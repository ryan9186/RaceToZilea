using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Ravine TileType is a resource type
 * Buildable generator is the O2 Extractor variant
*/
public class Ravine : ResourceTileType
{

    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.resourceType = "Oxygen";
        this.typeName = "Ravine";
        this.tileSprite = Resources.Load<Sprite>("RavineSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
