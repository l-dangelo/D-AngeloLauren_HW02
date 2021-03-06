﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupSpeed : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _speedChange = 20;
    [SerializeField] float _powerupLength = 5;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDisappear = null;
    [SerializeField] ParticleSystem _particles = null;

    [Header("Audio")]
    [SerializeField] AudioClip _winSound = null;
    [SerializeField] float _volume = 0;

    Collider _colliderToDisappear = null;
    bool _poweredUp = false;

    private void Awake()
    {
        _colliderToDisappear = GetComponent<Collider>();
        EnableObject();
        _particles.Pause();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip pShip = other.gameObject.GetComponent<PlayerShip>();

        if(pShip != null && _poweredUp == false)
        {
            StartCoroutine(PowerupSequence(pShip));
        }
    }

    IEnumerator PowerupSequence(PlayerShip pShip)
    {
        _poweredUp = true;

        ActivatePowerup(pShip);
        DisableObject();

        yield return new WaitForSeconds(_powerupLength);

        DeactivatePowerup(pShip);
        EnableObject();

        _poweredUp = false;
    }

    void ActivatePowerup(PlayerShip pShip)
    {
        _particles.Play();

        pShip?.SetSpeed(_speedChange);
        pShip?.SetBoosters(true);

        AudioHelper.PlayClip2D(_winSound, _volume);
    }

    void DeactivatePowerup(PlayerShip pShip)
    {
        pShip?.SetSpeed(-_speedChange);

        pShip?.SetBoosters(false);
    }

    void EnableObject()
    {
        _colliderToDisappear.enabled = true;

        _visualsToDisappear.SetActive(true);
    }

    void DisableObject()
    {
        _colliderToDisappear.enabled = false;

        _visualsToDisappear.SetActive(false);
    }
}