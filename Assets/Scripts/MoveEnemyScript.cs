using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyScript : MonoBehaviour
{ 
    private Rigidbody2D fishBody;
    public float fishSpeed = 10.0f;
    public float leftSideEdge, rightSideEdge;

    // Start is called before the first frame update
    void Start()
    {
        fishBody = GetComponent<Rigidbody2D>();
        fishBody.velocity = new Vector2(-fishSpeed, GameManager.verticalMovementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.goingUp == false)
        {
            if (this.transform.position.x >= rightSideEdge)
            {
                fishBody.velocity = new Vector2(-fishSpeed, GameManager.verticalMovementSpeed);
            }
            else if (this.transform.position.x <= leftSideEdge)
            {
                fishBody.velocity = new Vector2(fishSpeed, GameManager.verticalMovementSpeed);
            }
        }
        else
        {
            if (this.transform.position.x >= rightSideEdge)
            {
                fishBody.velocity = new Vector2(-fishSpeed, -GameManager.verticalMovementSpeed);
            }
            else if (this.transform.position.x <= leftSideEdge)
            {
                fishBody.velocity = new Vector2(fishSpeed, -GameManager.verticalMovementSpeed);
            }
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
