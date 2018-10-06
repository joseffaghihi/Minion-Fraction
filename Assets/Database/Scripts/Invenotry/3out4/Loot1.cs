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

public class Loot1 : MonoBehaviour {

    public Texture2D i1;
    public int fractionValue;
    public GameObject target;
    public GameObject text;
    public AudioClip pick;

    public GameObject CollectIcon;
    public GameObject CollectText;

    ItemClass1 itemObject = new ItemClass1();

    private Ray mouseRay;
    private RaycastHit rayHit;

    public Texture2D icon14;
    public Texture2D icon24;
    public Texture2D icon34;
    public Texture2D icon44;

    /*private Dictionary<int, string> lootDictionary = new Dictionary<int, string>()
    {
        {1, null}
    };*/

    void Start ()
    {
        InventoryGUI1.InventoryNameDictionary1[0] = icon14;
        InventoryGUI1.InventoryNameDictionary1[1] = icon24;
        InventoryGUI1.InventoryNameDictionary1[2] = icon34;
        InventoryGUI1.InventoryNameDictionary1[3] = icon44;
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
                itemObject.cog14.SetIcon(i1);
                InventoryGUI1.InventoryNameDictionary1[0] = itemObject.cog14.icon;
                InventoryGUI1.dictonaryAmounts1[0] += 1;
            }

            else if (fractionValue == 2)
            {
                itemObject.cog24.SetIcon(i1);
                InventoryGUI1.InventoryNameDictionary1[1] = itemObject.cog24.icon;
                InventoryGUI1.dictonaryAmounts1[1] += 1;
            }

            else if (fractionValue == 3)
            {
                itemObject.cog34.SetIcon(i1);
                InventoryGUI1.InventoryNameDictionary1[2] = itemObject.cog34.icon;
                InventoryGUI1.dictonaryAmounts1[2] += 1;
            }

            else if (fractionValue == 4)
            {
                itemObject.cog44.SetIcon(i1);
                InventoryGUI1.InventoryNameDictionary1[3] = itemObject.cog44.icon;
                InventoryGUI1.dictonaryAmounts1[3] += 1;
            }

            /////////////////////////
        }
    }

}
