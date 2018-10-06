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

public class LoginStudent : MonoBehaviour
{
    public InputField email;
    public InputField password;

    public string LevelToLoad; // eventually the script will decide where the user left last time he played and load that level -> for now just reference a scene

    public void Login()
    {
        DataBaseManager.notCorrect = false;
        DataBaseManager.notInDB = false;

        if(email.text != "" && password.text != "")
        {
            string e = email.text;
            string p = password.text;

            DataBaseManager.loginStudent(e, p, LevelToLoad);
        }
    }
	
}
