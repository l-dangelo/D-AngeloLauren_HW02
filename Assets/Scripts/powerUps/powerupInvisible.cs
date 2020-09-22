using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupInvisible : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _puLength = 5;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDisappear = null;
    [SerializeField] Material _originalMaterial = null;
    [SerializeField] Material _invisibleMaterial = null;
    [SerializeField] ParticleSystem _particles = null;

    [Header("Ship Parts to Disappear")]
    [SerializeField] GameObject _pShip = null;
    [SerializeField] GameObject[] _children = null;

    [Header("Audio")]
    [SerializeField] AudioClip _winSound = null;
    [SerializeField] float _volume = 0;

    Collider _colliderToDisappear = null;

    private void Awake()
    {
        _colliderToDisappear = GetComponent<Collider>();
        EnableObject();
        _particles.Pause();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(PowerupSequence());
    }
    
    IEnumerator PowerupSequence()
    {
        ActivatePowerUp();
        DisableObject();

        yield return new WaitForSeconds(_puLength);

        DeactivatePowerUp();
        EnableObject();
    }

    void ActivatePowerUp()
    {
        _particles.Play();
        _pShip.GetComponent<Collider>().enabled = false;

        AudioHelper.PlayClip2D(_winSound, _volume);

        foreach (GameObject childObj in _children)
        {
            childObj.GetComponent<MeshRenderer>().material = _invisibleMaterial;
        }
    }

    void DeactivatePowerUp()
    {
        _pShip.GetComponent<Collider>().enabled = true;
        foreach (GameObject childObj in _children)
        {
            childObj.GetComponent<MeshRenderer>().material = _originalMaterial;
        }
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