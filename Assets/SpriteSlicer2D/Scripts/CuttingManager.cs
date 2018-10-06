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

public class CuttingManager : MonoBehaviour
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
            "1/12", "2/12", "3/12", "4/12", "5/12", "6/12", "7/12", "8/12", "9/12", "10/12", "11/12" }; // this array stores all the possible fractions

    private int[] ap = new int[67];
    const int NrFractions = 67;
    //private int fractionCounter = 1;
    //private int textCounter = 1;
    private int currentFraction;

    private string givenFration;

    private int apFraction = 0;

    private Transform[] cuts;
    private Transform[] lines;

    private GameObject fractionStrip;

    private int num = 1;
    private int denom = 2;

    private bool moveOnce;

    public GameObject CutterObjectHolder;
    public GameObject LinesHolder;
    public GameObject Colors;
    public Text TitleText;

    public GameObject[] fractionStrips;
    public GameObject SpawnPoint;
    public GameObject bar;
    public GameObject MainCamera;

    public GameObject[] okText;
    public GameObject[] noText;

    //Start Function makes sure everything is correct at the beggining of the game
    void Start()
    {
        //Set the ap array to 0 for all positions
        foreach (int i in ap)
            ap[i] = 0;
        //Set the text to the first fraction
        TitleText.text = "CUT THE FOLLOWING FRACTION: " + fractions[1];
        //Set the given fraction to the first fraction
        givenFration = fractions[1];

        Debug.Log(givenFration);

        //textCounter++;
        //Spawn the first fraction strip
        fractionStrip = (GameObject)Instantiate(fractionStrips[1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        fractionStrip.transform.parent = bar.transform;
        SpawnPoint.SetActive(false);
        //Set the apparence first fration to 1
        ap[1] = 1;
        ap[0] = 1; //blank franction strip not used in this game

        //Bool to make sure the cuts move just once
        moveOnce = true; 
    }


    //Update function is called once per frame
    void Update()
    {
        //Get the cutting parts as game objects
        cuts = gameObject.GetComponentsInChildren<Transform>();

        //Move the cutting parts once if the lenght of cut = 3 (2 cut parts + 1 spawn point)
        if (cuts.Length == 3 && moveOnce == true)
        {
            float unitsToMove = 50f;
            Vector3 moveLeft = new Vector3(cuts[2].transform.position.x - unitsToMove, cuts[2].transform.position.y, cuts[2].transform.position.z);
            Vector3 moveRight = new Vector3(cuts[1].transform.position.x + unitsToMove, cuts[1].transform.position.y, cuts[1].transform.position.z);

            cuts[1].transform.position = Vector3.Lerp(cuts[1].transform.position, moveRight, Time.deltaTime);
            cuts[2].transform.position = Vector3.Lerp(cuts[2].transform.position, moveLeft, Time.deltaTime);
            moveOnce = false;
        }
    }

    //Function to activate the colors button -> not used in this game
    public void button_colors()
    {
        Colors.SetActive(true);
        //Colors.SetActive(false);
    }

    // Function to check for correct answer
    public void check_button()
    {
        //Destroy the cutting lines
        destroyLines();
        //Make sure the parts move once after the next cut
        moveOnce = true;

        //Get's the rigidbody for the two cutting parts
        Rigidbody2D rbFirstCut;
        Rigidbody2D rbSecondCut;
        cuts = gameObject.GetComponentsInChildren<Transform>();
        rbFirstCut = cuts[1].GetComponent<Rigidbody2D>();
        rbSecondCut = cuts[2].GetComponent<Rigidbody2D>();

        //Gets the mass storred in the rigidbody for both cuts
        float firstCutMass = rbFirstCut.mass;
        float secondCutMass = rbSecondCut.mass;
        //Create variables for correct cutting mass
        float correctCutMass = 0.0f;
        float errorPercentage = 0.0f;

        //Check forr different fractions -> each one individual
        //Special case for 1/2
        if (givenFration == "1/2")
        {
            //Set the correct mass acording to the fraction + set the error
            correctCutMass = (float)(1.0 / 2.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            //Check right cut
            if (firstCutMass < correctCutMass && correctCutMass - firstCutMass < errorPercentage)
            {
                animateOk();
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            //Check left cut
            else if (firstCutMass > correctCutMass && firstCutMass - correctCutMass < errorPercentage)
            {
                animateOk();
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            //Incorrect answer
            else 
            {
                animateNo();
                Debug.Log("Incorrect");
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            //Stops the fraction execution
            return; 
        }

        //This is the general way of checking all other fractions
        if (givenFration == "1/3")
        {
            //Compute the correct mass + error
            correctCutMass = (float)(1.0 / 3.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            //Flag for correct answer
            int ok = 0;

            //Call checkMass fucntion for the right cut
            if(checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
                
            }
            //Call the checkMass function for the left cut
            else if(checkMass(secondCutMass, correctCutMass, errorPercentage) == true )
            {
                ok = 1;
            }

            //Check for correct = 1 / incorrect = 0
            if(ok == 1)
            {
                animateOk();
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            //Go out of the function
            return;
        }
        if (givenFration == "2/3")
        {
            correctCutMass = (float)(2.0 / 3.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/4")
        {
            correctCutMass = (float)(1.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/4")
        {
            correctCutMass = (float)(2.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/4")
        {
            correctCutMass = (float)(3.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/5")
        {
            correctCutMass = (float)(1.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/5")
        {
            correctCutMass = (float)(2.0 / 5);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

               // //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/5")
        {
            correctCutMass = (float)(3.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "4/5")
        {
            correctCutMass = (float)(4.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/6")
        {
            correctCutMass = (float)(1.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/6")
        {
            correctCutMass = (float)(2.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/6")
        {
            correctCutMass = (float)(3.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                
                   ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "4/6")
        {
            correctCutMass = (float)(4.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "5/6")
        {
            correctCutMass = (float)(5.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

               // //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/7")
        {
            correctCutMass = (float)(1.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/7")
        {
            correctCutMass = (float)(2.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/7")
        {
            correctCutMass = (float)(3.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "4/7")
        {
            correctCutMass = (float)(4.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "5/7")
        {
            correctCutMass = (float)(5.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }  
        if (givenFration == "6/7")
        {
            correctCutMass = (float)(6.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/8")
        {
            correctCutMass = (float)(2.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/8")
        {
            correctCutMass = (float)(3.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "4/8")
        {
            correctCutMass = (float)(4.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "5/8")
        {
            correctCutMass = (float)(5.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "6/8")
        {
            correctCutMass = (float)(6.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "7/8")
        {
            correctCutMass = (float)(7.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/9")
        {
            correctCutMass = (float)(2.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/9")
        {
            correctCutMass = (float)(3.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }  
        if (givenFration == "4/9")
        {
            correctCutMass = (float)(4.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "5/9")
        {
            correctCutMass = (float)(5.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "6/9")
        {
            correctCutMass = (float)(6.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "7/9")
        {
            correctCutMass = (float)(7.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "8/9")
        {
            correctCutMass = (float)(8.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                ////Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/10")
        {
            correctCutMass = (float)(2.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/10")
        {
            correctCutMass = (float)(3.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "4/10")
        {
            correctCutMass = (float)(4.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "5/10")
        {
            correctCutMass = (float)(5.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "6/10")
        {
            correctCutMass = (float)(6.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "7/10")
        {
            correctCutMass = (float)(7.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "8/10")
        {
            correctCutMass = (float)(8.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "9/10")
        {
            correctCutMass = (float)(9.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/11")
        {
            correctCutMass = (float)(2.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/11")
        {
            correctCutMass = (float)(3.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "4/11")
        {
            correctCutMass = (float)(4.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "5/11")
        {
            correctCutMass = (float)(5.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "6/11")
        {
            correctCutMass = (float)(6.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "7/11")
        {
            correctCutMass = (float)(7.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "8/11")
        {
            correctCutMass = (float)(8.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "9/11")
        {
            correctCutMass = (float)(9.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "10/11")
        {
            correctCutMass = (float)(10.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }

        if (givenFration == "1/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "2/12")
        {
            correctCutMass = (float)(2.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "3/12")
        {
            correctCutMass = (float)(3.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "4/12")
        {
            correctCutMass = (float)(4.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "5/12")
        {
            correctCutMass = (float)(5.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "6/12")
        {
            correctCutMass = (float)(6.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "7/12")
        {
            correctCutMass = (float)(7.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "8/12")
        {
            correctCutMass = (float)(8.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "9/12")
        {
            correctCutMass = (float)(9.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "10/12")
        {
            correctCutMass = (float)(10.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            return;
        }
        if (givenFration == "11/12")
        {
            correctCutMass = (float)(11.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                animateOk();
                spawnNextFraction();
                //Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                animateNo();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[currentFraction], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        return;
    }


    //Function to spawn the correct next fraction strip if the answer was correct
    void spawnNextFraction()
    {
        //The first part spawns all of them in sequance
        /*if (num + 1 == denom)
        {
            TitleText.text = "CUT THE FOLLOWING FRACTION: " + fractions[textCounter];
            givenFration = fractions[textCounter];
            textCounter++;

            Debug.Log(givenFration);

            num = 1;
            denom++;

            //Destroy(fractionStrip);
            SpawnPoint.SetActive(true);
            fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter++], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            fractionStrip.transform.parent = bar.transform;
            SpawnPoint.SetActive(false);

        }
        else
        {
            TitleText.text = "CUT THE FOLLOWING FRACTION: " + fractions[textCounter];
            givenFration = fractions[textCounter];
            textCounter++;

            Debug.Log(givenFration);

            num++;

            /*Destroy(fractionStrip);
            SpawnPoint.SetActive(true);
            fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter++], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            fractionStrip.transform.parent = bar.transform;
            SpawnPoint.SetActive(false);*/
        //}
        
        
        //This part spawns all fractions once randomly

        //Rand seed makes sure that the sequance is always different. It generates approximatelly 700 numbers before it starts reapeating
        Random.seed = (Random.Range(Random.Range(Random.Range(Random.Range(0, 25), Random.Range(324, 5673)), Random.Range(Random.Range(53, 2378), Random.Range(50, 423))), Random.Range(Random.Range(Random.Range(23, 2354), Random.Range(1, 3456)), Random.Range(Random.Range(7, 32421), Random.Range(8, 23472)))));

        //Set the correct rand acording to how many positions there are in the fractions array
        int rand = Random.Range(1, 66);
        //Set the text to the correct fraction
        TitleText.text = "CUT THE FOLLOWING FRACTION: " + fractions[rand];
        //Set the given fraction correct
        givenFration = fractions[rand];
        //Variable for spawning the correct fraction
        apFraction = rand;

        Debug.Log("Random is: " + rand + "\nFraction is: " + fractions[rand]);

        //Flag for checking if all fractions appeard already
        int ok = 1;

        //Checks the ap array for 0 positions and stops the exectuions if all positions are set to 1
        for(int i = 1; i < NrFractions; i++)
        {
            if(ap[i] == 0)
            {
                ok = 0;
                break;
            }
        }

        //If it gets to this point it will start searching for the correct fraction strip according to the lenght of the fractions array
        if (ap[apFraction] == 0 && ok == 0)
        {
            //Special case for 1/2
            if (rand == 1) // 1/2
            {
                currentFraction = 1;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            //Allways check between x and y because the fractions have the same denominator
            else if (rand > 1 && rand < 4) // 1/3 2/3
            {
                currentFraction = 2;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[2], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 3 && rand < 7) // 1/4 - 3/4
            {
                currentFraction = 3;
                // //Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[3], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 6 && rand < 11) // 1/5 - 4/5
            {
                currentFraction = 4;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[4], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 10 && rand < 16) // 1/6 - 5/6
            {
                currentFraction = 5;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[5], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 15 && rand < 22) // 1/7 - 6/7
            {
                currentFraction = 6;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[6], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 21 && rand < 29) // 1/8 - 7/8
            {
                currentFraction = 7;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[7], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 28 && rand < 37) // 1/9 - 8/9
            {
                currentFraction = 8;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[8], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 36 && rand < 46) // 1/10 - 9/10
            {
                currentFraction = 9;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[9], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 45 && rand < 56) // 1/11 - 10/11
            {
                currentFraction = 10;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[10], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
            else if (rand > 55 && rand < 67) // 1/12 - 11/12
            {
                currentFraction = 11;
                ////Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[11], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        else spawnNextFraction();

    } 

    //Fraction to check the correct mass for each cut. Is called each time the check button is pressed except for 1/2
    private bool checkMass(float cutMass, float correctMass, float error)
    {
        //Case for right cutting object mass
        if (cutMass < correctMass && correctMass - cutMass < error)
        {
            /*spawnNextFraction();
            Destroy((cuts[1] as Transform).gameObject);
            Destroy((cuts[2] as Transform).gameObject);*/
            ap[apFraction] = 1;
            CutterObjectHolder.SetActive(false);
            Camera.main.GetComponent<DrawLine>().enabled = false;
            return true;
        }
        //Case for left cutting object mass
        else if (cutMass > correctMass && cutMass - correctMass < error)
        {
            /*spawnNextFraction();
            Destroy((cuts[1] as Transform).gameObject);
            Destroy((cuts[2] as Transform).gameObject);*/
            ap[apFraction] = 1;
            CutterObjectHolder.SetActive(false);
            Camera.main.GetComponent<DrawLine>().enabled = false;
            return true;
        }
        
        //If it gets to this point the answer was incorrect
        CutterObjectHolder.SetActive(false); //deactivate the cutting script
        Camera.main.GetComponent<DrawLine>().enabled = false; // deactivate the line drowing script
        return false;
    }

    //Function for showing different correct messages
    private void animateOk()
    {
        //Random bettweend 0 and the maximum number in the okText array
        int r = Random.Range(0, okText.Length);
        //Make the text show on the screen
        okText[r].SetActive(true);
        //Start the timmer coroutine for showing the message for few seconds
        StartCoroutine(AnimateOk(r));
    }

    //Coroutine if the answer was correct
    IEnumerator AnimateOk(int x)
    {
        //Wait for 3 seconds
        yield return new WaitForSeconds(3);

        CutterObjectHolder.SetActive(true); // activate cutting script
        Camera.main.GetComponent<DrawLine>().enabled = true; // activate line drowing script
        okText[x].SetActive(false); // deactivate the ok message
    }

    //Exact same sequance for incorrect messages
    private void animateNo()
    {
        int r = Random.Range(0, noText.Length);
        noText[r].SetActive(true);
        StartCoroutine(AnimanteNo(r));
    }

    //Same coroutine for for incorrect messages
    IEnumerator AnimanteNo(int x)
    {
        yield return new WaitForSeconds(3);

        CutterObjectHolder.SetActive(true);
        Camera.main.GetComponent<DrawLine>().enabled = true;
        noText[x].SetActive(false);
    }

    //Functions to destroy the cutting lines when the check button is pressed no matter if the answer was correc or not
    private void destroyLines()
    {
        //Gets all the lines from the parent gameobject
        lines = LinesHolder.GetComponentsInChildren<Transform>();
        //Must start form i = 1 in order not to destroy the parent gameobject for the lines
        for (int i = 1; i < lines.Length; i++)
            Destroy((lines[i] as Transform).gameObject);
    }

    /*
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


    public void ActivateDrag()
    {
        //  index = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<MouseDrag>();
        }

        CutterObjectHolder.SetActive(false);
        MainCamera.GetComponent<DrawLine>().enabled = false;

    }


    public void ActivateCutting()
    {
        // index = 1;
        CutterObjectHolder.SetActive(true);
        MainCamera.GetComponent<DrawLine>().enabled = true;
    }
    */
}
