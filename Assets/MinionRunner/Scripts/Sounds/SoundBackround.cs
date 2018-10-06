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

public class SoundBackround : MonoBehaviour {


    public AudioClip backround;
    AudioSource source;

	
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
