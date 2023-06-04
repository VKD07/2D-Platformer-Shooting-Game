using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] ShieldScript shieldScript;
    void Start()
    {
        InitPlayerHealthSlider();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealthUI();
        DeathHandler();
    }
    private void InitPlayerHealthSlider()
    {
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = playerHealth;
    }

    private void UpdatePlayerHealthUI()
    {
        playerHealthSlider.value = playerHealth;
    }

    public void DamagePlayer(float damage)
    {
        if (!shieldScript.ShieldActivated())
        {
            playerHealth -= damage;
        }
    }

    public void AddPlayerHealth(float addHealth)
    {
        float totalHealth = addHealth + playerHealth;

        if (totalHealth > playerHealthSlider.maxValue)
        {
            playerHealth = playerHealthSlider.maxValue;
        }
        else
        {
            playerHealth += addHealth;
        }
    }

    private void DeathHandler()
    {
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
