using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    private KeyCode forward;
    private KeyCode backward;
    private KeyCode left;
    private KeyCode right;
    private KeyCode jump;

    private Rigidbody rb;

    private float runSpeed;
    private float jumpHeight;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        
        
        forward = KeyCode.W;
        backward = KeyCode.S;
        left = KeyCode.A;
        right = KeyCode.D;
        jump = KeyCode.Space;

        runSpeed = 10.0f;
        jumpHeight = 100.0f;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(forward))
        {
            rb.AddForce(transform.forward * runSpeed);
        }
        if (Input.GetKey(backward))
        {
            rb.AddForce(-transform.forward * runSpeed);
        }
        if (Input.GetKey(left))
        {
            rb.AddForce(-transform.right * runSpeed);
        }
        if (Input.GetKey(right))
        {
            rb.AddForce(transform.right * runSpeed);
        }
        if (Input.GetKeyDown(jump))
        {
            rb.AddForce(transform.up * jumpHeight);
        }
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
