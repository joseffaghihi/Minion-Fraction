using UnityEngine;
using System.Collections;

public class GreenColor : MonoBehaviour {

    public void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow*1.5f;
        }
    }
}
