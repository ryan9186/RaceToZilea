using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Flatlands Crater is a resource type
 * Buildable generator is the Fishery variant
*/
public class Crater : TileType
{
    public int food;
    public int mobility = 2;
    // Start is called before the first frame update

    void Awake()
    {
        food = GenerateResourceAmount();
        this.typeName = "Crater";
        this.tileSprite = Resources.Load<Sprite>("CraterSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
