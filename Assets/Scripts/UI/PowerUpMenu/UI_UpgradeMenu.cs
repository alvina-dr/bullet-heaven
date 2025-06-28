using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_UpgradeMenu : MonoBehaviour
{
    public List<UI_UpgradeButton> PowerUpButtonList = new();
    public List<UpgradeData> PowerUpDataList = new();

    private void Awake()
    {
        PowerUpDataList.Clear();
        PowerUpDataList = Resources.LoadAll<UpgradeData>("Upgrades/").ToList();
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

        for (int i = 0; i < PowerUpButtonList.Count; i++)
        {
            PowerUpButtonList[i].SetupPowerUpData(PowerUpDataList[Random.Range(0, PowerUpDataList.Count)]);
        }
    }

    public void CloseMenu()
    {
        Time.timeScale = 1; 
        gameObject.SetActive(false);
    }
}
