using UnityEngine;
using System.Collections;

public class SortMove : MonoBehaviour
{
    public TreeInstance Sort;

    public GameObject Gravity;
    public GameObject Lines;
    public GameObject Cutting;

    private GameObject destroyLine;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(LineDestroy());
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            Gravity.SetActive(true);
            StartCoroutine(LateCall());
        }
    }


    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(0.5f);

        Gravity.SetActive(false);
    }

    IEnumerator LineDestroy()
    {
        yield return new WaitForSeconds(1f);

        GameObject.Destroy(Lines.transform.GetChild(0).gameObject);
    }
}
