using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject fireworks;
    public void playParticleSystem()
    {
        fireworks.transform.GetComponent<ParticleSystem>().Play();
        Debug.Log(fireworks.transform.GetComponent<ParticleSystem>().startDelay);
        StartCoroutine(stopParticleSystem());
    }

    public void refreshParticleSystem()
    {
        fireworks.transform.GetComponent<ParticleSystem>().startSize = 3;
        fireworks.SetActive(true);
    }
    public IEnumerator stopParticleSystem()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Fire!");
        fireworks.transform.GetComponent<ParticleSystem>().startSize = 0;
        fireworks.SetActive(false);
    } 
}
