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
using System.IO;

public class UserClass : MonoBehaviour {

    static public user player = new user(null, null, null, null, null, null, null, false);
    [System.Serializable]
    public class user
    {
        public string userId;
        public string firstName;
        public string lastName;
        public string email;
        public string givenFraction;
        public string enteredFraction;
        public string enteredRFraction;
        public bool success;


        /// <summary>
        ///  One score for each individual level and one score for the total game.
        /// </summary>
        /// 

        public user(string userId1, string fn, string ln, string email1, string gf, string ef, string erf, bool success1)
        {
            userId = userId1;
            firstName = fn;
            lastName = ln;
            email = email1;
            givenFraction = gf;
            enteredFraction = ef;
            enteredRFraction = erf;
            success = success1;
           
        }

        public void setUserId(string userId1)
        {
            userId = userId1;
        }
        public string getUserId()
        {
            return userId;
        }

      /*  public void setProblemId(string problemId1)
        {
            problemId = problemId1;
        }
        public string getProblemId()
        {
            return problemId;
        }*/

        public void setSuccess(bool success1)
        {
            success = success1;
        }
        public bool getSuccess()
        {
            return success;
        }

       /* public void setScore(int score1)
        {
            score = score1;
        }
        public int getScore()
        {
            return score;
        }

        public void setHintId(string hintId1)
        {
            hintId = hintId1;
        }
        public string getHintId()
        {
            return hintId;
        }*/

        public void printUserMain()
        {
           /* using (StreamWriter sw = new StreamWriter("MinionRunner_Data/playerRecords.txt", true))  // True to append data to the file; false to overwrite the file
            {
                sw.WriteLine(player.userId + "," + player.firstName + "," + player.lastName + "," + player.email + "," + player.dob + "," + player.pn
                    + "," + player.problemId + "," + player.success + "," + player.score + "," + player.hintId + "," + "\n");
            }*/
        }

        public void printUserByLevel()
        {
          /*  using (StreamWriter sw = new StreamWriter("MinionRunner_Data/playerRecordsByLevel.txt", true))  // True to append data to the file; false to overwrite the file
            {
                sw.WriteLine(player.userId + "," + player.problemId + "," + player.success + "," + player.score + "," + player.hintId  + "\n\n");
            }*/
        }

    }

    //static public Dictionary<string, user> record = new Dictionary<string, user>();
    static public List<user> record = new List<user>();
    

    /*public void printList()
    {
        foreach (user i in record)
            i.printUser();
    }*/

}
