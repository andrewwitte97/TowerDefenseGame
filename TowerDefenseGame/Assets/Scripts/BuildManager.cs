using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    //Variable that stores an instance of BuildManager in itself.
    //This ensures that the reference to nodes is one to one, such that
    //one node has one unique BuildManager instance, opposed to being
    //called by all nodes.
	public static BuildManager instance;
	
    //Called before Start()
    //Instantiates the BuildManager
	void Awake()
	{
        //If this instance is null, more than one BuildManager must be operating simultaneously.
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }

		instance = this;
	}

    //The standard turret prefab object
	public GameObject standardTurretPrefab;
	public GameObject missleLauncherPrefab;
	public GameObject buildEffect;
	private GameObject turretToBuild;

    //Can the turret be built?
    //public bool CanBuild { get { return turretToBuild != null; } }
    //Does the player have enough money to build it?
    //public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    //Called when the game starts.
    //Sets the turret to build on the nodes to the Standard turret.
    //TO-DO: Obsolete method by adding another turret
    void Start()
    {
        turretToBuild = standardTurretPrefab;    
    }

    //Returns the turret to build on the node
    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
	
	//public void BuildTurretOn (Node node)
	//{
        //Does the player have enough money to build a turret?
		//if (PlayerStats.Money < turretToBuild.cost)
		//{
		//	Debug.Log("Not enought money to build!");
		//	return;
		//}
		
        //Subtract money from the player's balance
		//PlayerStats.Money -= turretToBuild.cost;
        
		
		//Build a turret
		//GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity); 
       // node.turret = turret;
			
        //Add the building effect
		//GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity); 
       // Destroy(effect, 5f);
			
		//Debug.Log ("Turret build! Money Left: " + PlayerStats.Money);
	//}
	
    //Select which turret to build
	//public void SelectTurretToBuild (TurretBlueprint turret)
	//{
		//turretToBuild = turret;
	//}


}
