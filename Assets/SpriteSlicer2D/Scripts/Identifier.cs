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
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Identifier : MonoBehaviour {

    public GameObject bar;
    public GameObject RightAnswer;
    public GameObject WrongAnswer;
    public GameObject panel;
    public Text showFraction;
    public float force;

    private float slidedFraction = 0;
    public float answerCheck = 0;

    public void checkButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void modifier()
    {
        bar.transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        bar.transform.GetChild(1).GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        bar.transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
    }

    public void wrongAnswerActivator()
    {
        WrongAnswer.SetActive(true);
        panel.SetActive(false);
        Invoke("checkButton", 5f);
        modifier();
    }

    public void rightAnswerActivator()
    {
        panel.SetActive(false);
        RightAnswer.SetActive(true);
        Invoke("LoadNextLevel", 5f);
        modifier();
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().name == "1-4")
            SceneManager.LoadScene("1-2");
        else if (SceneManager.GetActiveScene().name == "1-2")
            SceneManager.LoadScene("3-4");
        else if (SceneManager.GetActiveScene().name == "3-4")
            SceneManager.LoadScene("1-4");
    }

    public void FractionCalculator()
    {
        slidedFraction = bar.transform.GetChild(1).GetComponent<Rigidbody2D>().mass;


        if (answerCheck == 14)
        {
            if (slidedFraction <= 0.27 && slidedFraction >= 0.22)
                rightAnswerActivator();
            else
                wrongAnswerActivator();
        }
        else if (answerCheck == 13)
        {
            if (slidedFraction <= 0.36 && slidedFraction >= 0.3)
                rightAnswerActivator();
            else
                wrongAnswerActivator();
        }
        else if (answerCheck == 12)
        {
            if (slidedFraction <= 0.53 && slidedFraction >= 0.48)
                rightAnswerActivator();
            else
                wrongAnswerActivator();
        }
        else if (answerCheck == 23)
        {
            if (slidedFraction <= 0.70 && slidedFraction >= 0.64)
                rightAnswerActivator();
            else
                wrongAnswerActivator();
        }
        else if (answerCheck == 34)
        {
            if (slidedFraction <= 0.78 && slidedFraction >= 0.72)
                rightAnswerActivator();
            else
                wrongAnswerActivator();
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            FractionCalculator();
        }
    }


 

}
