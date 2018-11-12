using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour {
	
	public Color hoverColor;
	public Vector3 positionOffset;
	
	private GameObject turret;
	
	BuildManager buildManager;
	
	private Renderer rend;
	private Color startColor;
	
	void Start  ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		
		buildManager = BuildManager.instance;
	}
	
	void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject())
			return;
		
		
			if (buildManager.GetTurretToBuild() == null)
				return;
		
			if(turret != null)
			{
				
			}
			
			//build a turret
			GameObject turretToBuild = buildManager.GetTurretToBuild();
			turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
			
	}
	
	void OnMouseEnter()
	{
		if(EventSystem.current.IsPointerOverGameObject())
			return;
		
		
		if (buildManager.GetTurretToBuild() == null)
				return;
			
			
		rend.material.color = hoverColor;
		
	}
	
	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
	
}
