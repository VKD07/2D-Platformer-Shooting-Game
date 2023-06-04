using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Gun SFX")]
    [SerializeField] AudioClip machineGun;
    [SerializeField] AudioClip heavyGun;

    [Header("Player SFX")]
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip pickUp;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #region GunShots
    public void PlayMachineGunShot(float volume)
    {
        audioSource.PlayOneShot(machineGun, volume);
    }

    public void PlayPowerBulletShot(float volume)
    {
        audioSource.PlayOneShot(heavyGun, volume);
    }
    #endregion

    #region PlayerSounds
    public void PlayJumpSound(float volume)
    {
        audioSource.PlayOneShot(jump, volume);
    }

    public void PlayPickUpSound(float volume)
    {
        audioSource.PlayOneShot(pickUp, volume);
    }
    #endregion
}
