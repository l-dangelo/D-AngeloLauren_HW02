using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField] float _time = 50;

    void Update()
    {
        transform.RotateAround(this.transform.position, Vector3.up, _time * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShip pship = other.gameObject.GetComponent<PlayerShip>();
            pship.kill();
        }
    }
}