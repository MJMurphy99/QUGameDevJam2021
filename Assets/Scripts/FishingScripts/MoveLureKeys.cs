using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLureKeys : MonoBehaviour
{

    private Rigidbody2D body;
    public float lureSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Left
            body.velocity = new Vector2(-lureSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //Right
            body.velocity = new Vector2(lureSpeed, 0);
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            //No Input
            body.velocity = new Vector2(0, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            GameManager.goingUp = true;
            Destroy(collision.gameObject);
        }
    }
}
