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
    //private int depth, nearestDepth = -2;
    private GameObject occupancy;
    private float delay = 1.0f;
    private static List<EnemyShip> enemyShips;
    private bool recovering = false;

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
        //depth = Mathf.RoundToInt(targetPos.y) - nearestDepth;

        for(int i = 0; i < enemyShips.Count; i++)
        {
            EnemyShip e = enemyShips[i];
            GameObject g = e.CurrentBody;

            if (Mathf.RoundToInt(g.transform.position.y) != Mathf.RoundToInt(targetPos.y)) continue;

            float xPos = g.transform.position.x;

            //If we want to have delay to impact, use these commented sections
            //if (IsPasssed(xPos, e.goingLeft)) continue;
            //else
            //{                    
            //xPos + e.moveSpeed / delay * (e.goingLeft ? -1 : 1); If we want to have delay to impact, use this
            float impactX = targetPos.x;
            int hitType = IsHit(xPos, e, impactX);

            if (hitType != 0)
            {
                e.CurrentHealth -= ammoType.damage * hitType;

                if(e.CurrentHealth <= 0)
                {
                    enemyShips.Remove(e);
                    Destroy(e);
                    Destroy(g);
                }
            }   
            //}

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

    public static void GetShips(List<EnemyShip> e)
    {
        enemyShips = e;
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
