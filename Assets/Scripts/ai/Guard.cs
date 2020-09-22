using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    [SerializeField] PlayerShip _playerShip = null;

    NavMeshAgent _navMesh;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMesh.destination = _playerShip.transform.position;
    }
}