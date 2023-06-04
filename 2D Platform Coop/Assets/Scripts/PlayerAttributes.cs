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
    void Start()
    {
        InitPlayerHealthSlider();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealthUI();
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
        playerHealth -= damage;
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
}
