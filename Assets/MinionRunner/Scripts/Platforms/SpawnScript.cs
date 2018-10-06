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

public class SpawnScript : MonoBehaviour
{

    public Color32[] MColors;

    public GameObject[] tilePrefabs;
    public GameObject currentTile;

    public int amount;
    private int _mColorCount
    {
        get
        {
            return MColors.Length;
        }
    }

    private static SpawnScript instance;

    private Stack<GameObject> tileEmpty = new Stack<GameObject>();
    public Stack<GameObject> TileEmpty
    {
        get { return tileEmpty; }
        set { tileEmpty = value; }
    }

    public static SpawnScript Instance
    {
        get
        {
            if (instance == null) //Finds the instance if it doesn't exist
            {
                instance = GameObject.FindObjectOfType<SpawnScript>();
            }
            return instance;
        }
    }

    private int i = 0;

    void Start()
    {   
        //Creates 100 tiles
        CreateTiles(1);

        //Spawns 50 tiles when the game starts
        for (int i = 0; i < 50; i++)
        {
            SpawnTile();
        }
    }
 
    public void CreateTiles(int amount)
    {
        for (int b = 0; b < amount; b++)
        {
        
            GameObject Tile = Instantiate<GameObject>(tilePrefabs[0]);
            
            Tile.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Lerp4(MColors[0], MColors[1], MColors[2], MColors[3], b);        
            tileEmpty.Push(Tile);
            tileEmpty.Peek().name = "TileEmpty";
            tileEmpty.Peek().SetActive(false);
        }
    }

    public void SpawnTile()
    {
       
        //If we are out of tiles, then we need to create more
        if (tileEmpty.Count == 0)
        {
            CreateTiles(10);
        }

        

        int randomIndex = Random.Range(0, 1); // for later if tiles in different direction
        if (randomIndex == 0) 
        {
            GameObject tmp = tileEmpty.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(0).position;
            currentTile = tmp;

            i += 1; 
            if (i == 5) // When a fraction should be spawned, ever  y 5 tiles
            {
                int Fraction = Random.Range(0, 3);

                if (Fraction == 0)
                {
                    currentTile.transform.GetChild(1).gameObject.SetActive(true);
                    i = 0;
                }

                else if (Fraction == 1)
                {
                    currentTile.transform.GetChild(2).gameObject.SetActive(true);
                    i = 0;
                }

                else if (Fraction == 2)
                {
                    currentTile.transform.GetChild(3).gameObject.SetActive(true);
                    i = 0;
                }
            }
        }
     }

 /*       else if (randomIndex == 1) //If the random number is one then spawn a top tile
        {
            GameObject tmp = tileFull.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(0).position;
            currentTile = tmp;
        }
*/
     public Color32 Lerp4(Color32 a, Color32 b, Color32 c, Color32 d, float t)
      {
        float r = (float)(_mColorCount - 1);

        if (t <= amount / r)
            return Color.Lerp(a, b, (float)t / r);
        else if (t < amount / r * 1f)
            return Color.Lerp(b, c, (t - amount / r) / 1.5f);
        else
            return Color.Lerp(c, d, (t - amount / r * 1f) / (_mColorCount - 1));
    }

   
            
    }




