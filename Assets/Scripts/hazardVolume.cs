using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardVolume : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip _sound = null;
    [SerializeField] float _volume = 0;

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playShip = other.gameObject.GetComponent<PlayerShip>();

        if(playShip != null && other.CompareTag("Player"))
        {
            playShip.kill();
            AudioHelper.PlayClip2D(_sound, _volume);
        }
    }
}