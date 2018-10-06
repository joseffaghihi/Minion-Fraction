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

public class TileColors : MonoBehaviour
{
    void Awake()
    {
  
                //Create random color
                Color32 col1 = new Color32((byte)Random.Range(0,1), (byte)Random.Range(100,180), (byte)Random.Range(200, 255), (byte)Random.Range(0,1));
                //Find mesh from game objects
                Mesh mesh1 = GetComponent<MeshFilter>().mesh;
                //Change colors of meshes
                
                Vector3[] vertices = mesh1.vertices;
                Color32[] colors = new Color32[vertices.Length];
                for (int i = 0; i < vertices.Length; i++)
                {
                    colors[i] = col1;
                }
                mesh1.colors32 = colors; //Set new colors of vertices
            }
            
    }



