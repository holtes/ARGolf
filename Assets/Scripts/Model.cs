using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public static int score
    {
        get
        {
            if (!PlayerPrefs.HasKey("score"))
            {
                PlayerPrefs.SetInt("score", 0);
            }
            return PlayerPrefs.GetInt("score");
        }
        set
        {
            PlayerPrefs.SetInt("score", value);
        }

    }
}
