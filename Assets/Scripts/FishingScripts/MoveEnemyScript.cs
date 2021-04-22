using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyScript : MonoBehaviour
{ 
    private Rigidbody2D fishBody;
    public float fishSpeed;
    public float leftSideEdge, rightSideEdge;

    public bool goingRight;

    public int changeFishDirectionInt;
    public float changeFishDirectionTimer;

    // Start is called before the first frame update
    void Start()
    {
        fishBody = GetComponent<Rigidbody2D>();
        fishBody.velocity = new Vector2(-fishSpeed, GameManager.verticalMovementSpeed);
        changeFishDirectionTimer = 0.5f;
        changeFishDirectionInt = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        changeFishDirectionTimer -= Time.deltaTime;

        if(changeFishDirectionTimer < 0)
        {
            changeFishDirectionInt = Random.Range(0, 100);
            if (changeFishDirectionInt < 1)
            {
                goingRight = !goingRight;
                changeFishDirectionTimer = 2f;
            }

        }

        if (this.transform.position.x >= rightSideEdge)
        {
            goingRight = false;
        }
        else if (this.transform.position.x <= leftSideEdge)
        {
            goingRight = true;
        }

        if (goingRight == true)
        {
            fishBody.velocity = new Vector2(fishSpeed, GameManager.verticalMovementSpeed);
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            fishBody.velocity = new Vector2(-fishSpeed, GameManager.verticalMovementSpeed);
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DespawnFish")
        {
            Destroy(this.gameObject);
        }
    }
}
