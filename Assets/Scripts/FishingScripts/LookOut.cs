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
        float randTime = Random.Range(60, 181);
        print(randTime);
        yield return new WaitForSeconds(randTime);
        enemyShipSpotted = true;
        shipSpotted.gameObject.SetActive(true);
    }

    public static void FightShips()
    {
        if (enemyShipSpotted)
        {
            SceneManager.LoadScene("ShipFight");
        }
    }
}
