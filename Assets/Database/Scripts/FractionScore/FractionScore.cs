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

public class FractionScore : MonoBehaviour {

    public int FractionValue = 0;
    public GameObject text;

    public GameObject CollectIcon;
    public GameObject CollectText;

    public GameObject UICog;
    public AudioClip pick;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FractionManager.score += FractionValue; 
            UICog.SetActive(false);
            text.SetActive(true);
            CollectIcon.SetActive(false);
            CollectText.SetActive(false);
            AudioSource.PlayClipAtPoint(pick, UICog.transform.position);
        }
    }
}
