using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool goingUp;
    public static float verticalMovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        goingUp = false;
        verticalMovementSpeed = 0.25f;
    }
}
