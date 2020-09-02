using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupSpeed : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _goFAST = 20;
    [SerializeField] float _goFASTLength = 5;

    [Header("Setup")]
    [SerializeField] GameObject _visualsGoBye = null;

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

        ActivatePowerup(pShip);
        DisableObject();

        yield return new WaitForSeconds(_goFASTLength);

        DeactivatePowerup(pShip);
        EnableObject();

        _poweredUp = false;
    }

    void ActivatePowerup(PlayerShip pShip)
    {
            pShip?.SetSpeed(_goFAST);

            pShip?.SetBoosters(true);
    }

    void DeactivatePowerup(PlayerShip pShip)
    {
        pShip?.SetSpeed(-_goFAST);

        pShip?.SetBoosters(false);
    }

    void DisableObject()
    {
        _colliderGoBye.enabled = false;

        _visualsGoBye.SetActive(false);

        //TODO particle flash/audio
    }

    void EnableObject()
    {
        _colliderGoBye.enabled = true;

        _visualsGoBye.SetActive(true);

        //TODO particle flash/audio
    }
}
