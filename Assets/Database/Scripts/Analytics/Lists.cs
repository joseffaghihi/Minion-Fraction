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
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Lists : MonoBehaviour {

    static public List<string> username = new List<string>(); // list for usernames
   
    static public List<string> problem = new List<string>(); // list for level name

    static public List<bool> success = new List<bool>(); // list for success/fail (true/false)

    static public List<int> score = new List<int>(); // list for scores

    static public List<string> hintID = new List<string>(); // list for hints

    void Start () {
	
	}
	
	
	void Update () {
	
	}
}
