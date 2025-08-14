using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrick : MonoBehaviour
{
    public GameObject brick;
    public bool isCollected = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            brick.SetActive(true);
            other.GetComponent<Player>().RemoveBrick();
        }


    }
}
