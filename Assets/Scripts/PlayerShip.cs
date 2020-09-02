using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float turnSpeed = 3f;

    [Header("Feedback")]
    [SerializeField] TrailRenderer tRail = null;
    [SerializeField] TrailRenderer tRail2 = null;

    Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        tRail.enabled = false;
        tRail2.enabled = false;
    }

    private void FixedUpdate()
    {
        moveShip();
        turnShip();
    }

    void moveShip()
    {
        float moveAmt = Input.GetAxisRaw("Vertical") * moveSpeed;
        Vector3 moveDir = transform.forward * moveAmt;
        rb.AddForce(moveDir);
    }

    void turnShip()
    {
        float turnAmt = Input.GetAxisRaw("Horizontal") * turnSpeed;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmt, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }

    public void kill()
    {
        Debug.Log("Player has been killed!");
        this.gameObject.SetActive(false);
    }

    public void SetSpeed(float speedChange)
    {
        moveSpeed += speedChange;
        //TODO a/v
    }

    public void SetBoosters(bool active)
    {
        tRail.enabled = active;
        tRail2.enabled = active;
    }
}
