using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool goingUp;
    public static float verticalMovementSpeed;
    public float fastLureMovementSpeed, normalLureMovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        goingUp = false;
    }

    public void Update()
    {
        if (goingUp == false)
        {
            if (MoveLureMouse.fastLureMode == true)
            {
                verticalMovementSpeed = fastLureMovementSpeed;
            }
            else
            {
                verticalMovementSpeed = normalLureMovementSpeed;
            }
            
        } else if (goingUp == true)
        {
            if (MoveLureMouse.fastLureMode == true)
            {
                verticalMovementSpeed = -fastLureMovementSpeed;
            }
            else
            {
                verticalMovementSpeed = -normalLureMovementSpeed;
            }
        }
    }
}
