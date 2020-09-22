using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winVolume : MonoBehaviour
{
    [SerializeField] GameObject _winText = null;
    //[SerializeField] GameObject _visualsToDisappear = null;
    [SerializeField] ParticleSystem _winParts = null;

    [Header("Audio")]
    [SerializeField] AudioClip _winSound = null;
    [SerializeField] float _volume = 0;

    private void Awake()
    {
        _winParts.Pause();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _winText.SetActive(true);
            this.GetComponent<MeshRenderer>().enabled = false;

            _winParts.Play();
            AudioHelper.PlayClip2D(_winSound, _volume);
        }
    }
}
