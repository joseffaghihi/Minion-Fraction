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

public class GravityDirection : MonoBehaviour
{

    public bool grounded;
    public static bool playergrounded;
    private Vector3 posCur;
    private Quaternion rotCur;
    RaycastHit hit;


    void Update()
    {
       
       
                Ray ray = new Ray(transform.position, -Vector3.up);
                RaycastHit hit;
           //      Debug.DrawLine(transform.position, Vector3.forward, Color.red);
      
                if (Physics.Raycast(ray, out hit,  1.5f) == true)
                {

                    Debug.DrawLine(transform.position, hit.point, Color.green);

                    rotCur = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                    posCur = new Vector3(transform.position.x, hit.point.y, transform.position.z);

                    grounded = true;
                    playergrounded = true;

                }
                else
                {
                    grounded = false;
                    playergrounded = false;
                }


                if (grounded == true)
                {
                    transform.position = Vector3.Lerp(transform.position, posCur, Time.deltaTime * 5);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, Time.deltaTime * 5);
                }
            }
    }
