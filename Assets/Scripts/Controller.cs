using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void beginBallMove(float sliderValue)
    {
        App.GetInstance().view.player.GetComponent<Player>().MovementLogic(Mathf.Clamp(sliderValue * 100f, 10f, 100f));
    }

    public void finishGame()
    {
        App.GetInstance().view.player.GetComponent<Player>().DestroyRotator();
        App.GetInstance().view.respawnPlayer();
        Model.score += 1;
        App.GetInstance().view.score.text = Model.score.ToString();
        Animator animator = App.GetInstance().view.fireworks.GetComponent<Animator>();
        animator.enabled = true;
        animator.Rebind();
        
    }
}
