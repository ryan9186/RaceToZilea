using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Mountain TileType is a resource type
 * Buildable generator is the Mine variant
*/
public class Mountain : ResourceTileType
{

    void Awake()
    {
        this.resourceAmt = GenerateResourceAmount();
        this.resourceType = "Iron";
        this.typeName = "Mountain";
        this.tileSprite = Resources.Load<Sprite>("MountainSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
