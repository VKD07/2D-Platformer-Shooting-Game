using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] bool activateShield;
    [SerializeField] float shieldDuration;

    private void Update()
    {
        StartShield();
    }

    private void StartShield()
    {
        if(activateShield)
        {
            StartCoroutine(DisableShield());
        }
    }

    IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(shieldDuration);
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
