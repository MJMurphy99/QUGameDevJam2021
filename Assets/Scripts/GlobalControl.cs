using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    //public static int fish1 = 0, fish2 = 0, fish3 = 0;
    public static float[] fish = new float[4];
    public static int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            fish[0] = Mathf.Infinity;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
