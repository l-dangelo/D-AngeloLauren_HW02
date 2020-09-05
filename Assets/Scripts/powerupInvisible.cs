using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupInvisible : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _howInvisible = 0;/*0-255 or 0-100?*/
    [SerializeField] float _puLength = 5;

    [Header("Setup")]
    [SerializeField] GameObject _visualsGoBye = null;

    [Header("Ship Parts to Disappear")]
    [SerializeField] GameObject[] children = null;

    Collider _colliderGoBye = null;
    bool _poweredUp = false;

    private void Awake()
    {
        _colliderGoBye = GetComponent<Collider>();
        EnableObject();
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

        ActivatePowerUp(pShip);
        DisableObject();

        yield return new WaitForSeconds(_puLength);

        DeactivatePowerUp(pShip);
        EnableObject();

        _poweredUp = false;
    }

    void ActivatePowerUp(PlayerShip pShip)
    {
        Transform pship = gameObject.transform;

        foreach (Transform child in pship)
        {
            GameObject childObj = child.gameObject;
            MeshRenderer childRenderer = childObj.GetComponent<MeshRenderer>();

            Color childColor = childRenderer.material.color;
            childColor.a = _howInvisible;
            childRenderer.material.color = childColor;
        }
    }

    void DeactivatePowerUp(PlayerShip pShip)
    {
        Transform pship = gameObject.transform;

        foreach (Transform child in pship)
        {
            GameObject childObj = child.gameObject;
            MeshRenderer childRenderer = childObj.GetComponent<MeshRenderer>();

            Color childColor = childRenderer.material.color;
            childColor.a = 255;
            childRenderer.material.color = childColor;
        }
    }

    void EnableObject()
    {
        _colliderGoBye.enabled = true;

        _visualsGoBye.SetActive(true);
    }

    void DisableObject()
    {
        _colliderGoBye.enabled = false;

        _visualsGoBye.SetActive(false);
    }
}