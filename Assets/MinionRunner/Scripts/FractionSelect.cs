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


/*
const string zero = "2/4";
const string one = "3/6";
const string two = "4/8";
const string three = "5/10";
const string four = "6/12";

const string reducedOne = "1/2";

const string five = "2/6";
const string six = "3/9";
const string seven = "4/12";
const string eight = "5/15";
const string nine = "6/18";

const string reducedTwo = "1/3";

const string ten = "4/6";
const string eleven = "9/6";
const string twelve = "8/12";
const string thirteen = "10/15";
const string fourteen = "12/18";

const string reducedThree = "2/3";

const string fifteen = "2/8";
const string sixteen = "3/12";
const string seventeen = "4/16";
const string eightteen = "5/20";
const string nineteen = "6/24";

const string reducedFour = "1/4";

const string twenty = "6/8";
const string twentyone = "9/12";
const string twentytwo = "12/16";
const string twentythree = "15/20";

const string reducedFive = "3/4";

*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class FractionSelect : MonoBehaviour
{

    const string zero = "2/4";
    const string one = "3/6";
    const string two = "4/8";
    const string three = "5/10";
    const string four = "6/12";

    const string reducedOne = "1/2";

    const string five = "2/6";
    const string six = "3/9";
    const string seven = "4/12";
    const string eight = "5/15";
    const string nine = "6/18";

    const string reducedTwo = "1/3";

    const string ten = "4/6";
    const string eleven = "9/6";
    const string twelve = "8/12";
    const string thirteen = "10/15";
    const string fourteen = "12/18";

    const string reducedThree = "2/3";

    const string fifteen = "2/8";
    const string sixteen = "3/12";
    const string seventeen = "4/16";
    const string eightteen = "5/20";
    const string nineteen = "6/24";

    const string reducedFour = "1/4";

    const string twenty = "6/8";
    const string twentyone = "9/12";
    const string twentytwo = "12/16";
    const string twentythree = "15/20";

    const string reducedFive = "3/4";


    public static FractionSelect instance;
 //   public GameObject lives;

    public GameObject slowMotion;

    public Transform Player;

    public float SlowMoTime, SlowTimeAllowed;
    public float resetTime;

    public GameObject[] myFraction;
    public GameObject RightWrongAnswer;

    public GameObject[] inputPanels;
    public Slider[] sliderValue;
    public Slider[] slider2ndCheck;

    public Sprite[] reset;
    public Sprite[] oneHalf;
    public Sprite[] oneThird;
    public Sprite[] twoThird;
    public Sprite[] oneFourth;
    public Sprite[] threeFourth;

    public Sprite[] right;
    public Sprite[] wrong;
     
    private int AnswerCheck;
    private int sliderSelect;
    private bool AnswerWasRightOrWrong = false;

    public int randomFraction = 0;

    public AudioSource rightAnswerAudio;
    public AudioSource wrongAnswerAudio;

    //DragNDropSection
    public Slider[] dragNdropReducedSliders;
    public GameObject[] dragNdDropComponentsToActivate;

   
    private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
    public static System.Diagnostics.Stopwatch totalStopwatch = new System.Diagnostics.Stopwatch();
    void OnTriggerEnter(Collider other) // show the fractions 
    {
        
        stopwatch.Start();
        totalStopwatch.Start();

        FractionSelect.resetAnimation = false;
        //      GameObject.Find("Slider 1").GetComponent<Animator>().Play("Idle", -1, 0f);

        if (other.tag == "Fraction2")
        {

            if (Scoring.score <= 15)
            {
                randomFraction = 0;
            }
            else if (Scoring.score >= 16)
            {
                randomFraction = Random.Range(0, 5);
            }
            Debug.Log("HitFraction2 show me");
            //   SlowMo(); 

            if (randomFraction == 0)
            {
                sliderSelect = 0;
                UserClass.player.givenFraction = zero;
                UserClass.player.enteredFraction = zero;
                UserClass.player.enteredRFraction = reducedOne;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[0];
                AnswerCheck = 1;                           
            }
            else if (randomFraction == 1)
            {
                sliderSelect = 1;
                UserClass.player.givenFraction = one;
                UserClass.player.enteredFraction = one;
                UserClass.player.enteredRFraction = reducedOne;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[1];
                AnswerCheck = 1;
            }
            else if (randomFraction == 2)
            {
                sliderSelect = 2;
                UserClass.player.givenFraction = two;
                UserClass.player.enteredFraction = two;
                UserClass.player.enteredRFraction = reducedOne;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[2];
                AnswerCheck = 1;
            }
            else if (randomFraction == 3)
            {
                sliderSelect = 3;
                UserClass.player.givenFraction = three;
                UserClass.player.enteredFraction = three;
                UserClass.player.enteredRFraction = reducedOne;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[3];
                AnswerCheck = 1;
            }
            else if (randomFraction == 4)
            {
                sliderSelect = 4;
                UserClass.player.givenFraction = four;
                UserClass.player.enteredFraction = four;
                UserClass.player.enteredRFraction = reducedOne;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[4];
                AnswerCheck = 1;
            }


        }
        else if (other.tag == "Fraction3")
        {
            Debug.Log("Hit Fraction 3 show me");
            //        SlowMo();
            if (Scoring.score <= 15)
            {
                randomFraction = Random.Range(0, 2);

                if(randomFraction == 0)
                {
                    randomFraction = 0;
                }
                else if(randomFraction == 1)
                {
                    randomFraction = 5;
                }
            }
            else if (Scoring.score >= 16)
            {
                randomFraction = Random.Range(0, 10);
            }

            if (randomFraction == 0)
            {
                sliderSelect = 5;
                UserClass.player.givenFraction = five;
                UserClass.player.enteredFraction = five;
                UserClass.player.enteredRFraction = reducedTwo;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[0];
                AnswerCheck = 2;
            }
            else if (randomFraction == 1)
            {
                sliderSelect = 6;
                UserClass.player.givenFraction = six;
                UserClass.player.enteredFraction = six;
                UserClass.player.enteredRFraction = reducedTwo;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[1];
                AnswerCheck = 2;
            }
            else if (randomFraction == 2)
            {
                sliderSelect = 7;
                UserClass.player.givenFraction = seven;
                UserClass.player.enteredFraction = seven;
                UserClass.player.enteredRFraction = reducedTwo;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[2];
                AnswerCheck = 2;
            }
            else if (randomFraction == 3)
            {
                sliderSelect = 8;
                UserClass.player.givenFraction = eight;
                UserClass.player.enteredFraction = eight;
                UserClass.player.enteredRFraction = reducedTwo;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[3];
                AnswerCheck = 2;
            }
            else if (randomFraction == 4)
            {
                sliderSelect = 9;
                UserClass.player.givenFraction = nine;
                UserClass.player.enteredFraction = nine;
                UserClass.player.enteredRFraction = reducedTwo;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[4];
                AnswerCheck = 2;
            }
            else if (randomFraction == 5)
            {
                sliderSelect = 10;
                UserClass.player.givenFraction = ten;
                UserClass.player.enteredFraction = ten;
                UserClass.player.enteredRFraction = reducedThree;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[0];
                AnswerCheck = 3;
            }
            else if (randomFraction == 6)
            {
                sliderSelect = 11;
                UserClass.player.givenFraction = eleven;
                UserClass.player.enteredFraction = eleven;
                UserClass.player.enteredRFraction = reducedThree;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[1];
                AnswerCheck = 3;
            }
            else if (randomFraction == 7)
            {
                sliderSelect = 12;
                UserClass.player.givenFraction = twelve;
                UserClass.player.enteredFraction = twelve;
                UserClass.player.enteredRFraction = reducedThree;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[2];
                AnswerCheck = 3;
            }
            else if (randomFraction == 8)
            {
                sliderSelect = 13;
                UserClass.player.givenFraction = thirteen;
                UserClass.player.enteredFraction = thirteen;
                UserClass.player.enteredRFraction = reducedThree;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[3];
                AnswerCheck = 3;
            }
            else if (randomFraction == 9)
            {
                sliderSelect = 14;
                UserClass.player.givenFraction = fourteen;
                UserClass.player.enteredFraction = fourteen;
                UserClass.player.enteredRFraction = reducedThree;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[4];
                AnswerCheck = 3;
            }
        
        }
        if (other.tag == "Fraction4")
        {
             Debug.Log("Hit Fraction 4 show me");
            ///      SlowMo();
            if (Scoring.score <= 15)
            {
                randomFraction = Random.Range(0, 2);

                if (randomFraction == 0)
                {
                    randomFraction = 0;
                }
                else if (randomFraction == 1)
                {
                    randomFraction = 5;
                }
            }
            else if (Scoring.score >= 16)
            {
                randomFraction = Random.Range(0, 9);
            }

            if (randomFraction == 0)
                {
                    sliderSelect = 15;
                    UserClass.player.givenFraction = fifteen;
                    UserClass.player.enteredFraction = fifteen;
                    UserClass.player.enteredRFraction = reducedFour;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[0];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 1)
                {
                    sliderSelect = 16;
                    UserClass.player.givenFraction = sixteen;
                    UserClass.player.enteredFraction = sixteen;
                    UserClass.player.enteredRFraction = reducedFour;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[1];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 2)
                {
                    sliderSelect = 17;
                    UserClass.player.givenFraction = seventeen;
                    UserClass.player.enteredFraction = seventeen;
                    UserClass.player.enteredRFraction = reducedFour;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[2];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 3)
                {
                    sliderSelect = 18;
                    UserClass.player.givenFraction = eightteen;
                    UserClass.player.enteredFraction = eightteen;
                    UserClass.player.enteredRFraction = reducedFour;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[3];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 4)
                {
                    sliderSelect = 19;
                    UserClass.player.givenFraction = nineteen;
                    UserClass.player.enteredFraction = nineteen;
                    UserClass.player.enteredRFraction = reducedFour;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[4];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 5)
                {
                    sliderSelect = 20;
                    UserClass.player.givenFraction = twenty;
                    UserClass.player.enteredFraction = twenty;
                    UserClass.player.enteredRFraction = reducedFive;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = threeFourth[0];
                    AnswerCheck = 5;
                }
                if (randomFraction == 6)
                {
                    sliderSelect = 21;
                    UserClass.player.givenFraction = twentyone;
                    UserClass.player.enteredFraction = twentyone;    
                    UserClass.player.enteredRFraction = reducedFive;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = threeFourth[1];
                    AnswerCheck = 5;
                }
                else if (randomFraction == 7)
                {
                    sliderSelect = 22;
                    UserClass.player.givenFraction = twentytwo;
                    UserClass.player.enteredFraction = twentytwo;
                    UserClass.player.enteredRFraction = reducedFive;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = threeFourth[2];
                    AnswerCheck = 5;
                }
                else if (randomFraction == 8)
                {
                    sliderSelect = 23;
                    UserClass.player.givenFraction = twentythree;
                    UserClass.player.enteredFraction = twentythree;
                    UserClass.player.enteredRFraction = reducedFive;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = threeFourth[3];
                    AnswerCheck = 5;
                }
        }
    }

    void SlowMo()
    {
        if (Time.timeScale == 1.0F)
        {
            Time.timeScale = SlowMoTime;
            slowMotion.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }          
    }

    void Reset()
    {
        myFraction[sliderSelect].GetComponent<Image>().overrideSprite = reset[0];
        slowMotion.gameObject.SetActive(false);
        
    }

    void Reset2()
    {
        RightWrongAnswer.GetComponent<Image>().overrideSprite = reset[1];
    }

    public bool checkAnswer;
    void AnswerCheckOneHalf()
    {
        if (0.45 <= checkInput && 0.55 >= checkInput)
        {
            checkAnswer = true;
        }
        else
        {
            checkAnswer = false;
        }
         
        if (AnswerCheck == 1 && checkAnswer)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("1 = 1 ... + 5");
       
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            Panel.playAnimation = true;
            //Invoke("Reset2", resetTime);
            AnswerWasRightOrWrong = true;
        }
        else if (!checkAnswer)
        {
            if (AnswerCheck == 1)
            {
                Scoring.score = Scoring.score - 5;
              //  Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("1 = 1 wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
                Invoke("Reset2", resetTime);
                AnswerWasRightOrWrong = false;

            }
        }
    }

    void AnswerCheckOneThird()
    {

        if (0.27 <= checkInput && 0.36 >= checkInput)
        {
            checkAnswer = true;
        }
        else
        {
            checkAnswer = false;
        }
        if (checkAnswer && AnswerCheck == 2)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("2 = 2 ... + 5");
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            //   Invoke("Reset2", resetTime);
            Panel.playAnimation = true;
            AnswerWasRightOrWrong = true;
        }
        else if (!checkAnswer)
        {
            if (AnswerCheck == 2)
            {
                Scoring.score = Scoring.score - 5;
               // Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("2 = 2  wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
            //    Invoke("Reset2", resetTime);
              
                AnswerWasRightOrWrong = false;
            }
        }
    }

    void AnswerCheckThreeTwoThird()
    {
        if (0.63 <= checkInput && 0.69 >= checkInput)
        {
            checkAnswer = true;
        }
        else
        {
            checkAnswer = false;
        }
        if (checkAnswer && AnswerCheck == 3)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("3 = 3.... +5");
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            //      Invoke("Reset2", resetTime);
            Panel.playAnimation = true;
          
            AnswerWasRightOrWrong = true;
        }
        else if (!checkAnswer)
        {
            if (AnswerCheck == 3)
            {
                Scoring.score = Scoring.score - 5;
            //    Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("3 = 3  wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
          //      Invoke("Reset2", resetTime);
              
                AnswerWasRightOrWrong = false;
               
            }
        }
    }

    void AnswerCheckOneFourth()
    {
            if (0.20 <= checkInput && 0.30 >= checkInput)
            {
                checkAnswer = true;
            }
            else
            {
                checkAnswer = false;
            }
            if (checkAnswer && AnswerCheck == 4)
            {
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("3 = 3.... +5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
           //     Invoke("Reset2", resetTime);
              
                AnswerWasRightOrWrong = true;
                Panel.playAnimation = true;
        }
            else if (!checkAnswer)
            {
                if (AnswerCheck == 4)
                {
                    Scoring.score = Scoring.score - 5;
                    //    Scoring.lives = Scoring.lives - 1;
                    Time.timeScale = 1.0F;
                    Time.fixedDeltaTime = 0.02F * Time.timeScale;
                    Debug.Log("3 = 3  wrong ... - 5");
                    RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
               //     Invoke("Reset2", resetTime);
                   
                    AnswerWasRightOrWrong = false;
            }
            }
        }

    void AnswerCheckThreeFourth()
    {
        if (0.70 <= checkInput && 0.80 >= checkInput)
        {
            checkAnswer = true;
        }
        else
        {
            checkAnswer = false;
        }

        if (checkAnswer && AnswerCheck == 5)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("3 = 3.... +5");
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
        //    Invoke("Reset2", resetTime);
     
            AnswerWasRightOrWrong = true;
            Panel.playAnimation = true;
        }
        else if (!checkAnswer)
        {
            if (AnswerCheck == 5)
            {
                Scoring.score = Scoring.score - 5;
                //    Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("3 = 3  wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
             //   Invoke("Reset2", resetTime);
           
                AnswerWasRightOrWrong = false;
            }
        }
    }

    void Update()
    {
        if (Player)
        {
            transform.position = new Vector3(Player.transform.position.x, 0, 0);
        }
        else if (!Player)
        {
            transform.position = transform.position;
        }

    }

    public float checkInput;
    
    public void Submit1stSlider()
    {
        

        Debug.Log(sliderValue[sliderSelect].value);

        checkInput = sliderValue[sliderSelect].value;
    
        AnswerCheckOneFourth();  
        AnswerCheckOneHalf();
        AnswerCheckOneThird();
        AnswerCheckThreeTwoThird();  
        AnswerCheckThreeFourth();      
        Invoke("Reset2", resetTime);

        if (AnswerWasRightOrWrong == true)
        {
            float timeTaken = 0.001f * stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            Debug.Log(UserClass.player.enteredFraction);
            DataBaseManager.writeSuccess(UserClass.player.givenFraction, UserClass.player.enteredFraction, "0", "0", 0, timeTaken, 0);
            GameObject.Find("Check Answer Button").SetActive(false);
     //       rightAnswerAudio = GetComponent<AudioSource>();
            rightAnswerAudio.Play();
            



        }
        else
        {
            float timeTaken = 0.001f * stopwatch.ElapsedMilliseconds;
            DataBaseManager.writeSuccess(UserClass.player.givenFraction, checkInput.ToString(), "0", "0", 0, timeTaken, 0);
            wrongAnswerAudio.Play();
        }

        //   

    }
    public float check2ndInput;

    public static bool resetAnimation = false;
    public void Submit2ndSlider()
    {
        Debug.Log(slider2ndCheck[sliderSelect].value);

        check2ndInput = slider2ndCheck[sliderSelect].value;
        Panel.playAnimation = false;
        SpawnSlider.ss = false;

        if (Mathf.Abs(check2ndInput - checkInput) < 0.08)
        {
            GameObject.Find("Slider (2)").SetActive(true);
            resetAnimation = true;
            inputPanels[sliderSelect].gameObject.SetActive(false);
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            Invoke("Reset2", resetTime);
            Reset();
            Scoring.score = Scoring.score + 5;
            slider2ndCheck[sliderSelect].value = 0;

            stopwatch.Stop();
            float timeTaken = 0.001f * stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            DataBaseManager.writeSuccess(UserClass.player.givenFraction, UserClass.player.enteredFraction, UserClass.player.enteredRFraction, "0", 0, timeTaken, 0);
            rightAnswerAudio.Play();
            //Call drag and drop check
            checkDragNDrop(UserClass.player.enteredRFraction, check2ndInput);
        }
        else
        {
            RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
            Invoke("Reset2", resetTime);

            float timeTaken = 0.001f * stopwatch.ElapsedMilliseconds;

            DataBaseManager.writeSuccess(UserClass.player.givenFraction, UserClass.player.enteredFraction, check2ndInput.ToString(),"0", 0, timeTaken, 0);
            wrongAnswerAudio.Play();

        }
    }

    public static string answerToBeChecked;
    public static System.Diagnostics.Stopwatch stopwatchDnD = new System.Diagnostics.Stopwatch();
    private void checkDragNDrop(string correctFraction, float sliderValue)
    {
        stopwatchDnD.Start();
        answerToBeChecked = correctFraction;

        foreach (GameObject i in dragNdDropComponentsToActivate)
            i.SetActive(true);

        foreach (Slider i in dragNdropReducedSliders)
            i.gameObject.SetActive(false);

        if(correctFraction == "1/2")
        {
            dragNdropReducedSliders[0].gameObject.SetActive(true);
            dragNdropReducedSliders[0].value = sliderValue;
        }
        else if(correctFraction == "1/3")
        {
            dragNdropReducedSliders[1].gameObject.SetActive(true);
            dragNdropReducedSliders[1].value = sliderValue;
        }
        else if(correctFraction == "1/4")
        {
            dragNdropReducedSliders[2].gameObject.SetActive(true);
            dragNdropReducedSliders[2].value = sliderValue;
        }
        else if(correctFraction == "2/3")
        {
            dragNdropReducedSliders[3].gameObject.SetActive(true);
            dragNdropReducedSliders[3].value = sliderValue;
        }
        else if(correctFraction == "3/4")
        {
            dragNdropReducedSliders[4].gameObject.SetActive(true);
            dragNdropReducedSliders[4].value = sliderValue;
        }
    }

    /*  public void gameOver()
      {
          if(Scoring.lives == 0)
          {

          }
      }*/
}


/* reset animation
 * setactive false slider
 * button and text
 * */
 