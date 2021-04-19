using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "EnemyShip")]
public class EnemyShip : ScriptableObject
{
    public float moveSpeed, radius;
    public bool goingLeft;
    public GameObject baseBody;
}
