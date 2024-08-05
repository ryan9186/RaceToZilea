using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Mountain TileType is a resource type
 * Buildable generator is the Mine variant
*/
public class Mountain : TileType
{
    public int iron;
    public int mobility = 2;
    // Start is called before the first frame update

    void Awake()
    {
        iron = GenerateResourceAmount();
        this.typeName = "Mountain";
        this.tileSprite = Resources.Load<Sprite>("MountainSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
