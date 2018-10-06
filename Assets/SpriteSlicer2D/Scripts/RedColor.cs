using UnityEngine;
using System.Collections;

public class RedColor : MonoBehaviour {

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<MeshRenderer>().material.color == Color.yellow*1.5f)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (gameObject.GetComponent<MeshRenderer>().material.color == Color.white)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 1f, 1f);
            }

            //  gameObject.GetComponent<MeshRenderer>().material.color = Color.red;


        }
    }
}
