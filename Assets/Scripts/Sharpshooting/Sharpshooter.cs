using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sharpshooter : MonoBehaviour
{
    public Ammunition ammoType;
    public GameObject reticle;
    public Slider recoverySlide;
    private Vector2 mousePos, targetPos;
    private int depth, nearestDepth = -2;
    private GameObject occupancy;
    private float delay = 1.0f;
    private static List<EnemyShip>[] enemyShips;
    private static List<GameObject>[] enemyShipBodies;
    private bool recovering = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reticle.transform.position = mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            targetPos = mousePos;
            if(!recovering) Fire();
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
                int hitType = IsHit(xPos, e, predictedX);

                if (hitType != 0)
                {
                    e.CurrentHealth -= ammoType.damage * hitType;

                    if(e.CurrentHealth <= 0)
                    {
                        enemyShips[depth].Remove(e);
                        Destroy(e);
                        enemyShipBodies[depth].Remove(g);
                        Destroy(g);
                    }
                }   
            }

            SetRecoilPeriod(ammoType.recoil);
        }
    }

    private bool IsPasssed(float xPos, bool goingLeft)
    {
        return (targetPos.x > xPos && goingLeft) || (targetPos.x < xPos && !goingLeft);
    }

    private int IsHit(float center, EnemyShip ship, float impact)
    {
        int hitType = 0;

        if (Mathf.Abs(center - impact) < ship.innerRadius) hitType = 2;
        else if (Mathf.Abs(center - impact) < ship.outerRadius) hitType = 1;

        return hitType;
    }

    public static void GetShips(List<EnemyShip>[] e, List<GameObject>[] g)
    {
        enemyShips = e;
        enemyShipBodies = g;
    }

    private void SetRecoilPeriod(float recoil)
    {
        recovering = true;
        recoverySlide.value = 1;

        StartCoroutine(RecoilPeriod(recoil));
    }

    private IEnumerator RecoilPeriod(float recoil)
    {
        while(recoverySlide.value > 0)
        {
            recoverySlide.value -= Time.deltaTime / recoil;
            yield return new WaitForEndOfFrame();
        }
        
        recovering = false;
    }
}
