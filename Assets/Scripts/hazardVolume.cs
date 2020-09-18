using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playShip = other.gameObject.GetComponent<PlayerShip>();

        if(playShip != null)
        {
            playShip.kill();
        }
    }
}