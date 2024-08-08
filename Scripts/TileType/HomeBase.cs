using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : TileType
{
    private void Awake()
    {
        this.tileSprite = Resources.Load<Sprite>("HomeBaseSprite");
        this.typeName = "Home Base";
    }
}
