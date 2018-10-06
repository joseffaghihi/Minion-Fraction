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

public class FSsuccessText : MonoBehaviour {

    Text text;
    UserClass user = new UserClass();

    void Awake()
    {
        text = GetComponent<Text>();
        ScoreManager.score = 0;
    }

    void Update()
    {
        text.text = "GOOD JOB, " + UserClass.player.userId + "! LET'S BEGIN THE GAME!";
    }

}
