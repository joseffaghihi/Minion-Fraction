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

public class Loot2 : MonoBehaviour {

    public Texture2D i1;
    public int fractionValue;
    public GameObject target;
    public GameObject text;
    public AudioClip pick;

    ItemClass2 itemObject = new ItemClass2();

    private Ray mouseRay;
    private RaycastHit rayHit;

    /*private Dictionary<int, string> lootDictionary = new Dictionary<int, string>()
    {
        {1, null}
    };*/
	
	void Start ()
    {
        
	}

	void Update ()
    {
        /*mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetButtonDown("Fire1"))
        {
            Physics.Raycast(mouseRay, out rayHit, 10);
            if (rayHit.collider.transform.tag == "PickUp")
            {
                //la fel ca mai sus ca sa le adaug la mine in inventory
                /////////////////////////
                InventoryGUI.InventoryNameDictionary[1] = itemObject.cog16.name;
                InventoryGUI.dictonaryAmounts[0] += 1;
                /////////////////////////

                FractionManager.score += fractionValue;
                target.SetActive(false);
            }
        }*/
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FractionManager.score += fractionValue;
            target.SetActive(false);
            text.SetActive(true);
            AudioSource.PlayClipAtPoint(pick, target.transform.position);

            //la fel ca mai sus ca sa le adaug la mine in inventory
            /////////////////////////
            if (fractionValue == 1)
            {
                itemObject.cog15.SetIcon(i1);
                InventoryGUI2.InventoryNameDictionary[0] = itemObject.cog15.icon;
                InventoryGUI2.dictonaryAmounts[0] += 1;
            }

            else if (fractionValue == 2)
            {
                itemObject.cog25.SetIcon(i1);
                InventoryGUI2.InventoryNameDictionary[1] = itemObject.cog25.icon;
                InventoryGUI2.dictonaryAmounts[1] += 1;
            }

            else if (fractionValue == 3)
            {
                itemObject.cog35.SetIcon(i1);
                InventoryGUI2.InventoryNameDictionary[2] = itemObject.cog35.icon;
                InventoryGUI2.dictonaryAmounts[2] += 1;
            }

            else if (fractionValue == 4)
            {
                itemObject.cog45.SetIcon(i1);
                InventoryGUI2.InventoryNameDictionary[3] = itemObject.cog45.icon;
                InventoryGUI2.dictonaryAmounts[3] += 1;
            }

            else if (fractionValue == 5)
            {
                itemObject.cog55.SetIcon(i1);
                InventoryGUI2.InventoryNameDictionary[4] = itemObject.cog55.icon;
                InventoryGUI2.dictonaryAmounts[4] += 1;
            }

            /////////////////////////
        }
    }

}
