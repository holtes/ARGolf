using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public static App app;
    public Model model;
    public Controller controller;
    public View view;

    public static App GetInstance()
    {
        if (app == null)
        {
            app = GameObject.Find("App").GetComponent<App>();
        }
        return app;
    }
}
