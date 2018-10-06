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
using UnityEngine.UI;
using System.Collections;

public class Pickup : MonoBehaviour {

    public Text pickup;
    private int countPickup;
    

    void Start () {
        countPickup = 0;
        pickup = GameObject.Find("Score").GetComponent<Text>();
	}
	
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            countPickup += 1;
            SetCountPickup();
        }
    }

    

    void SetCountPickup()
    {
        pickup.text = "Bonus \nPoints: " + countPickup.ToString() + "/4";
    }
}
