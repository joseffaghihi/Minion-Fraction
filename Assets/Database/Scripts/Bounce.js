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

 #pragma strict
 
var velocity = Vector3.zero;
var floorHeight = 0.0;
var sleepThreshold = 0.05;
var bounceCooef = 0.8;
var gravity = -9.8;
 
function FixedUpdate() 
{
    if (velocity.magnitude > sleepThreshold || transform.position.y > floorHeight) 
    {
        velocity.y += gravity * Time.fixedDeltaTime;
    }
    transform.position += velocity * Time.fixedDeltaTime;
    if (transform.position.y <= floorHeight) {
        transform.position.y = floorHeight;
        velocity.y = -velocity.y;
        velocity *= bounceCooef;
    }
}