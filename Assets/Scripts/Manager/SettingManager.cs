using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : Singleton<SettingManager>
{
    public GameObject setingsPanel;



    public void OpenSettingsPanel()
    {
        setingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        setingsPanel.SetActive(false);
    }


}
