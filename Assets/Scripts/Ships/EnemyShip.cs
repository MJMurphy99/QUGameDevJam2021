using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "EnemyShip")]
public class EnemyShip : ScriptableObject
{
    public float moveSpeed, outerRadius, innerRadius, baseHealth, damage;
    public bool goingLeft, loadingAttack = false;
    public GameObject baseBody;
    public Slider healthBar; 

    private float currentHealth;
    private GameObject currentBody;
    private Image readyToAttack;

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
            readyToAttack = currentBody.transform.GetChild(0).GetChild(0).GetComponent<Image>();
            Debug.Log(readyToAttack);
        }
    }

    public IEnumerator Fire()
    {
        loadingAttack = true;
        float rand = Random.Range(3, 7);

        yield return new WaitForSeconds(rand);
        readyToAttack.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        readyToAttack.gameObject.SetActive(false);
        FindObjectOfType<Health>().DeductHealth(damage);
        loadingAttack = false;
    }
}
