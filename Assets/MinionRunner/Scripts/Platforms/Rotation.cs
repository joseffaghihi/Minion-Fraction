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

public class Rotation : MonoBehaviour
{

    public float rotateRate = 1.0f;
    public float InvokeRate = 1.0f;

    float xRot;

    void Start()
    {
        InvokeRepeating("newRotation", 0.0f, InvokeRate);
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.right, Time.deltaTime*xRot);
    }

    void newRotation()
    {
        xRot = Random.Range(-100, 100);
    }
}
