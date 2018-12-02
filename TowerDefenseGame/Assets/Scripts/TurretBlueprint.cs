using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity will save and load values in this class for us,
//which makes them visible in inspector.
[System.Serializable]

//Saves values for use with selecting the turrets in the shop
public class TurretBlueprint {

	public GameObject prefab;
	public int cost;
	
}
