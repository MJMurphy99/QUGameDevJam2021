using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFishAndObstacles : MonoBehaviour
{
    public List<GameObject> listOfFish;
    public float spawnFishTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnFishTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.goingUp == true)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            spawnFishTimer -= Time.deltaTime;
            if (spawnFishTimer < 0f)
            {
                Instantiate(listOfFish[0], new Vector3(Random.Range(-9, 9), -5, 0), Quaternion.identity);
                spawnFishTimer = 2f;
            }
        }
    }
}
