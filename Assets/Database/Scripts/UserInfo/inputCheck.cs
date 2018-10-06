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

public class inputCheck : MonoBehaviour {

    public InputField username;
    public InputField firstName;
    public InputField lastName;
    public InputField email;
    public InputField password;

    public GameObject instructions;
    public GameObject textIfFail;

    public GameObject userReq;
    public GameObject firstReq;
    public GameObject lastReq;
    public GameObject emailReq;
    public GameObject passReq;

    public string currentLevel;

    public void checkInputs()
    {
        /* if (username.text == "")
             Debug.Log("username is empty");
         else
         {
             Debug.Log("username is not empty");
             string name = username.text;
             Debug.Log(name);
         }*/

        if (username.text == "" || firstName.text == "" || lastName.text == "" || email.text == "" || password.text == "")
        {
            instructions.SetActive(false);
            textIfFail.SetActive(true);

            //if (username.text == "")
                userReq.SetActive(true);
            //if (firstName.text == "")
                firstReq.SetActive(true);
            //if (lastName.text == "")
                lastReq.SetActive(true);
            //if (email.text == "")
                emailReq.SetActive(true);
            //if (password.text == "")
                passReq.SetActive(true);
        }

        else
        {
            userReq.SetActive(false);
            firstReq.SetActive(false);
            lastReq.SetActive(false);
            emailReq.SetActive(false);
            textIfFail.SetActive(false);
            passReq.SetActive(false);

            UserClass.player.userId = username.text;
            UserClass.player.firstName = firstName.text;
            UserClass.player.lastName = lastName.text;
            UserClass.player.email = email.text;
            //UserClass.player.problemId = currentLevel;
           // UserClass.player.success = true;
           // UserClass.player.score = -1;
           // UserClass.player.hintId = "Succesfully created a new user";


          //  UserClass.record.Add(UserClass.player);
          //  UserClass.player.printUserMain();

            //UserClass.player.printUser();

            Application.LoadLevel("UserInfoSuccess");
        }
    }
}
