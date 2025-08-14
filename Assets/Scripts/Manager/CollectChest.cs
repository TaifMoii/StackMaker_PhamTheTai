using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectChest : Singleton<CollectChest>
{
    public GameObject chestClose;
    public GameObject chestOpen;
    public Transform chestPosition;

    public void OpenChest()
    {
        chestClose.SetActive(false);
        chestOpen.SetActive(true);
        LevelManager.Instance.OnFinish();
    }
    public void CloseChest()
    {
        chestClose.SetActive(true);
        chestOpen.SetActive(false);
    }

}
