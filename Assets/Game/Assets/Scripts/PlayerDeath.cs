using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerDeath : MonoBehaviour
{
    public float PlayerHealth = 100;
    public TextMeshProUGUI healthText;

    public float recentlyDamaged = 3.0f;
    public float delayRemaining;

    public Blood bloodReference;
    void Start()
    {
        
    }

    private void UpdateUI()
    {
        healthText.text = ((int)PlayerHealth).ToString();
    }
    public void TakeDamage(float damage)
    {
        PlayerHealth -= damage;
        delayRemaining = recentlyDamaged;
        UpdateUI();
        bloodReference.damageTaken();
        if (PlayerHealth <= 20)
        {
            healthText.color = new Color(255, 0, 0, 255);
        }
    }
    void Update()
    {
        if (PlayerHealth <= 0)
        {
            SceneManager.LoadScene("Credits");
        }
        if (delayRemaining <= 0 && PlayerHealth <= 100)
        {
            PlayerHealth += Time.deltaTime * 10;
            UpdateUI();
            if (PlayerHealth > 20)
            {
                healthText.color = new Color(255, 255, 255, 255);
            }
        }
        else
        {
            delayRemaining -= Time.deltaTime;
        }

        if (PlayerHealth > 100)
        {
            PlayerHealth = 100;
        }
    }
}
