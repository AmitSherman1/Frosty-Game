using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform leftWall;
    public Transform rightWall;
    public Transform bottomWall;

    private float moveSpeed = 10.0f;
    private Vector2 moveDirection = Vector2.zero;

    private Rigidbody2D rb;

    private InputChannel inputChannel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disabling gravity

        var beacon = FindObjectOfType<BeaconSO>();
        if (beacon == null)
        {
            Debug.LogError("BeaconSO not found!");
            return;
        }

        inputChannel = beacon.inputChannel;
        if (inputChannel == null)
        {
            Debug.LogError("InputChannel not found in BeaconSO!");
            return;
        }

        inputChannel.MoveEvent += HandleMovement;
    }

    void Update()
    {
        // Typically, physics-related movement should be done in FixedUpdate.
        // However, since we're setting the velocity based on input, which is generally checked per frame,
        // it's usually okay to do this in Update if the input event is frame-based.
    }

    public void HandleMovement(Vector2 moveDirection)
    {
        rb.velocity = moveDirection * moveSpeed;
    }
}