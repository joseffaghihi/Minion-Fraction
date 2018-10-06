using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckDragNDropAnswer : MonoBehaviour
{

    public Slider[] dragNdropReducedSliders;
    public GameObject[] dragNdDropComponentsToActivate;

    public AudioSource rightAnswerAudio;
    public AudioSource wrongAnswerAudio;


    private string correctAnswer;
    private string enteredAnswer;

    private Refresh DragNDropObject;

	public GameObject Numbers;
	public GameObject Numerator;
	public GameObject Denominator; 

    public void ClickToCheckAnswer()
    {

        DragNDropObject = new Refresh();
           
        Debug.Log("Button Clicked!");

        correctAnswer = FractionSelect.answerToBeChecked;
        enteredAnswer = FractionIdentificator.enteredAnswer;

        Debug.Log("Correct answer is: " + correctAnswer);
        Debug.Log("Entered answer is: " + enteredAnswer);

        if (correctAnswer == enteredAnswer)
        {

			Transform child = Numerator.gameObject.transform.GetChild(0);
			child.SetParent(Numbers.transform);

			Transform child2 = Denominator.gameObject.transform.GetChild(0);
			child2.SetParent(Numbers.transform);
			rightAnswerAudio.Play();

            Debug.Log("Answer is Correct!");

            foreach (GameObject i in dragNdDropComponentsToActivate)
                i.SetActive(false);

            foreach (Slider i in dragNdropReducedSliders)
                i.gameObject.SetActive(false);

            FractionSelect.stopwatchDnD.Stop();
            FractionSelect.totalStopwatch.Stop();
            float timeTaken = 0.001f * FractionSelect.stopwatchDnD.ElapsedMilliseconds;
            float totalTimeTaken = 0.001f * FractionSelect.totalStopwatch.ElapsedMilliseconds;
            FractionSelect.stopwatchDnD.Reset();
            FractionSelect.totalStopwatch.Reset();

            DataBaseManager.writeSuccess(UserClass.player.givenFraction, UserClass.player.enteredFraction, UserClass.player.enteredRFraction, enteredAnswer, 1, timeTaken, totalTimeTaken);
        }

        else
        {
            FractionSelect.stopwatchDnD.Stop();
            FractionSelect.totalStopwatch.Stop();
            float timeTaken = 0.001f * FractionSelect.stopwatchDnD.ElapsedMilliseconds;
            FractionSelect.stopwatchDnD.Reset();

            wrongAnswerAudio.Play();
            Debug.Log("Answer is not correct!");
            DataBaseManager.writeSuccess(UserClass.player.givenFraction, UserClass.player.enteredFraction, UserClass.player.enteredRFraction, enteredAnswer, 0, timeTaken, 0);
        }
    }
}
