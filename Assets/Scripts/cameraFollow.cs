using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform objToFollow = null;

    Vector3 objOffset;

    private void Awake()
    {
        objOffset = this.transform.position - objToFollow.position;
    }

    private void LateUpdate()
    {
        this.transform.position = objToFollow.position + objOffset;
    }
}
