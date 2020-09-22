using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] GameObject _connectedTP = null;
    [SerializeField] ParticleSystem _connectParticles = null;

    [Header("Audio")]
    [SerializeField] AudioClip _winSound = null;
    [SerializeField] float _volume = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Vector3 pos = new Vector3(_connectedTP.transform.position.x + 5,
                _connectedTP.transform.position.y, _connectedTP.transform.position.z + 5);

            AudioHelper.PlayClip2D(_winSound, _volume);

            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            other.transform.position = pos;

            _connectParticles.Play();
        }
    }
}