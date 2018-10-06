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

public class IncreaseGravity : MonoBehaviour {

    private Vector3 top;
    private Vector3 down;
    private Vector3 tmp;
    // Use this for initialization
    public float gravityChangeSpeed;



    void Start()
    {
        top = new Vector3(0, -55, 0);
        Physics.gravity = top;
        down = new Vector3(0, 55, 0);

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GravityChange")
        {
            Physics.gravity = Vector3.Lerp(top, down, gravityChangeSpeed);
            tmp = top;
            top = down;
            down = tmp;

        }
    }

    
}
