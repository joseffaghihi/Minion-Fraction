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

public class BulletScript : MonoBehaviour {

    public GameObject ps;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Basket")
        {
            Instantiate(ps, transform.position, Quaternion.identity);
        }
    }

}
