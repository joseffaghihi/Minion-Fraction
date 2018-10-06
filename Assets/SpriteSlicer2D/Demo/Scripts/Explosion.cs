using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    //public GameObject CenterForce;
    public float radius = 5.0F;
    public float power = 10.0F;
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            foreach (Transform child in transform)
            {
                child.gameObject.AddComponent<Explosion>();
            }
            Vector3 objPos1 = new Vector3(3.3f, -3.7f, 0);
            AddExplosionForce(GetComponent<Rigidbody2D>(), power * 100, objPos1, radius);

        }
    }

    public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }

        body.AddForce(dir.normalized * expForce * calc);
    }

}
