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

public class Scoring : MonoBehaviour {

    private static Scoring instance;



    public Text scoreText;
  //  public Text livesText;
    public static int score;
 //   public static int lives;


    void Start () {
        score = 0;
 //       lives = 3;
	}

    void Update()
    {
        scoreText.text = "SCORE: " + score;
 //       livesText.text = "Lives: " + lives;
    }
}
