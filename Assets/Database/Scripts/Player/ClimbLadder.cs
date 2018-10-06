/********************************************************         
 *       Scripted and Designed for MinionRunner         *   
 *                                                      *   
 *       Authors:  Christoph Drechsler                  *
 *                 Dean Dumitru                         *
 *                                                      *
 *       Contact: drechslerc@uindy.edu                  *
 *                dumitrud@uindy.edu                    *   
 *                                                      *   
 *                                                      *   
 *               All Rights Reserved.                   *   
 *                                                      *   
 ********************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClimbLadder : MonoBehaviour {

    public GameObject Player;
    public bool inside = false;
    public float heightFactor;

	
	void Start ()
    {
	}
	
	void Update ()
    {
        if (inside == true && Input.GetKey("space"))
        {
            Player.transform.position += Vector3.up / heightFactor;
        }
    }

    void OnTriggerEnter(Collider ladder)
    {
        if (ladder.gameObject.tag == "Ladder")
        {
            //PlayerMovement.setActive = false;
            inside = !inside;
        }
    }
    void OnTriggerExit(Collider ladder)
    {
        if (ladder.gameObject.tag == "Ladder")
        {
            //PlayerMovement.setActive = true;
            inside = !inside;
        }
    }
}
