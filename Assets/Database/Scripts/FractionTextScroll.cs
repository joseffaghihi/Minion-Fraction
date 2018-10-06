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

public class FractionTextScroll : MonoBehaviour
{
    public Text Text;
    public float duration;

    private RectTransform rectTransform;
    private Vector2 textStartPosition, textEndPosition;
    private Color textStartColor, textEndColor;
    private Coroutine TextCoroutine;

    void Start()
    {
        rectTransform = Text.GetComponent<RectTransform>();
        textStartPosition = rectTransform.anchoredPosition;
        textEndPosition = new Vector2(textStartPosition.x, Screen.height / 2);
        textStartColor = Text.color;
        textEndColor = new Color(textStartColor.r, textStartColor.g, textStartColor.b, 0f);
        //duration = 3f;
    }

    void Update()
    {
        TextCoroutine = StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        Text.enabled = true;

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; //0 means the animation just started, 1 means it finished
            rectTransform.anchoredPosition = Vector2.Lerp(textStartPosition, textEndPosition, t);
            Text.color = Color.Lerp(textStartColor, textEndColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Text.enabled = false;
    }
}