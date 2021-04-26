using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LookOut : MonoBehaviour
{
    public Image shipSpotted;

    private static bool enemyShipSpotted = false; 

    public void ReturnToLookOut()
    {
        StartCoroutine("LookForEnemyShips");
    }

    public IEnumerator LookForEnemyShips()
    {
        float randTime = 5;//Random.Range(60, 181);
        yield return new WaitForSeconds(randTime);
        enemyShipSpotted = true;
        shipSpotted.gameObject.SetActive(true);
    }

    public static void FightShips()
    {
        if (enemyShipSpotted)
        {
            enemyShipSpotted = false;
            SceneManager.LoadScene("ShipFight");
        }
    }
}
