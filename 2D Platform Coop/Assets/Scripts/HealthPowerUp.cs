using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] float additionalHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerAttributes>().AddPlayerHealth(additionalHealth);
            Destroy(gameObject);
        }
    }
}
