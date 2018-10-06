using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour {

    float distance = 100;


   
    public void OnMouseDrag()
    {
        
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToViewportPoint(mousePosition);

            transform.position = objPosition *2;
            
    }
}
