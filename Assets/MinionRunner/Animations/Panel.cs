using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour
{


    public void PlayAnimation()
    {
        GetComponent<Animator>().SetBool("Move", true);
        SpawnSlider.ss = true;
    }

    public static bool playAnimation = false;

    void Update()
    {
        if (playAnimation == true)
        {
            PlayAnimation();
           // Panel.playAnimation = false;
        }
        if (FractionSelect.resetAnimation == true)
        {
            GetComponent<Animator>().SetBool("ResetPanel", true);
            
        }
    }

}

