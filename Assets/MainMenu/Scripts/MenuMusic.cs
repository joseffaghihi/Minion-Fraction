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

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance = null;
    public static MenuMusic Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    } // any other methods you need 

    public void StopMusic()
    {
        Destroy(this.gameObject);
    }
}