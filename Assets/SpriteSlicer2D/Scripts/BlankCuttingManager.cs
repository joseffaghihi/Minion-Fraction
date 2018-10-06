
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
blank
1/2
1/3 2/3
1/4 2/4 3/4
1/5 2/5 3/5 4/5
1/6 2/6 3/6 4/6 5/6
1/7 2/7 3/7 4/7 5/7 6/7
1/8 2/8 3/8 4/8 5/8 6/8 7/8
1/9 2/9 3/9 4/9 5/9 6/9 7/9 8/9
1/10 2/10 3/10 4/10 5/10 6/10 7/10 8/10 9/10
1/11 2/11 3/11 4/11 5/11 6/11 7/11 8/11 9/11 10/11
1/12 2/12 3/12 4/12 5/15 6/12 7/12 8/12 9/12 10/12 11/12 
*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlankCuttingManager : MonoBehaviour
{

    private string[] fractions = new string[67] {
            "blank",
            "1/2",
            "1/3", "2/3",
            "1/4", "2/4", "3/4",
            "1/5", "2/5", "3/5", "4/5",
            "1/6", "2/6", "3/6", "4/6", "5/6",
            "1/7", "2/7", "3/7", "4/7", "5/7", "6/7",
            "1/8", "2/8", "3/8", "4/8", "5/8", "6/8", "7/8",
            "1/9", "2/9", "3/9", "4/9", "5/9", "6/9", "7/9", "8/9",
            "1/10", "2/10", "3/10", "4/10", "5/10", "6/10", "7/10", "8/10", "9/10",
            "1/11", "2/11", "3/11", "4/11", "5/11", "6/11", "7/11", "8/11", "9/11", "10/11",
            "1/12", "2/12", "3/12", "4/12", "5/12", "6/12", "7/12", "8/12", "9/12", "10/12", "11/12" };

    private int[] ap = new int[67];
    const int NrFractions = 67;
    private string givenFration;
    private bool moveOnce;

    private Transform[] cuts;
    private Transform[] lines;

    private GameObject fractionStrip;
   

    private int correctNumberOfCuts;
    private int cutsLeft;

    Color[] colors = new Color[] { Color.white, Color.red, Color.green, Color.blue };
    private int currentColor, length;

    private bool correcCutNumber;
    private int currentFraction;
    private int firstEntry = 1;
    private int mistakes = 0;

    public GameObject CutterObjectHolder;
    public GameObject LinesHolder;
    public GameObject Colors;
    public GameObject Coloring;
    public Text TitleText;

    public GameObject fractionStrips;
    public GameObject[] easyFractionStrips;
    public GameObject SpawnPoint;
    public GameObject bar;
    public GameObject MainCamera;

    public GameObject CutButton;
    public GameObject ColorButton;

    public GameObject[] okText;
    public GameObject[] noText;

    // Use this for initialization
    void Start ()
    {
        foreach (int i in ap)
            ap[i] = 0;
        TitleText.text = "CUT THE FOLLOWING FRACTION: " + fractions[1];
        givenFration = fractions[1];

        Debug.Log(givenFration);

        correctNumberOfCuts = cutsLeft = 2;

        spawnFractionStrip();
        ap[1] = 1;

        Coloring.SetActive(false);
        CutButton.SetActive(true);
        ColorButton.SetActive(false);

        correcCutNumber = true;
        firstEntry = 1;
        currentFraction = 1;
        mistakes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*lines = LinesHolder.GetComponentsInChildren<Transform>();
        if (lines.Length - 1 == correctNumberOfCuts)
            correcCutNumber = true;
        else correcCutNumber = false;*/

        if(mistakes == 3)
        {
            mistakes = 0;
            spawnEasyFractionStrip(currentFraction);
        }

    }

    public void check_button()
    {
        //destroyLines();
        moveOnce = true;

        float correctCutMass = 0.0f;
        float errorPercentage = 0.0f;


        if (givenFration == "1/2")
        {
            correctCutMass = (float)(1.0 / 2.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);
            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Debug.Log("Correct Cut");
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                Debug.Log("Incorrect Cut");
                destroyCuts();
                spawnFractionStrip();
            }

            destroyLines();
            return;
        }


        if (givenFration == "1/3")
        {
            correctCutMass = (float)(1.0 / 3.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Debug.Log("Correct Cut");
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                Debug.Log("InCorrect Cut");
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }
        if (givenFration == "2/3")
        {
            correctCutMass = (float)(1.0 / 3.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Debug.Log("Correct Cut");
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                Debug.Log("InCorrect Cut");
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }

        if (givenFration == "1/4")
        {
            correctCutMass = (float)(1.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }
        if (givenFration == "2/4")
        {
            correctCutMass = (float)(1.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }

            destroyLines();
            return;
        }
        if (givenFration == "3/4")
        {
            correctCutMass = (float)(1.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }

        if (givenFration == "1/5")
        {
            correctCutMass = (float)(1.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }
        if (givenFration == "2/5")
        {
            correctCutMass = (float)(1.0 / 5);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }
        if (givenFration == "3/5")
        {
            correctCutMass = (float)(1.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }
        if (givenFration == "4/5")
        {
            correctCutMass = (float)(1.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }

        if (givenFration == "1/6")
        {
            correctCutMass = (float)(1.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "2/6")
        {
            correctCutMass = (float)(1.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "3/6")
        {
            correctCutMass = (float)(1.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "4/6")
        {
            correctCutMass = (float)(1.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "5/6")
        {
            correctCutMass = (float)(1.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;

        }

        if (givenFration == "1/7")
        {
            correctCutMass = (float)(1.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "2/7")
        {
            correctCutMass = (float)(1.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "3/7")
        {
            correctCutMass = (float)(1.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "4/7")
        {
            correctCutMass = (float)(1.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "5/7")
        {
            correctCutMass = (float)(1.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "6/7")
        {
            correctCutMass = (float)(1.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }

        if (givenFration == "1/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "2/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "3/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "4/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "5/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "6/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "7/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }

        if (givenFration == "1/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "2/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "3/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "4/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }
        if (givenFration == "5/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "6/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "7/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }
        if (givenFration == "8/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }

        if (givenFration == "1/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "2/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "3/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "4/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "5/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "6/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
            return;
        }
        if (givenFration == "7/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "8/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "9/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }

        if (givenFration == "1/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "2/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "3/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "4/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "5/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "6/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();



            return;
        }
        if (givenFration == "7/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "8/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "9/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "10/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }

        if (givenFration == "1/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "2/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "3/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "4/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "5/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "6/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "7/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "8/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "9/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "10/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();

            return;
        }
        if (givenFration == "11/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 20.0) / 100.0);

            if (correctAnswer(correctCutMass, errorPercentage) == true)
            {
                Coloring.SetActive(true);
                CutterObjectHolder.SetActive(false);
                CutButton.SetActive(false);
                ColorButton.SetActive(true);
            }
            else
            {
                destroyCuts();
                spawnFractionStrip();
            }
            destroyLines();
        }
        return;
    }

    public void check__color_button()
    {
        destroyLines();
        moveOnce = true;

        Rigidbody2D rbFirstCut;
        Rigidbody2D rbSecondCut;
        cuts = gameObject.GetComponentsInChildren<Transform>();
        rbFirstCut = cuts[1].GetComponent<Rigidbody2D>();
        rbSecondCut = cuts[2].GetComponent<Rigidbody2D>();

        float firstCutMass = rbFirstCut.mass;
        float secondCutMass = rbSecondCut.mass;
        float correctCutMass = 0.0f;
        float errorPercentage = 0.0f;


        if (givenFration == "1/2")
        {
            if(checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }


        if (givenFration == "1/3")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }

            return;
        }
        if (givenFration == "2/3")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }

        if (givenFration == "1/4")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "2/4")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "3/4")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }

            return;
        }

        if (givenFration == "1/5")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }

            return;
        }
        if (givenFration == "2/5")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }

            return;
        }
        if (givenFration == "3/5")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "4/5")
        {
            if (checkColoring(4) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }

        if (givenFration == "1/6")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "2/6")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "3/6")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "4/6")
        {
            if (checkColoring(4) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "5/6")
        {
            if (checkColoring(5) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;

        }

        if (givenFration == "1/7")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "2/7")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "3/7")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "4/7")
        {
            if (checkColoring(4) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "5/7")
        {
            if (checkColoring(5) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "6/7")
        {
            if (checkColoring(6) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }

        if (givenFration == "1/8")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "2/8")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "3/8")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "4/8")
        {
            if (checkColoring(4) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "5/8")
        {
            if (checkColoring(5) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "6/8")
        {
            if (checkColoring(6) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "7/8")
        {
            if (checkColoring(7) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }

        if (givenFration == "1/9")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "2/9")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }

            return;
        }
        if (givenFration == "3/9")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }

            return;
        }
        if (givenFration == "4/9")
        {
            if (checkColoring(4) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "5/9")
        {
            if (checkColoring(5) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "6/9")
        {
            if (checkColoring(6) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "7/9")
        {
            if (checkColoring(7) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "8/9")
        {
            if (checkColoring(8) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }

        if (givenFration == "1/10")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "2/10")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "3/10")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "4/10")
        {
            if (checkColoring(4) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "5/10")
        {
            if (checkColoring(5) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "6/10")
        {
            if (checkColoring(6) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "7/10")
        {
            if (checkColoring(7) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "8/10")
        {
            if (checkColoring(8) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "9/10")
        {
            if (checkColoring(9) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }

        if (givenFration == "1/11")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "2/11")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "3/11")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }

            return;
        }
        if (givenFration == "4/11")
        {
            if (checkColoring(4) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "5/11")
        {
            if (checkColoring(5) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "6/11")
        {
            if (checkColoring(6) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "7/11")
        {
            if (checkColoring(7) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "8/11")
        {
            if (checkColoring(8) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "9/11")
        {
            if (checkColoring(9) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "10/11")
        {
            if (checkColoring(10) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }

        if (givenFration == "1/12")
        {
            if (checkColoring(1) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "2/12")
        {
            if (checkColoring(2) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "3/12")
        {
            if (checkColoring(3) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "4/12")
        {
            if (checkColoring(4) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "5/12")
        {
            if (checkColoring(5) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "6/12")
        {
            if (checkColoring(6) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "7/12")
        {
            if (checkColoring(7) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "8/12")
        {
            if (checkColoring(8) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "9/12")
        {
            if (checkColoring(9) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "10/12")
        {
            if (checkColoring(10) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }
            return;
        }
        if (givenFration == "11/12")
        {
            if (checkColoring(11) == true)
            {
                Debug.Log("CorrectAnswer");
                CutterObjectHolder.SetActive(true);
                ColorButton.SetActive(false);
                Colors.SetActive(false);
                CutButton.SetActive(true);
                destroyCuts();
                spawnNextFraction();
            }
            else
            {
                Debug.Log("Incorrect");
                resetColors();
            }

        }
        return;
    }

    int firstFractionsCounter = 2;
    bool random = false;
    int limit = 2;

    void spawnNextFraction()
    {
        if (random == false)
        {
            if(firstFractionsCounter == 2)
            {
                currentFraction = 2;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/3";
                givenFration = "1/3";
                correctNumberOfCuts = cutsLeft = 2;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 3)
            {
                currentFraction = 3;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/4";
                givenFration = "1/4";
                correctNumberOfCuts = cutsLeft = 3;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 4)
            {
                currentFraction = 4;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/5";
                givenFration = "1/5";
                correctNumberOfCuts = cutsLeft = 4;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 5)
            {
                currentFraction = 5;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/6";
                givenFration = "1/6";
                correctNumberOfCuts = cutsLeft = 5;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 6)
            {
                currentFraction = 6;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/7";
                givenFration = "1/7";
                correctNumberOfCuts = cutsLeft = 6;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 7)
            {
                currentFraction = 7;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/8";
                givenFration = "1/8";
                correctNumberOfCuts = cutsLeft = 7;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 8)
            {
                currentFraction = 8;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/9";
                givenFration = "1/9";
                correctNumberOfCuts = cutsLeft = 8;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 9)
            {
                currentFraction = 9;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/10";
                givenFration = "1/10";
                correctNumberOfCuts = cutsLeft = 9;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 10)
            {
                currentFraction = 10;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/11";
                givenFration = "1/11";
                correctNumberOfCuts = cutsLeft = 10;
                firstFractionsCounter++;
            }
            else if (firstFractionsCounter == 11)
            {
                currentFraction = 11;
                TitleText.text = "CUT THE FOLLOWING FRACTION: 1/12";
                givenFration = "1/12";
                correctNumberOfCuts = cutsLeft = 11;
                firstFractionsCounter++;
                random = true;
            }
            spawnFractionStrip();
        }
        else
        {
            Random.seed = (Random.Range(Random.Range(Random.Range(Random.Range(0, 25), Random.Range(324, 5673)), Random.Range(Random.Range(53, 2378), Random.Range(50, 423))), Random.Range(Random.Range(Random.Range(23, 2354), Random.Range(1, 3456)), Random.Range(Random.Range(7, 32421), Random.Range(8, 23472)))));

            int rand = Random.Range(1, 66);
            TitleText.text = "CUT THE FOLLOWING FRACTION: " + fractions[rand];
            givenFration = fractions[rand];

            Debug.Log("Random is: " + rand + "\nFraction is: " + fractions[rand]);


            if (rand == 1) // 1/2
            {
                currentFraction = 1;
                correctNumberOfCuts = cutsLeft = 2;

                spawnFractionStrip();
            }
            else if (rand > 1 && rand < 4) // 1/3 2/3
            {
                currentFraction = 2;
                correctNumberOfCuts = cutsLeft = 3;

                spawnFractionStrip();
            }
            else if (rand > 3 && rand < 7) // 1/4 - 3/4
            {
                currentFraction = 3;
                correctNumberOfCuts = cutsLeft = 4;

                spawnFractionStrip();
            }
            else if (rand > 6 && rand < 11) // 1/5 - 4/5
            {
                currentFraction = 4;
                correctNumberOfCuts = cutsLeft = 5;

                spawnFractionStrip();
            }
            else if (rand > 10 && rand < 16) // 1/6 - 5/6
            {
                currentFraction = 5;
                correctNumberOfCuts = cutsLeft = 6;

                spawnFractionStrip();
            }
            else if (rand > 15 && rand < 22) // 1/7 - 6/7
            {
                currentFraction = 6;
                correctNumberOfCuts = cutsLeft = 7;

                spawnFractionStrip();
            }
            else if (rand > 21 && rand < 29) // 1/8 - 7/8
            {
                currentFraction = 7;
                correctNumberOfCuts = cutsLeft = 8;

                spawnFractionStrip();
            }
            else if (rand > 28 && rand < 37) // 1/9 - 8/9
            {
                currentFraction = 8;
                correctNumberOfCuts = cutsLeft = 9;

                spawnFractionStrip();
            }
            else if (rand > 36 && rand < 46) // 1/10 - 9/10
            {
                currentFraction = 9;
                correctNumberOfCuts = cutsLeft = 10;

                spawnFractionStrip();
            }
            else if (rand > 45 && rand < 56) // 1/11 - 10/11
            {
                currentFraction = 10;
                correctNumberOfCuts = cutsLeft = 11;

                spawnFractionStrip();
            }
            else if (rand > 55 && rand < 67) // 1/12 - 11/12
            {
                currentFraction = 11;
                correctNumberOfCuts = cutsLeft = 12;

                spawnFractionStrip();
            }
        }

        Debug.Log("Fraction is: " + TitleText.text);
        Debug.Log("The given fraction is: " + givenFration);
        Debug.Log("Currect cut number is: " + correctNumberOfCuts);
        Debug.Log("Limit of cuts is: " + cutsLeft);

    }

    private bool correctAnswer(float correctCutMass, float errorPercentage)
    {
        CutterObjectHolder.SetActive(false);
        Camera.main.GetComponent<DrawLine>().enabled = false;

        cuts = gameObject.GetComponentsInChildren<Transform>();
        lines = LinesHolder.GetComponentsInChildren<Transform>();
        Rigidbody2D[] rbs = new Rigidbody2D[correctNumberOfCuts+1];

        int correctLinesLenght;

        if (firstEntry == 1)
        {
            firstEntry++;
            correctLinesLenght = lines.Length - 1;
        }
        else
        {
            correctLinesLenght = lines.Length - 2;
            //correctNumberOfCuts++;
        }

        if (correctLinesLenght == correctNumberOfCuts)
        {
            for (int i = 0; i < cuts.Length - 1; i++)
            {
                rbs[i] = cuts[i + 1].GetComponent<Rigidbody2D>();
                float cutMass = rbs[i].mass;

                if (cutMass < correctCutMass && correctCutMass - cutMass < errorPercentage)
                {
                    continue;
                }
                else if (cutMass > correctCutMass && cutMass - correctCutMass < errorPercentage)
                {
                    continue;
                }
                else
                {
                    animateNo();
                    mistakes++;
                    return false;
                }
            }
        }
        else
        {
            mistakes++;
            animateNo();
            return false;
        }

        animateOk();
        return true;
    }

    private bool checkColoring(int limitColoring)
    {
        CutterObjectHolder.SetActive(false);
        Camera.main.GetComponent<DrawLine>().enabled = false;

        int countColors = 0;
        for(int i = 1;  i < cuts.Length; i++)
        {
            int ok = 0;
            if (cuts[i].transform.GetComponent<MeshRenderer>().material.color == Color.yellow)
            {
                ok = 1;
                countColors++;
                if (countColors < limitColoring && i + 1 < cuts.Length)
                {
                    for (int j = i + 1; j < cuts.Length; j++)
                        if (cuts[j].transform.GetComponent<MeshRenderer>().material.color == Color.yellow)
                        {
                            countColors++;
                            if (countColors < limitColoring && cuts[j + 1].transform.GetComponent<MeshRenderer>().material.color == Color.yellow)
                                continue;
                            else break;
                        }
                }
                else break;
            }
            if(ok == 1)
                break;
        }

        if (countColors == limitColoring)
        {
            animateOk();
            return true;
        }
        animateNo();
        return false;
    }

    private void animateOk()
    {
        int r = Random.Range(0, okText.Length);
        okText[r].SetActive(true);
        StartCoroutine(AnimateOk(r));
    }

    IEnumerator AnimateOk(int x)
    {
        yield return new WaitForSeconds(3);

        CutterObjectHolder.SetActive(true);
        Camera.main.GetComponent<DrawLine>().enabled = true;
        okText[x].SetActive(false);
    }

    private void animateNo()
    {
        int r = Random.Range(0, noText.Length);
        noText[r].SetActive(true);
        StartCoroutine(AnimanteNo(r));
    }

    IEnumerator AnimanteNo(int x)
    {
        yield return new WaitForSeconds(3);

        CutterObjectHolder.SetActive(true);
        Camera.main.GetComponent<DrawLine>().enabled = true;
        noText[x].SetActive(false);
    }

    private void resetColors()
    {
        for (int i = 1; i < cuts.Length; i++)
            cuts[i].transform.GetComponent<MeshRenderer>().material.color = Color.white;

        Debug.Log("Colors Reste!");
    }


    private void spawnFractionStrip()
    {
        correcCutNumber = true;

        ////Destroy(fractionStrip);
        SpawnPoint.SetActive(true);
        fractionStrip = (GameObject)Instantiate(fractionStrips, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        fractionStrip.transform.parent = bar.transform;
        SpawnPoint.SetActive(false);
    }

    private void spawnEasyFractionStrip(int a)
    {
        Destroy(fractionStrip);
        SpawnPoint.SetActive(true);
        fractionStrip = (GameObject)Instantiate(easyFractionStrips[a], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        fractionStrip.transform.parent = bar.transform;
        SpawnPoint.SetActive(false);
    }

    private void destroyCuts()
    {
        for (int i = 1; i < cuts.Length; i++)
        {
            Destroy((cuts[i] as Transform).gameObject);
        }
    }

    private void destroyLines()
    {
        lines = LinesHolder.GetComponentsInChildren<Transform>();
        for (int i = 1; i < lines.Length; i++)
            Destroy((lines[i] as Transform).gameObject);
    }

    public void button_colors()
    {
        Colors.SetActive(true);
        Coloring.SetActive(false);
        //MainMenu.SetActive(false);
    }
    
    public void button_coloring()
    {
        Colors.SetActive(false);
        Coloring.SetActive(true);

        Destroy(gameObject.GetComponent<BlueColor>());
        Destroy(gameObject.GetComponent<YellowColor>());
        Destroy(gameObject.GetComponent<GreenColor>());
        Destroy(gameObject.GetComponent<RedColor>());

    }

    public void selectColorButtonRed()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<RedColor>();

            Destroy(gameObject.GetComponent<BlueColor>());
            Destroy(gameObject.GetComponent<YellowColor>());
            Destroy(gameObject.GetComponent<GreenColor>());
        }
        CutterObjectHolder.SetActive(false);
    }

    public void selectColorButtonBlue()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<BlueColor>();

            Destroy(gameObject.GetComponent<RedColor>());
            Destroy(gameObject.GetComponent<YellowColor>());
            Destroy(gameObject.GetComponent<GreenColor>());
        }
        CutterObjectHolder.SetActive(false);

    }

    public void selectColorButtonYellow()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<YellowColor>();

            Destroy(gameObject.GetComponent<RedColor>());
            Destroy(gameObject.GetComponent<BlueColor>());
            Destroy(gameObject.GetComponent<GreenColor>());
        }
        CutterObjectHolder.SetActive(false);
    }

    public void selectColorButtonGreen()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<GreenColor>();

            Destroy(gameObject.GetComponent<RedColor>());
            Destroy(gameObject.GetComponent<YellowColor>());
            Destroy(gameObject.GetComponent<BlueColor>());
        }
        CutterObjectHolder.SetActive(false);
    }

}
