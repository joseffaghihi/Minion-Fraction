using UnityEngine;
using System.Collections;

public class DestroyCuttingLine : MonoBehaviour
{
    public Transform[] lines;

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            lines = gameObject.GetComponentsInChildren<Transform>();
            foreach (Transform i in lines)
                i.gameObject.SetActive(false);
        }
	}
}
