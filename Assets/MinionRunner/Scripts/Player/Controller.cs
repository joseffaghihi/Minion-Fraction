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

public class Controller : MonoBehaviour
{

   
    public float speed = 6f;
    public float jump;
    public float jumpRate;
 //   public float fireRate;

    [HideInInspector]
    public static bool setActive;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    

    public VirtualJoystick moveJoystick;

    int floorMask = 0;

    public float nextJump;

    public AudioSource jumpAudio;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Jumping();

        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");

        if (dir.magnitude > 1)
            dir.Normalize();

        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dir = moveJoystick.InputDirection;
        }
        Move(dir.x, dir.z);
        Animating(dir.x, dir.z);
    }

    void Move(float h, float v)
    {
        movement.Set(v, 0f, -h);
        movement = movement.normalized * speed * Time.deltaTime; // time between every call
        playerRigidbody.MovePosition(transform.localPosition + movement);
    }
    
    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    private void Jumping()
    {

        if (Input.GetKeyDown(KeyCode.Space) && GravityDirection.playergrounded == true)
        {           
            playerRigidbody.AddForce(transform.up * jump, ForceMode.Impulse);
            jumpAudio.Play();
        }

    }

    public void buttonJump()
    {
        if (GravityDirection.playergrounded == true)
        {
            playerRigidbody.AddForce(transform.up * jump, ForceMode.Impulse);
            jumpAudio.Play();

        }
    }
}