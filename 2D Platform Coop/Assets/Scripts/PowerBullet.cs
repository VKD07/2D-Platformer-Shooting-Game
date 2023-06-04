using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBullet : MonoBehaviour
{
    [SerializeField] GameObject powerBullet;
    [SerializeField] bool bulletAvailable;
    [SerializeField] float numberOfBullets = 0;
    [SerializeField] float bulletSpeed = 80f;
    [SerializeField] ShootingScript shootingScript;
    [SerializeField] PlayerMovementScript playerMovementScript;
    [SerializeField] GameObject powerBulletIndicator;
    [Header("KnockBack Force")]
    [SerializeField] bool knockBack = true;
    [SerializeField] float knockBackForce = 20f;
    bool bulletAdded;
    Rigidbody2D rb;

    [Header("SFX")]
    [SerializeField] PlayerSfx playerSfx;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSfx = GetComponent<PlayerSfx>();
    }
    void Update()
    {
        ShootPowerBullet();
    }

    private void ShootPowerBullet()
    {
        if (bulletAvailable)
        {
            powerBulletIndicator.SetActive(true);
            if (!bulletAdded)
            {
                bulletAdded = true;
                numberOfBullets = 2;
            }

            shootingScript.enabled = false;

            if (Input.GetKeyDown(shootingScript.shootingKey))
            {
                playerMovementScript.enabled = false;
                if (numberOfBullets > 0)
                {
                    ReleasePowerBullet();
                }

                numberOfBullets--;
            }

            if (numberOfBullets <= 0)
            {
                powerBulletIndicator.SetActive(false);
                bulletAdded = false;
                bulletAvailable = false;
                StartCoroutine(EnableShooting(0.3f));
            }
        }

        if (Input.GetKeyUp(shootingScript.shootingKey))
        {
            playerMovementScript.enabled = true;
        }
    }

    private void ReleasePowerBullet()
    {
        GameObject powerBulletObj = Instantiate(powerBullet, shootingScript.bulletSpawnPoint.position, Quaternion.Euler(0, 0, -90f));
        powerBulletObj.GetComponent<Rigidbody2D>().velocity = shootingScript.bulletSpawnPoint.transform.right * bulletSpeed;
        KnockBackForce(powerBulletObj);
        Destroy(powerBulletObj, 5f);
        //sfx
        playerSfx.PlayPowerBulletShot(0.5f);
    }

    void KnockBackForce(GameObject bulletObj)
    {
        if (knockBack)
        {
            var knockBackDirection = transform.position - bulletObj.transform.position;
            knockBackDirection.Normalize();
            rb.AddForce(knockBackDirection * knockBackForce, ForceMode2D.Impulse);
        }
    }

    IEnumerator EnableShooting(float delay)
    {
        yield return new WaitForSeconds(delay);
        shootingScript.enabled = true;
    }

    public void EnablePowerBullet(bool enable)
    {
        bulletAvailable = enable;
    }
}
