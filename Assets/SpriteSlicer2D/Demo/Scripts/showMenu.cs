using UnityEngine;
using System.Collections;

public class showMenu : MonoBehaviour
{

    public GameObject PauseMenuToShow;
    public GameObject PauseMenuBG;

    public void clickMe()
    {
        if (PauseMenuToShow.activeSelf == true && PauseMenuBG.activeSelf == true)
        {
            PauseMenuToShow.SetActive(false);
            PauseMenuBG.SetActive(false);
        }
        else
        {
            PauseMenuToShow.SetActive(true);
            PauseMenuBG.SetActive(true);
        }
    }
}
