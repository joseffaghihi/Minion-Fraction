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

public class InventorySet6 : MonoBehaviour
{

    public Texture2D icon16;
    public Texture2D icon26;
    public Texture2D icon36;
    public Texture2D icon46;
    public Texture2D icon56;
    public Texture2D icon66;


    void Start ()
    {
        InventoryGUI.InventoryNameDictionary[0] = icon16;
        InventoryGUI.InventoryNameDictionary[1] = icon26;
        InventoryGUI.InventoryNameDictionary[2] = icon36;
        InventoryGUI.InventoryNameDictionary[3] = icon46;
        InventoryGUI.InventoryNameDictionary[4] = icon56;
        InventoryGUI.InventoryNameDictionary[5] = icon66;

        InventoryGUI.dictonaryAmounts[0] = 0;
        InventoryGUI.dictonaryAmounts[1] = 0;
        InventoryGUI.dictonaryAmounts[2] = 0;
        InventoryGUI.dictonaryAmounts[3] = 0;
        InventoryGUI.dictonaryAmounts[4] = 0;
        InventoryGUI.dictonaryAmounts[5] = 0;
    }
}
