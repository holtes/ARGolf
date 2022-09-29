using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class View : MonoBehaviour
{
    public Slider slider;
    public GameObject playerPref;
    [HideInInspector]
    public GameObject player;
    public GameObject fireworks;
    public GameObject spawnPoint;
    public TMP_Text score;
    public GameObject plane;
    public GameObject imageTarget;
    void Start()
    {
        respawnPlayer();
        score.text = Model.score.ToString();
    }

    public void respawnPlayer()
    {
        if (player != null) Destroy(player);
        player = Instantiate(playerPref);
        player.transform.SetParent(spawnPoint.transform.parent);
        player.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        player.transform.position = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        plane.transform.position = new Vector3(imageTarget.transform.position.x + 0.28f, imageTarget.transform.position.y - 0.01f, imageTarget.transform.position.z + 0.3f);
    }
}
