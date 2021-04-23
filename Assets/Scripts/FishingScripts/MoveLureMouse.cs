using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLureMouse : MonoBehaviour
{
    private Vector3 targetPos;
    public Transform normalLurePos, fastLurePos;
    public float lureSpeed;
    public static bool fastLureMode;
    public Sprite fastMovingLure, normalLure;

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
            this.gameObject.GetComponent<SpriteRenderer>().sprite = fastMovingLure;
            transform.position = Vector3.Lerp(transform.position, fastLurePos.transform.position, 1 * Time.deltaTime);
        }
        else
        {
            fastLureMode = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = normalLure;
            transform.position = Vector3.Lerp(transform.position, normalLurePos.transform.position, 1 * Time.deltaTime);
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
            GlobalControl.fish2++;
            GameManager.goingUp = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Fish3")
        {
            GlobalControl.fish3++;
            GameManager.goingUp = true;
            Destroy(collision.gameObject);
        }
    }
}

