using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupInvisible : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _puLength = 5;
    [SerializeField] float _howInvisible = 0;

    [Header("Setup")]
    [SerializeField] GameObject __visualsToDisappear = null;
    [SerializeField] AudioSource _powerUpSound = null;
    [SerializeField] AudioSource _powerDownSound = null;

    [Header("Ship Parts to Disappear")]
    [SerializeField] GameObject[] children = null;

    Collider _colliderToDisappear = null;

    private void Awake()
    {
        _colliderToDisappear = GetComponent<Collider>();
        EnableObject();
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
        foreach (GameObject childObj in children)
        {
            MeshRenderer childRender = childObj.GetComponent<MeshRenderer>();
            Color childColor = childRender.material.color;
            childColor.a = _howInvisible;
            childRender.material.color = childColor;
        }

        _powerUpSound.Play();
    }

    void DeactivatePowerUp()
    {
        foreach (GameObject childObj in children)
        {
            MeshRenderer childRender = childObj.GetComponent<MeshRenderer>();
            Color childColor = childRender.material.color;
            childColor.a = 1;
            childRender.material.color = childColor;
        }

        _powerDownSound.Play();
    }

    void EnableObject()
    {
        _colliderToDisappear.enabled = true;

        __visualsToDisappear.SetActive(true);
    }

    void DisableObject()
    {
        _colliderToDisappear.enabled = false;

        __visualsToDisappear.SetActive(false);
    }
}