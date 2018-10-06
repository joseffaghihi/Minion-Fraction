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

public class PlayerFollow : MonoBehaviour
{

    public Transform Player;

    void Update()
    {
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
