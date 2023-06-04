using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour
{
    [SerializeField] float additionalBullet;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ShootingScript>().AddBullets(additionalBullet);
            Destroy(gameObject);
        }
    }
}
