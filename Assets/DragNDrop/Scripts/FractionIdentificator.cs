using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FractionIdentificator : MonoBehaviour
{

    public GameObject numerator;
    public GameObject denominator;

    private NumberValue[] numeratorValues;
    private NumberValue[] denominatorValues;

    private DropZone numeratorDropZone;
    private DropZone denominaotrDropZone;

    public static string enteredAnswer;

    void Start()
    {
        numeratorDropZone = numerator.GetComponent<DropZone>();
        denominaotrDropZone = denominator.GetComponent<DropZone>();
    }

    // Update is called once per frame
    void Update()
    {
        numeratorValues = numerator.GetComponentsInChildren<NumberValue>();
        denominatorValues = denominator.GetComponentsInChildren<NumberValue>();

        if (numeratorValues.Length > 0)
            numeratorDropZone.enabled = false;
        if (numeratorValues.Length == 0)
            numeratorDropZone.enabled = true;

        if (denominatorValues.Length > 0)
            denominaotrDropZone.enabled = false;
        if (denominatorValues.Length == 0)
            denominaotrDropZone.enabled = true;

        if (numeratorValues.Length > 0 && denominatorValues.Length > 0)
            enteredAnswer = SetFraction();



        /*foreach(NumberValue i in numeratorValues)
        {
            Debug.Log("The nominator value is: " + i.value);
        }

        foreach (NumberValue i in denominatorValues)
        {
            Debug.Log("The denominator value is: " + i.value);
        }*/
    }

    private string SetFraction()
    {
        string a = numeratorValues[0].value + "/" + denominatorValues[0].value;
        return a;
    }

}