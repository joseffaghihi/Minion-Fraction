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

public class detectInvetoryToggle : MonoBehaviour
{
    public GameObject oldText;
    public GameObject newText;

    InventoryGUI1 inv;
    // Update is called once per frame
    void Update()
    {
        if (InventoryGUI1.InventoryStatus() == true || Input.GetKeyDown(KeyCode.I))
        {
            oldText.SetActive(false);
            newText.SetActive(true);
        }
	}
}
