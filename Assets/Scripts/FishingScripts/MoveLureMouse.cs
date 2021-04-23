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
            transform.position = Vector3.Lerp(transform.position, fastLurePos.transform.position, 2 * Time.deltaTime);
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
            //this fixes the jitter bug but adds a strange jump effect
            Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, followXonly, lureSpeed * Time.deltaTime);
            //this.transform.position = targetPos;
            Destroy(collision.gameObject);
            GlobalControl.fish1++;
            Debug.Log(GlobalControl.fish1);
            GameManager.goingUp = true;
        }

        if (collision.gameObject.tag == "Fish2")
        {
            Destroy(collision.gameObject);
            GlobalControl.fish2++;
            GameManager.goingUp = true;
        }

        if (collision.gameObject.tag == "Fish3")
        {
            Destroy(collision.gameObject);
            GlobalControl.fish3++;
            GameManager.goingUp = true;
            
        }
    }
}

