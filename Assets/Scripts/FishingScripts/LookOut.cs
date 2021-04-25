using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookOut : MonoBehaviour
{
    private static bool enemyShipSpotted = true; 

    public void ReturnToLookOut()
    {
        StartCoroutine("LookForEnemyShips");
    }

    public IEnumerator LookForEnemyShips()
    {
        float randTime = Random.Range(60, 181);

        yield return new WaitForSeconds(randTime);
        enemyShipSpotted = true;
    }

    public static void FightShips()
    {
        if(enemyShipSpotted)
        {
            SceneManager.LoadScene("ShipFight");
        }
    }
}
