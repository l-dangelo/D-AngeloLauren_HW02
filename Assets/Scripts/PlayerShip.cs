using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 3f;

    [Header("Feedback")]
    [SerializeField] TrailRenderer _tRail = null;
    [SerializeField] ParticleSystem _deathParts = null;

    Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        _tRail.enabled = false;
    }

    private void FixedUpdate()
    {
        moveShip();
        turnShip();
    }

    void moveShip()
    {
        float moveAmt = Input.GetAxisRaw("Vertical") * _moveSpeed;
        Vector3 moveDir = transform.forward * moveAmt;
        rb.AddForce(moveDir);
    }

    void turnShip()
    {
        float turnAmt = Input.GetAxisRaw("Horizontal") * _turnSpeed;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmt, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }

    public void kill()
    {
        Debug.Log("Player has been killed!");

        _deathParts.transform.position = this.transform.position;
        _deathParts.Play();

        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<MeshRenderer>().enabled = false;

        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2);

        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    public void SetSpeed(float speedChange)
    {
        _moveSpeed += speedChange;
    }

    public void SetBoosters(bool active)
    {
        _tRail.enabled = active;
    }
}