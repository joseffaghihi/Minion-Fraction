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

public class DestroyOld : MonoBehaviour {

   /* void OnTriggerEnter(Collider other)
    {
              if(other.tag == "Player")
              {
                  Debug.Break();
              }

              if(other.gameObject.transform.parent)
              {
                  Destroy(other.gameObject.transform.parent.gameObject);
              }
              else
              {
                  Destroy(other.gameObject);
              }
       
    }*/
    void OnCollisionEnter(Collision  other)
    {
        Destroy(other.collider.gameObject);
        Destroy(gameObject);
    }
}
