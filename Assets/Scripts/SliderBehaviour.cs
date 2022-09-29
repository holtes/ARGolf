using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    public Image fill;
    public bool Pressed = false;
    public Color baseColor;
    public Color targetColor;
    private float timeLeft = 10.0f;
    private float sliderKoef = 0.1f;

    void Start()
    {
        fill.color = baseColor;
    }
    public void ChangeFillColor(float sliderValue)
    {
        if (timeLeft <= Time.deltaTime)
        {
            fill.color = targetColor;
        }
        else
        {
            fill.color = Color.Lerp(fill.color, targetColor, Time.deltaTime / timeLeft);
            timeLeft -= Time.deltaTime;
        }
    }

    public void onDown()
    {
        Pressed = true;
    }

    public void onUp()
    {
        timeLeft = 10.0f;
        App.GetInstance().controller.beginBallMove(transform.GetComponent<Slider>().value);
        transform.GetComponent<Slider>().value = 0;
        fill.color = baseColor;
        Pressed = false;
    }

    void Update()
    {
        if (Pressed)
        {
            transform.GetComponent<Slider>().value += Time.deltaTime * sliderKoef;
            ChangeFillColor(transform.GetComponent<Slider>().value);
        }
    }
}
