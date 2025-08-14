using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            other.GetComponent<Player>().ClearBricks();
            CollectChest.Instance.OpenChest();

        }
    }
}
