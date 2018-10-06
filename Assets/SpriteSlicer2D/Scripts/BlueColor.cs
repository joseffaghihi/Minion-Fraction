using UnityEngine;
using System.Collections;

public class BlueColor : MonoBehaviour {

    public void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}
