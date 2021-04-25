using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLureMouse : MonoBehaviour
{
    private Vector3 targetPos;
    public Transform normalLurePos, fastLurePos, leftHook, rightHook;
    public float lureSpeed;
    public static bool fastLureMode;
    public Sprite fastMovingLure, normalLure;
    public ParticleSystem bubbles;
    public int randomFishRotation, randomHookAttach;
    public float sideBounds;
    public bool aboveWater;

    void Start()
    {
        targetPos = transform.position;
        fastLureMode = false;
        aboveWater = true;
    }

    void Update()
    {
        /******************MOUSE MOVEMENT********************/
        float distance = transform.position.z - Camera.main.transform.position.z;
        targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);
        if (aboveWater == true)
        {
            targetPos.x = 0;
        } else if (targetPos.x > sideBounds)
        {
            targetPos.x = sideBounds;
        } else if (targetPos.x < -sideBounds) {
            targetPos.x = -sideBounds;
        } 
        Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, followXonly, lureSpeed * Time.deltaTime);
        /******************MOUSE MOVEMENT********************/

        /******************SPEED INCREASE********************/
        if (Input.GetKey("space"))
        {
            if (GameManager.goingUp == false)
            {
                fastLureMode = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = fastMovingLure;
                bubbles.startSpeed = 10;
                bubbles.emissionRate = 4;
                transform.position = Vector3.Lerp(transform.position, fastLurePos.transform.position, 2 * Time.deltaTime);
            }
        }
        else
        {
            fastLureMode = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = normalLure;
            bubbles.startSpeed = 5;
            bubbles.emissionRate = 2;
            transform.position = Vector3.Lerp(transform.position, normalLurePos.transform.position, 1 * Time.deltaTime);
        }
        /******************SPEED INCREASE********************/

        //couple of random ranges that get changed during update to make them more interesting
        randomFishRotation = Random.Range(60, 100);
        randomHookAttach = Random.Range(0, 10);
          
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish1")
        {
            collision.transform.localScale = new Vector3(1, 1, 1);
            collision.GetComponent<MoveEnemyScript>().enabled = false;
            if(randomHookAttach > 5)
            {
                collision.transform.parent = rightHook.transform;
            }
            else
            {
                collision.transform.parent = leftHook.transform;
            }
            collision.transform.localPosition = new Vector3(Random.Range(-0.1f, 0.1f), -0.2f, 0);
            collision.transform.Rotate(180, 0, randomFishRotation);
            GlobalControl.fish1++;
            GameManager.goingUp = true;
        }

        if (collision.gameObject.tag == "Fish2")
        {
            collision.transform.localScale = new Vector3(1, 1, 1);
            collision.GetComponent<MoveEnemyScript>().enabled = false;
            if (randomHookAttach > 5)
            {
                collision.transform.parent = rightHook.transform;
            }
            else
            {
                collision.transform.parent = leftHook.transform;
            }
            collision.transform.localPosition = new Vector3(Random.Range(-0.1f, 0.1f), -0.55f, 0);
            collision.transform.Rotate(180, 0, randomFishRotation);
            GlobalControl.fish2++;
            GameManager.goingUp = true;
        }

        if (collision.gameObject.tag == "Fish3")
        {
            collision.transform.localScale = new Vector3(1, 1, 1);
            collision.GetComponent<MoveEnemyScript>().enabled = false;
            if (randomHookAttach > 5)
            {
                collision.transform.parent = rightHook.transform;
            }
            else
            {
                collision.transform.parent = leftHook.transform;
            }
            collision.transform.localPosition = new Vector3(Random.Range(-0.1f, 0.1f), -0.6f, 0);
            collision.transform.Rotate(180, 0, randomFishRotation);
            GlobalControl.fish3++;
            GameManager.goingUp = true;

        }


    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PreventBubbleSpawner")
        {
            aboveWater = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PreventBubbleSpawner")
        {
            aboveWater = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "TipOfPole")
        {
            LookOut.FightShips();
        }
    }
}

