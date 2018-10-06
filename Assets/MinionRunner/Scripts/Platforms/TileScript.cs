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

public class TileScript : MonoBehaviour {

    /// <summary>
    /// The time in seconds that it takes for the tile to start falling
    /// </summary>
    private float fallDealy = 1.5f;
 
    
    /// <summary>
    /// When an objects exit's the tile
    /// </summary>
    /// <param name="other"></param>
    /// 
   
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Scoring.score++;
            //Spawns a new tile
            SpawnScript.Instance.SpawnTile();

            //Makes the tile start falling
            StartCoroutine(FallDown());
        }
    }

    /// <summary>
    /// Makes the tile start falling to the ground
    /// </summary>
    IEnumerator FallDown()
    {
        //Waits a fixed amount of seconds before falling
        yield return new WaitForSeconds(fallDealy);

        //Sets makes the tile fall
       GetComponent<Rigidbody>().isKinematic = true;

        //Waits 2 seconds 
        yield return new WaitForSeconds(2);

        //Moves the tile back to the correct stack, so that we can recycle it
        switch (gameObject.name)
        {
            case "TileEmpty":
                SpawnScript.Instance.TileEmpty.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
        }


    }
}