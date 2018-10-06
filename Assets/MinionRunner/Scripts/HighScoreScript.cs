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
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public GameObject score;
    public GameObject scoreName;
    public GameObject rank;

    public void SetScore(string firstName, string lastName, string score, string rank)
    {
        string name1 = firstName + " " + lastName;
        this.score.GetComponent<Text>().text = score;
        this.scoreName.GetComponent<Text>().text = name1;
        this.rank.GetComponent<Text>().text = rank;
    }
}
