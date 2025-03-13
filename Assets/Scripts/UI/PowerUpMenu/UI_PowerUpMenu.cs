using System.Collections.Generic;
using UnityEngine;

public class UI_PowerUpMenu : MonoBehaviour
{
    public List<UI_PowerUpButton> PowerUpButtonList = new();

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        Time.timeScale = 1; 
        gameObject.SetActive(false);
    }
}
