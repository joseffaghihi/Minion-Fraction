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

public class InventoryGUI2 : MonoBehaviour
{
    public static bool inventoryToggle = false;
    private Rect inventoryRect = new Rect(300, 100, 422, 240);

    bool usingSlider;

    static public Dictionary<int, Texture2D> InventoryNameDictionary = new Dictionary<int, Texture2D>()
    {
        {0, null},
        {1, null},
        {2, null},
        {3, null},
        {4, null}
    };

        static public List<int> dictonaryAmounts = new List<int>()
    {
        0,
        0,
        0,
        0,
        0
    };

    void start()
    {
        inventoryToggle = false;
        ItemClass itemObject = new ItemClass();
        dictonaryAmounts.Clear();
        InventoryNameDictionary.Clear();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryToggle = !inventoryToggle;
    }

    void OnGUI()
    {
        inventoryToggle = GUI.Toggle(new Rect(50, 30, 150, 75), inventoryToggle, "Inventory");

        if (inventoryToggle)
        {
            inventoryRect = GUI.Window(0, inventoryRect, inventoryMethod, "Inventory");
        }
    }

    void inventoryMethod(int windowId)
    {

        /*/Display at start Dictionary ==> Start Empty
        InventoryNameDictionary[1] = cog16.name;
        InventoryNameDictionary[2] = cog26.name;
        InventoryNameDictionary[3] = cog36.name;
        InventoryNameDictionary[4] = cog46.name;
        InventoryNameDictionary[5] = cog56.name;
        InventoryNameDictionary[6] = cog66.name;*/

        GUILayout.BeginArea(new Rect(5, 50, 440, 440));

        GUILayout.BeginHorizontal();

        if(GUI.Button(new Rect(1, 2, 70, 70), InventoryNameDictionary[0]))
        {
            if (dictonaryAmounts[0] != 0)
            {
                dictonaryAmounts[0] -= 1;
                FractionManager.score -= 1;
            }
            /*if (dictonaryAmounts[0] == 0) // not working. How do I update the button above? Do I want to not show anything or just keep the same icon there all the time?
            {
                itemObject.cog16.SetIcon(null);
                GUI.Button(new Rect(1, 2, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(73, 13, 50, 50), dictonaryAmounts[0].ToString());

        if (GUI.Button(new Rect(145, 2, 70, 70), InventoryNameDictionary[1]))
        {
            if (dictonaryAmounts[1] != 0)
            {
                dictonaryAmounts[1] -= 1;
                FractionManager.score -= 2;
            }
            /*if (dictonaryAmounts[1] == 0) // not working. How do I update the button above? Do I want to not show anything or just keep the same icon there all the time?
            {
                itemObject.cog26.SetIcon(null);
                GUI.Button(new Rect(145, 2, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(217, 13, 50, 50), dictonaryAmounts[1].ToString());

        if(GUI.Button(new Rect(288, 2, 70, 70), InventoryNameDictionary[2]))
        {
            if (dictonaryAmounts[2] != 0)
            {
                dictonaryAmounts[2] -= 1;
                FractionManager.score -= 3;
            }
            /*if (dictonaryAmounts[2] == 0) 
            {
                itemObject.cog36.SetIcon(null);
                GUI.Button(new Rect(288, 2, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(360, 13, 50, 50), dictonaryAmounts[2].ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if(GUI.Button(new Rect(53, 90, 70, 70), InventoryNameDictionary[3]))
        {
            if (dictonaryAmounts[3] != 0)
            {
                dictonaryAmounts[3] -= 1;
                FractionManager.score -= 4;
            }
            /*if (dictonaryAmounts[3] == 0)
            {
                itemObject.cog46.SetIcon(null);
                GUI.Button(new Rect(1, 90, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(125, 103, 50, 50), dictonaryAmounts[3].ToString());

        if(GUI.Button(new Rect(253, 90, 70, 70), InventoryNameDictionary[4]))
        {
            if (dictonaryAmounts[4] != 0)
            {
                dictonaryAmounts[4] -= 1;
                FractionManager.score -= 5;
            }
            /*if (dictonaryAmounts[4] == 0)
            {
                itemObject.cog56.SetIcon(null);
                GUI.Button(new Rect(145, 90, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(325, 103, 50, 50), dictonaryAmounts[4].ToString());

        GUILayout.EndHorizontal();

        GUILayout.EndArea();

    } 

    public static bool InventoryStatus()
    {
        return inventoryToggle;
    }
}
