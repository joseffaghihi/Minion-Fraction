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

public class PlayerDestroy : MonoBehaviour {

    public static PlayerDestroy instance;
    public GameObject HighScore;
    //  public GameObject EnterName;
    public static bool playerDead = false;

	void Update () {
        if (gameObject.transform.position.y <= -30 || gameObject.transform.position.y >= 40)
        {
            playerDead = true;
            HighScore.gameObject.SetActive(true);
     //       EnterName.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
