using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Flatlands TileType is a resource type
 * Buildable generator is the Barracks variant
*/
public class Flatlands : ResourceTileType
{
	void Awake()
	{
		this.resourceAmt = GenerateResourceAmount();
		this.resourceType = "Troops";
		this.typeName = "Flatlands";
		this.tileSprite = Resources.Load<Sprite>("FlatlandsSprite");
	}

	// Update is called once per frame
	void Update()
	{

	}
}
