using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sharpshooter : MonoBehaviour
{
    public Ammunition[] ammoType;
    public Ammunition currentAmmo;
    public Image ammoDisplay;
    public TextMeshProUGUI qty;
    public GameObject reticle;
    public Slider recoverySlide;
    private Vector2 mousePos, targetPos;
    //private int depth, nearestDepth = -2;
    private GameObject occupancy;
    private float delay = 1.0f;
    private static List<EnemyShip> enemyShips;
    private bool recovering = false;
    int scroll = 0, delta = 0;

    private void Start()
    {
        currentAmmo = ammoType[0];
        ammoDisplay.sprite = currentAmmo.display;
        qty.text = "x " + GlobalControl.fish[scroll];
    }

    // Update is called once per frame
    void Update()
    {
        reticle.transform.position = mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            targetPos = mousePos;
            if(!recovering && GlobalControl.fish[scroll] > 0) Fire();
        }

        delta = (int)Input.mouseScrollDelta.y;
        if (delta != 0)
            CurrentAmmoType();
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
                e.CurrentHealth -= currentAmmo.damage * hitType;

                if(e.CurrentHealth <= 0)
                {
                    if (e.loadingAttack) StopCoroutine(e.Fire());
                    enemyShips.Remove(e);
                    Destroy(e);
                    Destroy(g);
                }
            }   
            //}
            SetRecoilPeriod(currentAmmo.recoil);
            GlobalControl.fish[scroll]--;
            qty.text = "x " + GlobalControl.fish[scroll];
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

    private void CurrentAmmoType()
    {
        scroll = (scroll + delta) % ammoType.Length;
        if (scroll < 0) scroll = ammoType.Length - 1;

        currentAmmo = ammoType[scroll];
        ammoDisplay.sprite = currentAmmo.display;
        qty.text = "x " + GlobalControl.fish[scroll];
    }
}
