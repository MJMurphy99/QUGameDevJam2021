using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFishAndObstacles : MonoBehaviour
{
    public GameObject allOfTheFish;
    public List<GameObject> listOfFish;
    public float spawnFishTimer, depthTimer, respawnFishTimeSet;
    public float fishDepthSpawnLevel1, fishDepthSpawnLevel2, fishDepthSpawnLevel3, fishDepthSpawnLevel4, fishDepthSpawnLevel5;

    // Update is called once per frame
    void Update()
    {
        depthTimer += Time.deltaTime;
        spawnFishTimer -= Time.deltaTime;

        if (depthTimer < fishDepthSpawnLevel1)
        {
            if (spawnFishTimer < 0f)
            {
                GameObject g = Instantiate(listOfFish[Random.Range(0,2)], new Vector3(Random.Range(-9, 9), -5, 0), Quaternion.identity);
                g.transform.SetParent(allOfTheFish.transform);
                spawnFishTimer = respawnFishTimeSet;
            }
        } else if (depthTimer >= fishDepthSpawnLevel1 && depthTimer < fishDepthSpawnLevel2)
        {
            if (spawnFishTimer < 0f)
            {
                GameObject g = Instantiate(listOfFish[Random.Range(0, 3)], new Vector3(Random.Range(-9, 9), -5, 0), Quaternion.identity);
                g.transform.SetParent(allOfTheFish.transform);
                spawnFishTimer = respawnFishTimeSet;
            }
        }
        else if (depthTimer >= fishDepthSpawnLevel2 && depthTimer < fishDepthSpawnLevel3)
        {
            if (spawnFishTimer < 0f)
            {
                GameObject g = Instantiate(listOfFish[Random.Range(2, 4)], new Vector3(Random.Range(-9, 9), -5, 0), Quaternion.identity);
                g.transform.SetParent(allOfTheFish.transform);
                spawnFishTimer = respawnFishTimeSet;
            }
        }
        else if (depthTimer >= fishDepthSpawnLevel3 && depthTimer < fishDepthSpawnLevel4)
        {
            if (spawnFishTimer < 0f)
            {
                GameObject g = Instantiate(listOfFish[Random.Range(3, 4)], new Vector3(Random.Range(-9, 9), -5, 0), Quaternion.identity);
                g.transform.SetParent(allOfTheFish.transform);
                spawnFishTimer = respawnFishTimeSet;
            }
        }
        else if (depthTimer >= fishDepthSpawnLevel4 && depthTimer < fishDepthSpawnLevel5)
        {
            if (spawnFishTimer < 0f)
            {
                GameObject g = Instantiate(listOfFish[Random.Range(3, 5)], new Vector3(Random.Range(-9, 9), -5, 0), Quaternion.identity);
                g.transform.SetParent(allOfTheFish.transform);
                spawnFishTimer = respawnFishTimeSet;
            }
        }
        else if (depthTimer > fishDepthSpawnLevel2)
        {
            if (spawnFishTimer < 0f)
            {
                GameObject g = Instantiate(listOfFish[Random.Range(3, 6)], new Vector3(Random.Range(-9, 9), -5, 0), Quaternion.identity);
                g.transform.SetParent(allOfTheFish.transform);
                spawnFishTimer = respawnFishTimeSet;
            }
        }
    }
}
