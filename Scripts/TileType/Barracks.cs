using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Barracks : GeneratorTileType
{
    //ResourcesPerTurn depends on Resource tile that this was built on
    void Awake()
    {
        this.resourceType = "Troops";
        this.tileSprite = Resources.Load<Sprite>("MountainSprite");
    }
}
