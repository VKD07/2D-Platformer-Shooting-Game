
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] KeyCode shootingKey = KeyCode.LeftAlt;
    [SerializeField] float fireRate = 1.0f;
    [SerializeField] bool knockBack;
    [SerializeField] float knockBackForce = 5f;
    float currentFireTime;
    Rigidbody2D rb;

    [Header("Bullet Settings")]
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float numberOfBullets = 50f;
    [SerializeField] Slider ammoSlider;

    [Header("Animation")]
    [SerializeField] Animator gunAnim;
    [SerializeField] string shootingAnimName;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitAmmoSlider();
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }
    private void InitAmmoSlider()
    {
        ammoSlider.maxValue = numberOfBullets;
        ammoSlider.value = numberOfBullets;
    }

    /// <summary>
    /// Shooting is when you spawn an object from the player gun point after pressing a button
    /// the object will travel on a specific direction with a speed
    /// if the object collides with another object it will do something to that object collided
    /// </summary>
    public void Shooting()
    {
        if (Input.GetKey(shootingKey))
        {
            if (currentFireTime < fireRate && numberOfBullets > 0)
            {
                currentFireTime += Time.deltaTime;
            }
            else if(numberOfBullets <= 0)
            {
                gunAnim.SetBool(shootingAnimName, false);
                return;
            }else{
                //animation
                gunAnim.SetBool(shootingAnimName, true);
                currentFireTime = 0f;
                //spawning bullets
                GameObject bulletObj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.Euler(0, 0, 90f));
                //handles the ammo
                numberOfBullets--;
                //handles the Sllider UI;
                bulletObj.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.transform.right * bulletSpeed;
                KnockBackForce(bulletObj);
                Destroy(bulletObj, 3f);
            }
        }
        else if (Input.GetKeyUp(shootingKey))
        {
            gunAnim.SetBool(shootingAnimName, false);
            currentFireTime = 0f;
        }
        ammoSlider.value = numberOfBullets;
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

    public void AddBullets(float additionalBullet)
    {
        float totalBullet = numberOfBullets + additionalBullet;

        if(totalBullet > ammoSlider.maxValue)
        {
            numberOfBullets = ammoSlider.maxValue;
        }
        else
        {
            numberOfBullets += additionalBullet;
        }
    }
}
