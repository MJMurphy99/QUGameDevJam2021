using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShipManager : MonoBehaviour
{
    public EnemyShip ship;
    public int min, max;
    public int negX, posX, negY, posY;

    private List<EnemyShip> enemyShipsSObj;
    // Start is called before the first frame update
    void Start()
    {
        PlaceShips();
        Sharpshooter.GetShips(enemyShipsSObj);
    }

    // Update is called once per frame
    void Update()
    {
        MoveShips();
    }

    private void PlaceShips()
    {
        int randomNum = Random.Range(min, max);
        enemyShipsSObj = new List<EnemyShip>();
        for(int i = 0; i < randomNum; i++)
        {
            Vector2 pos = new Vector2(Random.Range(negX, posX), Random.Range(negY, posY));
            int indexY = negY < 0 ? Mathf.Abs(negY) + (int)pos.y : (int)pos.y;

            enemyShipsSObj.Add(Instantiate(ship));
            EnemyShip e = enemyShipsSObj[i];
            e.goingLeft = Random.Range(0, 2) == 0;

            e.CurrentBody = Instantiate(e.baseBody, pos, Quaternion.identity);
            e.CurrentBody.GetComponent<SpriteRenderer>().flipX = !e.goingLeft;
        }
    }

    private void MoveShips()
    {
        int dead = 0;
        for(int i = 0; i < enemyShipsSObj.Count; i++)
        {
            if (enemyShipsSObj[i] == null)
                continue;

            EnemyShip e = enemyShipsSObj[i];
            float magnitude = e.moveSpeed * Time.deltaTime * (e.goingLeft ? -1 : 1);
            enemyShipsSObj[i].CurrentBody.transform.position += Vector3.right * magnitude;

            Vector2 pos = enemyShipsSObj[i].CurrentBody.transform.position;
            if (pos.x < negX || pos.x > posX)
            {
                e.goingLeft = !e.goingLeft;
                e.CurrentBody.GetComponent<SpriteRenderer>().flipX = !e.goingLeft;
            }

            if (!e.loadingAttack) StartCoroutine(e.Fire());
        }
        if(dead == enemyShipsSObj.Count) ReturnToLookOut();
    }

    private void ReturnToLookOut()
    {
        SceneManager.LoadScene("Fishing");
    }
}
