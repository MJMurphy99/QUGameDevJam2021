using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float baseHealth, currentHealth;
    public Slider healthBar;
    public TextMeshProUGUI healthLabel;
    public Image redTinge;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = baseHealth;
        healthBar.value = 1;
        healthLabel.text = currentHealth + " / " + baseHealth;
    }

    public void DeductHealth(float dmg)
    {
        currentHealth -= dmg;
        healthBar.value = currentHealth / baseHealth;
        healthLabel.text = currentHealth + " / " + baseHealth;
        float alpha = 1 - (currentHealth / baseHealth);
        redTinge.color = new Color(1, 0, 0, alpha);

        if (currentHealth <= 0) Dead();
    }

    public void Dead()
    {
        for (int i = 1; i < GlobalControl.fish.Length; i++)
            GlobalControl.fish[i] = 0;

        SceneManager.LoadScene("Fishing");
    }
}
