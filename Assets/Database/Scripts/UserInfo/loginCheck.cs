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
using UnityEngine.UI;

public class loginCheck : MonoBehaviour {

    public InputField email;
    public InputField password;
   
    public GameObject emailReq;
    public GameObject passReq;

    public void checkLogin()
    {
        /* if (username.text == "")
             Debug.Log("username is empty");
         else
         {
             Debug.Log("username is not empty");
             string name = username.text;
             Debug.Log(name);
         }*/

        if (email.text == "" || password.text == "")
        {         
            emailReq.SetActive(true);
            passReq.SetActive(true);
        }
    }
}
