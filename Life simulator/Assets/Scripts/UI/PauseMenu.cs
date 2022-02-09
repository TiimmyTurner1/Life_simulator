using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnPauseMenuButton()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void OnPlayMenuButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    
    public void OnSettingMenuButton()
    {
        //
    }
    
    public void OnExitMenuButton()
    {
        Application.Quit();
    }
}
