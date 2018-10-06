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

public class InventoryGUI1 : MonoBehaviour
{
    private static bool inventoryToggle = false;
    private Rect inventoryRect = new Rect(300, 100, 280, 240);

    ItemClass1 itemObject = new ItemClass1();

    bool usingSlider;

    static public Dictionary<int, Texture2D> InventoryNameDictionary1 = new Dictionary<int, Texture2D>()
    {
        {0, null},
        {1, null},
        {2, null},
        {3, null}
    };

    static public List<int> dictonaryAmounts1 = new List<int>()
    {
        0,
        0,
        0,
        0
    };

    void start()
    {
        inventoryToggle = false;
       
        dictonaryAmounts1.Clear();
        InventoryNameDictionary1.Clear();
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
        InventoryNameDictionary1[0] = itemObject.cog14.icon;
        InventoryNameDictionary1[1] = itemObject.cog24.icon;
        InventoryNameDictionary1[2] = itemObject.cog34.icon;
        InventoryNameDictionary1[3] = itemObject.cog44.icon;*/
        

        GUILayout.BeginArea(new Rect(5, 50, 440, 440));

        GUILayout.BeginHorizontal();

        if(GUI.Button(new Rect(1, 2, 70, 70), InventoryNameDictionary1[0]))
        {
            if (dictonaryAmounts1[0] != 0)
            {
                dictonaryAmounts1[0] -= 1;
                FractionManager.score -= 1;
            }
            /*if (dictonaryAmounts[0] == 0) // not working. How do I update the button above? Do I want to not show anything or just keep the same icon there all the time?
            {
                itemObject.cog16.SetIcon(null);
                GUI.Button(new Rect(1, 2, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(73, 13, 50, 50), dictonaryAmounts1[0].ToString());

        if (GUI.Button(new Rect(145, 2, 70, 70), InventoryNameDictionary1[1]))
        {
            if (dictonaryAmounts1[1] != 0)
            {
                dictonaryAmounts1[1] -= 1;
                FractionManager.score -= 2;
            }
            /*if (dictonaryAmounts[1] == 0) // not working. How do I update the button above? Do I want to not show anything or just keep the same icon there all the time?
            {
                itemObject.cog26.SetIcon(null);
                GUI.Button(new Rect(145, 2, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(217, 13, 50, 50), dictonaryAmounts1[1].ToString());

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if(GUI.Button(new Rect(1, 90, 70, 70), InventoryNameDictionary1[2]))
        {
            if (dictonaryAmounts1[2] != 0)
            {
                dictonaryAmounts1[2] -= 1;
                FractionManager.score -= 3;
            }
            /*if (dictonaryAmounts[3] == 0)
            {
                itemObject.cog46.SetIcon(null);
                GUI.Button(new Rect(1, 90, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(73, 103, 50, 50), dictonaryAmounts1[2].ToString());

        if(GUI.Button(new Rect(145, 90, 70, 70), InventoryNameDictionary1[3]))
        {
            if (dictonaryAmounts1[3] != 0)
            {
                dictonaryAmounts1[3] -= 1;
                FractionManager.score -= 4;
            }
            /*if (dictonaryAmounts[4] == 0)
            {
                itemObject.cog56.SetIcon(null);
                GUI.Button(new Rect(145, 90, 70, 70), "");
            }*/
        }
        GUI.Box(new Rect(217, 103, 50, 50), dictonaryAmounts1[3].ToString());

       
        GUILayout.EndHorizontal();

        GUILayout.EndArea();

    } 

    public static bool InventoryStatus()
    {
        return inventoryToggle;
    }
}
