using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuUI;
    public GameObject finishUI;
    public GameObject deadUI;
    public GameObject settingsUI;
    public TextMeshProUGUI levelText;

    private int currentLevel = 1;

    public void OpenMainMenu()
    {
        mainMenuUI.SetActive(true);
        finishUI.SetActive(false);
        deadUI.SetActive(false);
        settingsUI.SetActive(false);
    }
    public void OpenFinishUI()
    {
        mainMenuUI.SetActive(false);
        finishUI.SetActive(true);
        deadUI.SetActive(false);
        settingsUI.SetActive(false);
    }
    public void OpenDeadUI()
    {
        mainMenuUI.SetActive(false);
        finishUI.SetActive(false);
        settingsUI.SetActive(false);
        deadUI.SetActive(true);
    }
    public void OpenSettings()
    {
        mainMenuUI.SetActive(false);
        finishUI.SetActive(false);
        deadUI.SetActive(false);
        settingsUI.SetActive(true);
    }
    public void PlayButton()
    {
        mainMenuUI.SetActive(false);
        deadUI.SetActive(false);
        settingsUI.SetActive(true);
        LevelManager.Instance.OnStart();
    }

    public void RetryButton()
    {
        LevelManager.Instance.LoadLevel();
        GameManager.Instance.ChangeState(GameState.MainMenu);
        OpenMainMenu();
    }
    public void NextButton()
    {
        currentLevel++;
        levelText.text = currentLevel.ToString();
        LevelManager.Instance.OnNext();
        GameManager.Instance.ChangeState(GameState.MainMenu);
        OpenMainMenu();
    }
    public void OpenSettingsButton()
    {
        SettingManager.Instance.OpenSettingsPanel();
    }
}

