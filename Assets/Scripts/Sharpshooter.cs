using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharpshooter : MonoBehaviour
{
    private Vector2 mousePos, targetPos;
    private int depth, nearestDepth = -2;
    private GameObject occupancy;
    private float delay = 1.0f;
    private static List<EnemyShip>[] enemyShips;
    private static List<GameObject>[] enemyShipBodies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            targetPos = mousePos;
            Fire();
        }   
    }

    private void Fire()
    {
        depth = Mathf.RoundToInt(targetPos.y) - nearestDepth;

        if (enemyShips[depth] == null) return;

        for(int i = 0; i < enemyShips[depth].Count; i++)
        {
            EnemyShip e = enemyShips[depth][i];
            GameObject g = enemyShipBodies[depth][i];

            float xPos = g.transform.position.x;

            if (IsPasssed(xPos, e.goingLeft)) continue;
            else
            {
                float predictedX = xPos + e.moveSpeed / delay * (e.goingLeft ? -1 : 1);

                if (IsHit(xPos, e.radius, predictedX))
                {
                    enemyShips[depth].Remove(e);
                    Destroy(e);
                    enemyShipBodies[depth].Remove(g);
                    Destroy(g);
                }   
            }
        }
    }

    private bool IsPasssed(float xPos, bool goingLeft)
    {
        return (targetPos.x > xPos && goingLeft) || (targetPos.x < xPos && !goingLeft);
    }

    private bool IsHit(float center, float radius, float impact)
    {
        return Mathf.Abs(center - impact) < radius;
    }

    public static void GetShips(List<EnemyShip>[] e, List<GameObject>[] g)
    {
        enemyShips = e;
        enemyShipBodies = g;
    }
}
