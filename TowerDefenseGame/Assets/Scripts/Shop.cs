using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{

    //The turrets to select
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    //Buildmanager instance
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected.");
        buildManager.selectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile launcher selected.");
        buildManager.selectTurretToBuild(missileLauncher);
    }

}
