using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Ravine TileType is a resource type
 * Buildable generator is the O2 Extractor variant
*/
public class Ravine : TileType
{
    public int oxygen;
    public int mobility = 2;
    // Start is called before the first frame update

    void Awake()
    {
        oxygen = GenerateResourceAmount();
        this.typeName = "Ravine";
        this.tileSprite = Resources.Load<Sprite>("RavineSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
