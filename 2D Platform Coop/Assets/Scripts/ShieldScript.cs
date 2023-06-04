using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] bool activateShield;
    [SerializeField] float shieldDuration;
    [SerializeField] GameObject shieldIndicator;

    private void Update()
    {
        StartShield();
    }

    private void StartShield()
    {
        if(activateShield)
        {
            shieldIndicator.SetActive(true);
            StartCoroutine(DisableShield());
        }
    }

    IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(shieldDuration);
        shieldIndicator.SetActive(false);
        activateShield = false;
    }

    public bool ShieldActivated()
    {
        return activateShield;
    }

    public void ActivateShield(bool activate)
    {
        activateShield = activate;
    }
}
