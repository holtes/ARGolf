using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Respawn");
            App.GetInstance().view.player.GetComponent<Player>().DestroyRotator();
            App.GetInstance().view.respawnPlayer();
        }
    }
}
