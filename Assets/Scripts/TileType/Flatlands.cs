using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Flatlands TileType is a resource type
 * Buildable generator is the Barracks variant
*/
public class Flatlands : TileType
{
	public int troops;
	public int mobility = 2;

	// Start is called before the first frame update
	void Awake()
	{
		troops = GenerateResourceAmount();
		this.typeName = "Flatlands";
		this.tileSprite = Resources.Load<Sprite>("FlatlandsSprite");
	}

	// Update is called once per frame
	void Update()
	{

	}
}
