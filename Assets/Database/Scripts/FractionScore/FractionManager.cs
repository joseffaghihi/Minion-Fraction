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

public class FractionManager : MonoBehaviour
{
    public static int score;
    public int denominator; 
    public int StartingCogPart;    
    Text text;                    

    void Awake()
    {
        text = GetComponent<Text>();
        score = StartingCogPart;
    }

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (score == 0)
            text.text = "FRACTION: " + "?/" + denominator;
        else text.text = "FRACTION: " + score + "/" + denominator;
    }

    void setScore(int score1)
    {
        score = score1;
    }
}