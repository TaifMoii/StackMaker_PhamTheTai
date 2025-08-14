using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuUI;
    public GameObject finishUI;
    public GameObject deadUI;

    public void OpenMainMenu()
    {
        mainMenuUI.SetActive(true);
        finishUI.SetActive(false);
        deadUI.SetActive(false);
    }
    public void OpenFinishUI()
    {
        mainMenuUI.SetActive(false);
        finishUI.SetActive(true);
        deadUI.SetActive(false);
    }
    public void OpenDeadUI()
    {
        mainMenuUI.SetActive(false);
        finishUI.SetActive(false);
        deadUI.SetActive(true);
    }
    public void PlayButton()
    {
        mainMenuUI.SetActive(false);
        deadUI.SetActive(false);
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
        LevelManager.Instance.OnNext();
        GameManager.Instance.ChangeState(GameState.MainMenu);
        OpenMainMenu();
    }
}
