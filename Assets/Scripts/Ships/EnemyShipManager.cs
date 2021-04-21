using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipManager : MonoBehaviour
{
    public EnemyShip ship;
    public int min, max;
    public int negX, posX, negY, posY;

    private List<EnemyShip>[] enemyShipsSObj;
    private List<GameObject>[] enemyShipsGObj;
    // Start is called before the first frame update
    void Start()
    {
        PlaceShips();
        Sharpshooter.GetShips(enemyShipsSObj, enemyShipsGObj);
    }

    // Update is called once per frame
    void Update()
    {
        MoveShips();
    }

    private void PlaceShips()
    {
        int randomNum = Random.Range(min, max);
        enemyShipsSObj = new List<EnemyShip>[posY - negY];
        enemyShipsGObj = new List<GameObject>[posY - negY];

        for(int i = 0; i < randomNum; i++)
        {
            Vector2 pos = new Vector2(Random.Range(negX, posX), Random.Range(negY, posY));
            int indexY = negY < 0 ? Mathf.Abs(negY) + (int)pos.y : (int)pos.y;

            if (enemyShipsSObj[indexY] == null)
            {
                enemyShipsSObj[indexY] = new List<EnemyShip>();
                enemyShipsGObj[indexY] = new List<GameObject>();
            }

            enemyShipsSObj[indexY].Add(Instantiate(ship));
            EnemyShip e = enemyShipsSObj[indexY][enemyShipsSObj[indexY].Count - 1];
            e.goingLeft = Random.Range(0, 2) == 0;

            e.CurrentBody = Instantiate(e.baseBody, pos, Quaternion.identity);
            enemyShipsGObj[indexY].Add(e.CurrentBody);
        }
    }

    private void MoveShips()
    {
        for(int i = 0; i < enemyShipsGObj.Length; i++)
        {
            if (enemyShipsGObj[i] == null) continue;

            for (int j = 0; j < enemyShipsGObj[i].Count; j++)
            {
                EnemyShip e = enemyShipsSObj[i][j];
                float magnitude = e.moveSpeed * Time.deltaTime * (e.goingLeft ? -1 : 1);
                enemyShipsGObj[i][j].transform.position += Vector3.right * magnitude;

                Vector2 pos = enemyShipsGObj[i][j].transform.position;
                if (pos.x < negX || pos.x > posX) e.goingLeft = !e.goingLeft;
            }
        }
    }
}
