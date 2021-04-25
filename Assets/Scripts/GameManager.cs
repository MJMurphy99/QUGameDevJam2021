using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool goingUp = false;
    public static float verticalMovementSpeed;
    public float fastLureMovementSpeed, normalLureMovementSpeed;
    public ParticleSystem bubbleSystem;

    private static SpawnFishAndObstacles sp;

    public static bool GoingUp
    {
        get { return goingUp; }
        set
        {
            goingUp = value;
            if(!goingUp)
            {
                sp.gameObject.SetActive(true);
                sp.depthTimer = 0;
                for (int i = 0; i < sp.allOfTheFish.transform.childCount; i++)
                    Destroy(sp.allOfTheFish.transform.GetChild(i).gameObject);
            }
            else
            {
                sp.gameObject.SetActive(false);
            }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        goingUp = false;
        sp = FindObjectOfType<SpawnFishAndObstacles>();
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
            bubbleSystem.Stop();
            verticalMovementSpeed = Mathf.Lerp(normalLureMovementSpeed, -normalLureMovementSpeed, 3);
        }
    }
}
