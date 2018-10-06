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
1/2 * 1/2 	2-2
1/2 * 1/3	2-3
1/2 * 1/4 	2-4
1/3 * 1/3   3-3
1/2 * 3/4   2-4
2/3 * 1/4   3-4
2/3 * 3/4   3-4
3/4 * 3/4   4-4


2-2 = 1
2-3 = 2
2-4 = 3
3-3 = 4
3-4 = 5
4-4 = 6
*/


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToolHandler : MonoBehaviour {

    public GameObject CutterObjectHolder;
    public GameObject MainMenu;
    public GameObject Colors;
    public GameObject Objects;

    public GameObject[] chocolateBars;
    public GameObject SpawnPoint;
    public GameObject bar;
    public GameObject MainCamera;
    

    public void button_colors()
    {
        Colors.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void button_objects()
    {
        Objects.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void button_main()
    {
        Colors.SetActive(false);
        Objects.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void restart_scene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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
       ////// CutterObjectHolder.SetActive(false);
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
       // CutterObjectHolder.SetActive(false);

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
      //  CutterObjectHolder.SetActive(false);
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
       // CutterObjectHolder.SetActive(false);
    }

  
    public void ActivateDrag()
    {
      //  index = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<MouseDrag>();
        }

     //   CutterObjectHolder.SetActive(false);
      //  MainCamera.GetComponent<DrawLine>().enabled = false;

    }


    public void ActivateCutting()
    {
       // index = 1;
        CutterObjectHolder.SetActive(true);
        MainCamera.GetComponent<DrawLine>().enabled = true;
    }

    public GameObject rightAnswer;
    public GameObject wrongAnswer;

    public IEnumerator WaitFunctionTrue()
    {
        rightAnswer.SetActive(true);
        yield return new WaitForSeconds(3f);
        rightAnswer.SetActive(false);
    }
    public IEnumerator WaitFunctionFalse()
    {
        wrongAnswer.SetActive(true);
        yield return new WaitForSeconds(3f);
        wrongAnswer.SetActive(false);
    }

    private float massHalfCut = 0;
    public void checkSelectedBar()
    {
        if (selectedBar == rightBar)
        {
            
            StartCoroutine(WaitFunctionTrue()); 
            Objects.SetActive(false);
            // MainMenu.SetActive(true);
            CutInHalfText.SetActive(true);
            CutHalfButton.SetActive(true);
            if (selectedBar == 22)
            {
                GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[0], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                chocolateBar.transform.parent = bar.transform;
                massHalfCut = 0.5f;
            }
            else if(selectedBar == 23)
            {
                GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                chocolateBar.transform.parent = bar.transform;
            }
            else if(selectedBar == 24)
            {
                GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[2], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                chocolateBar.transform.parent = bar.transform;
            }
            else if(selectedBar ==33)
            {
                GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[3], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                chocolateBar.transform.parent = bar.transform;
            }
            else if(selectedBar == 34)
            {
                GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[4], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                chocolateBar.transform.parent = bar.transform;
            }
            else if(selectedBar == 44)
            {
                GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[5], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                chocolateBar.transform.parent = bar.transform;
            }

            Destroy(SpawnPoint);

        }
        else
        {
            StartCoroutine(WaitFunctionFalse());          
        }
    }

    private float selectedBar = 0;
    public float rightBar = 0;

    public void twoTwo()
    {      
        selectedBar = 22f;
        checkSelectedBar();
    }
    public void twoThree()
    {
        checkSelectedBar();
        selectedBar = 23f;
    }
    public void twoFour()
    {
        checkSelectedBar();
        selectedBar = 24f;
    }
    public void threeThree()
    {
        checkSelectedBar();
        selectedBar = 33f;
    }
    public void threeFour()
    {
        checkSelectedBar();
        selectedBar = 34f;
    }
    public void fourFour()
    {
        checkSelectedBar();
        selectedBar = 44f;
    }

    private float checkMass = 0;

    public GameObject CutInHalfText;
    public GameObject CutInQuarters;
    public GameObject CutHalfButton;
    public GameObject CutQuarterButton;

    public void checkFirstCut()
    {
        checkMass = bar.transform.GetChild(0).GetComponent<Rigidbody2D>().mass;
        if (massHalfCut - checkMass <= 0.1 && massHalfCut - checkMass >= -0.1)
        {
            StartCoroutine(WaitFunctionTrue());
            CutInHalfText.SetActive(false);
            colorGreenButton.SetActive(true);
            colorGreenText.SetActive(true);
            nextCutButton.SetActive(true);
            CutHalfButton.SetActive(false);
        }
        else
            StartCoroutine(WaitFunctionFalse());
    }
    
    public GameObject colorGreenButton;
    public GameObject colorGreenText;

    public void nextAfterColorGreen()
    {
        colorGreenButton.SetActive(false);
        colorGreenText.SetActive(false);
        CutInQuarters.SetActive(true);
        nextCutButton.SetActive(false);
        CutQuarterButton.SetActive(true);
    }

    public GameObject nextCutButton;
    public GameObject finalColorRed;
    public GameObject ColorRedText;
    public GameObject DragAndDrop;
    public GameObject Cutting;
    public GameObject Gravity;

    public void checkSecondCut()
    {
        checkMass = bar.transform.GetChild(0).GetComponent<Rigidbody2D>().mass;
        if (checkMass >= 0.22 && checkMass <= 0.28)
        {
            StartCoroutine(WaitFunctionTrue());
            CutQuarterButton.SetActive(false);
            CutInQuarters.SetActive(false);
            finalColorRed.SetActive(true);
            ColorRedText.SetActive(true);
            DragAndDrop.SetActive(true);
            Cutting.SetActive(false);
            MainCamera.GetComponent<DrawLine>().enabled = false;
            Gravity.SetActive(true);
            StartCoroutine(LateCall());
        }
        else
            StartCoroutine(WaitFunctionFalse());
        }
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(0.6f);

        Gravity.SetActive(false);
    }
}

