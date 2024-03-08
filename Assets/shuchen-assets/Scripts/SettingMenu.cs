using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public GameObject SMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActiveSettingMenu();
        }
    }

    public void ActiveSettingMenu()
    {
        if (SMenu.activeSelf != true)
        {
            SMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            SMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
