using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLureMouse : MonoBehaviour
{
    private Vector3 targetPos;
    public float lureSpeed;
    public static bool fastLureMode;
    public GameManager fishDirectionCall;

    void Start()
    {
        targetPos = transform.position;
        fastLureMode = false;
    }

    void Update()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);

        Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, followXonly, lureSpeed * Time.deltaTime);

        if (Input.GetKey("space"))
        {
            fastLureMode = true;
        }
        else
        {
            fastLureMode = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fish1")
        {
            GlobalControl.fish1++;
            Debug.Log(GlobalControl.fish1);
            GameManager.goingUp = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Fish2")
        {
            GlobalControl.fish1++;
            GameManager.goingUp = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Fish3")
        {
            GlobalControl.fish1++;
            GameManager.goingUp = true;
            Destroy(collision.gameObject);
        }
    }
}

