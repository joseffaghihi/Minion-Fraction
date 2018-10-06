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

/*
1/2 * 1/2 	2-2
1/2 * 1/3	2-3
1/2 * 1/4 	2-4
1/3 * 1/3   3-3
1/2 * 3/4   2-4
2/3 * 1/4   3-4
2/3 * 3/4   3-4
3/4 * 3/4   4-4


2-2 = 1
2-3 = 2
2-4 = 3
3-3 = 4
3-4 = 5
4-4 = 6
*/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Multiplication : MonoBehaviour {

    public GameObject[] chocolateBars;
    public GameObject SpawnPoint;
    public GameObject bar;


	public void twoTwo()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[0], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
    }
    public void twoThree()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
    }
    public void twoFour()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[2], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
    }
    public void threeThree()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[3], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
    }
    public void threeFour()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[4], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
    }
    public void fourFour()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[5], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
    }

 

}
