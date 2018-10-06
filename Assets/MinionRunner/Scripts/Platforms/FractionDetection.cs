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

public class FractionDetection : MonoBehaviour {

    public Transform Player;
    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fraction2")
        {
            Debug.Log("HitFraction2 show me");
        }
        else if (other.tag == "Fraction3")
        {
            Debug.Log("Hit Fraction 3 show me");
        }
        else if (other.tag == "Fraction4")
        {
            Debug.Log("Hit Fraction 3 show me");
        }
    }

        void Update() {
        if (Player)
        {
            transform.position = new Vector3(Player.transform.position.x, 0, 0);
        }
        else
        {
            transform.position = transform.position;
        }
    }

}
