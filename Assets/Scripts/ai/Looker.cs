using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{
    [SerializeField] GameObject _guard = null;
    
    float _reset = 5;
    bool _movingDown;
    
    void Update()
    {
        if(_movingDown == false)
        {
            transform.position -= new Vector3(0, 0, 0.01f);
        }
        else
        {
            transform.position += new Vector3(0, 0, 0.01f);
        }

        if(transform.position.z > 10)
        {
            _movingDown = false;
        }
        else if(transform.position.z < -10)
        {
            _movingDown = true;
        }

        _reset -= Time.deltaTime;

        if(_reset < 0)
        {
            _guard.GetComponent<Guard>().enabled = false;
            GetComponent<SphereCollider>().enabled = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer colliderMat = other.gameObject.GetComponent<MeshRenderer>();

        if (other.gameObject.CompareTag("Player"))
        {
            _guard.GetComponent<Guard>().enabled = true;
            _reset = 5;
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}