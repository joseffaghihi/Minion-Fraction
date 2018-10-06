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
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour {

    public GameObject MenuPanel;
    public GameObject SettingsPanel;

    public GameObject Joystick;
    public GameObject JumpButton;

    private bool JoystickActive = false;

    public void Menu()
    {
        MenuPanel.SetActive(true);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void MenuClose()
    {
        MenuPanel.SetActive(false);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        MenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void Back()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void PressToggle()
    {
        if(JoystickActive == false)
        {
            JoystickActive = true;
            Joystick.SetActive(true);
            JumpButton.SetActive(true);
        }
        else
        {
            JoystickActive = false;
            Joystick.SetActive(false);
            JumpButton.SetActive(false);
        }
    }
}
