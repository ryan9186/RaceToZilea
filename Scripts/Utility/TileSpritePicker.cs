using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpritePicker : MonoBehaviour
{
    public SpriteRenderer tileRender;
    public Sprite mountainSp;
    public Sprite fissureSp;
    public Sprite ravineSp;
    public Sprite craterSp;
    public Sprite blankSp;

 
    void Start()
    {
        tileRender = this.GetComponent<SpriteRenderer>();
        mountainSp = Resources.Load<Sprite>("MountainSprite");
        fissureSp = Resources.Load<Sprite>("FissureSprite");
        ravineSp = Resources.Load<Sprite>("RavineSprite");
        craterSp = Resources.Load<Sprite>("CraterSprite");
        blankSp = Resources.Load<Sprite>("blankHex");
       // tileRender.sprite = UpdateSprite(Tile.)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Sprite UpdateSprite(string tileType)
    {
        if (tileType == "Mountain")
            return mountainSp;
        else if (tileType == "Fissure")
            return fissureSp;
        else if (tileType == "Ravine")
            return ravineSp;
        else if (tileType == "Crater")
            return craterSp;
        else
        {
            Debug.Log("Error in SpritePicker");
            return null;
        }
    }
}
