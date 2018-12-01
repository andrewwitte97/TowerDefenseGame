using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


/**Node controls the Node prefab. It enables turret placement on nodes,
 * and changes their color on mouse enter and exit.
 */

public class Node : MonoBehaviour {

    //Controls the color that the node changes to when hovered over,
    //as defined in editor
    public Color hoverColor;

    

    //Saves the turret that is currently on the node
    private GameObject turret;

    //Unity renderer object which handles color changing
    private Renderer rend;
    //Stores the initial color of the node
    private Color startColor;

    //initializes rend and stores the starting color of the node
    void Start()
    {
        rend = GetComponent<Renderer>();
        //stores the original color of the object
        startColor = rend.material.color;
    }

    //initializes when mouse clicks on node object
    void OnMouseDown()
    {
        //If there's already a turret on the node
        if (turret != null)
        {
            Debug.Log("Can't build there. - TODO: Display on screen");
            return;
        }

        //Build a turret
        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    //initializes when mouse hovers over node object
    void OnMouseEnter()
    {
        //the color of the object becomes hoverColor
        rend.material.color = hoverColor;

        
    }

    //initializes when mouse leaves the node object
    void OnMouseExit()
    {
        //the color of the object becomes the inital color, startColor
        rend.material.color = startColor;
    }


}