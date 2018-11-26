﻿using System.Collections;
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
	
	public bool CanBuild { get { return turretToBuild != null; } }

	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
	
	
	public void BuildTurretOn (Node node)
	{
		if (PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not enought money to build!");
			return;
		}
		
		PlayerStats.Money -= turretToBuild.cost;
		
		//build a turret
			GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
			node.turret = turret;
			
			GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
			Destroy(effect, 5f);
			
			Debug.Log ("Turret build! Money Left: " + PlayerStats.Money);
	}
	
	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
	}


}
