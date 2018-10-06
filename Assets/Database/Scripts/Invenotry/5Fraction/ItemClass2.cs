﻿/********************************************************         
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

public class ItemClass2 : MonoBehaviour
{

    //Icons
    /*static public Texture2D Cog16;
    static public Texture2D Cog26;
    static public Texture2D Cog36;
    static public Texture2D Cog46;
    static public Texture2D Cog56;
    static public Texture2D Cog66;*/

    // Items
    public ItemCreatorClass cog15 = new ItemCreatorClass(0, "Part 1/6", null, "Cogwheel fraction 1/6");
    public ItemCreatorClass cog25 = new ItemCreatorClass(1, "Part 2/6", null, "Cogwheel fraction 2/6");
    public ItemCreatorClass cog35 = new ItemCreatorClass(2, "Part 3/6", null, "Cogwheel fraction 3/6");
    public ItemCreatorClass cog45 = new ItemCreatorClass(3, "Part 4/6", null, "Cogwheel fraction 4/6");
    public ItemCreatorClass cog55 = new ItemCreatorClass(4, "Part 5/6", null, "Cogwheel fraction 5/6");


    void Start()
    {
    }
    void Update()
    {
    }

    public class ItemCreatorClass
    {
        public int id;
        public string name;
        public Texture2D icon;
        public string description;

        public ItemCreatorClass(int id1, string name1, Texture2D icon1, string description1)
        {
            id = id1;
            name = name1;
            icon = icon1;
            description = description1;
        }
        public void SetIcon(Texture2D icon1)
        {
            icon = icon1;
        }
    }
}
