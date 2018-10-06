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

public class detectSprint : MonoBehaviour
{
    public GameObject TextToHide;
    public GameObject[] ColletToShow;
    public GameObject Player;
    Rigidbody rig;


    // Use this for initialization
    void Start()
    {
        rig = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            TextToHide.SetActive(false);

            foreach (GameObject i in ColletToShow)
                i.SetActive(true);
        }
    }
}