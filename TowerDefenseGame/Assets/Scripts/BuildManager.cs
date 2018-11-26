using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	
	void Awake()
	{
		instance = this;
	}

	public GameObject standardTurretPrefab;
	public GameObject missleLauncherPrefab;
	public GameObject buildEffect;
	private TurretBlueprint turretToBuild;

    //Can the turret be built?
	public bool CanBuild { get { return turretToBuild != null; } }
    //Does the player have enough money to build it?
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
	
	
	public void BuildTurretOn (Node node)
	{
        //Does the player have enough money to build a turret?
		if (PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not enought money to build!");
			return;
		}
		
        //Subtract money from the player's balance
		PlayerStats.Money -= turretToBuild.cost;
		
		//Build a turret
		GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity); //, node.GetBuildPosition(), Quaternion.identity
        node.turret = turret;
			
        //Add the building effect
		GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity); //, node.GetBuildPosition(), Quaternion.identity
        Destroy(effect, 5f);
			
		Debug.Log ("Turret build! Money Left: " + PlayerStats.Money);
	}
	
    //Select which turret to build
	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
	}


}
