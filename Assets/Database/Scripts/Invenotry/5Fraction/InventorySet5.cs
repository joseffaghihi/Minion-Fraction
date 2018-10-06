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

public class InventorySet5 : MonoBehaviour
{

    public Texture2D icon15;
    public Texture2D icon25;
    public Texture2D icon35;
    public Texture2D icon45;
    public Texture2D icon55;


    void Start ()
    {
        InventoryGUI2.InventoryNameDictionary[0] = icon15;
        InventoryGUI2.InventoryNameDictionary[1] = icon25;
        InventoryGUI2.InventoryNameDictionary[2] = icon35;
        InventoryGUI2.InventoryNameDictionary[3] = icon45;
        InventoryGUI2.InventoryNameDictionary[4] = icon55;

        InventoryGUI2.dictonaryAmounts[0] = 0;
        InventoryGUI2.dictonaryAmounts[1] = 0;
        InventoryGUI2.dictonaryAmounts[2] = 0;
        InventoryGUI2.dictonaryAmounts[3] = 0;
        InventoryGUI2.dictonaryAmounts[4] = 0;
    }
}
