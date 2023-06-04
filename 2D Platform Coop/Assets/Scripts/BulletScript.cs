using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float bulletDamage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerAttributes>().DamagePlayer(bulletDamage);
            Destroy(gameObject);
        }
    }
}
