using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public List<Level> levels = new List<Level>();
    public Player player;
    Level currentLevel;
    int loadLevel = 1;
    void Start()
    {
        UIManager.Instance.OpenMainMenu();
        LoadLevel();
    }
    public void LoadLevel()
    {
        LoadLevel(loadLevel);
        OnInit();
    }
    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = Instantiate(levels[level - 1]);
    }
    public void OnInit()
    {
        player.transform.position = currentLevel.startPoint.position;
        player.OnInit();
    }
    public void OnStart()
    {
        GameManager.Instance.ChangeState(GameState.Playing);
    }
    public void OnFinish()
    {
        UIManager.Instance.OpenFinishUI();
        GameManager.Instance.ChangeState(GameState.GameOver);
        MoveToChest();
    }

    public void OnNext()
    {
        loadLevel++;
        LoadLevel();
    }
    public void MoveToChest()
    {
        Vector3.MoveTowards(player.transform.position, currentLevel.finishPoint.position, 0.5f);
    }
}
