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

public class RegisterStudent : MonoBehaviour
{
    public InputField email;
    public InputField password;
    public InputField username;
    public InputField firstName;
    public InputField lastName;

    public string FirstLevelName;

    public void Register()
    {
        if (email.text != "" && password.text != "" && username.text != "" && firstName.text != "" && lastName.text != "")
        {
            string e = email.text;
            string p = password.text;
            string f = firstName.text;
            string l = lastName.text;
            string u = f + " " + l;
            DataBaseManager.registerStudent(e, p, f, l, FirstLevelName);
        }
    }

	
}
