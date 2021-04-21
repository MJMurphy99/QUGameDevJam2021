using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "EnemyShip")]
public class EnemyShip : ScriptableObject
{
    public float moveSpeed, outerRadius, innerRadius, baseHealth;
    public bool goingLeft;
    public GameObject baseBody;
    public Slider healthBar; 

    private float currentHealth;
    private GameObject currentBody;

    public void Awake()
    {
        currentHealth = baseHealth;
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            healthBar.value = currentHealth / baseHealth;
        }
    }

    public GameObject CurrentBody
    {
        get { return currentBody; }
        set
        {
            currentBody = value;
            healthBar = currentBody.GetComponentInChildren<Slider>();
        }
    }
}
