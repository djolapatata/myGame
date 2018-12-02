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
    private float airSpeed;
    private float jumpHeight;
    private float maxSpeed;
    private float straightLineSpeed;
    private bool grounded = true;
    private bool canJump = true;

    private GameObject playerCam;

    // Use this for initialization
    void Start () {
        playerCam = GameObject.FindGameObjectsWithTag("playerCam")[0];
        rb = GetComponent<Rigidbody>();
        
        
        forward = KeyCode.W;
        backward = KeyCode.S;
        left = KeyCode.A;
        right = KeyCode.D;
        jump = KeyCode.Space;

        runSpeed = 10.0f;
        airSpeed = 2f;
        jumpHeight = 5f;

        maxSpeed = 10f;
    }

    private void FixedUpdate()
    {

        straightLineSpeed = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2));
        grounded = isGrounded();
        canJump = ableToJump();
        Debug.Log(isGrounded());

        if (Input.GetKey(forward) && straightLineSpeed <= maxSpeed && grounded)
        {
            rb.AddForce(transform.forward * runSpeed);
        }
        if (Input.GetKey(forward) && !grounded)
        {
            rb.AddForce(transform.forward * airSpeed);
        }
        if (Input.GetKey(backward) && straightLineSpeed <= maxSpeed && grounded)
        {
            rb.AddForce(-transform.forward * runSpeed);
        }
        if (Input.GetKey(backward) && !grounded)
        {
            rb.AddForce(-transform.forward * airSpeed);
        }
        if (Input.GetKey(left) && straightLineSpeed <= maxSpeed && grounded)
        {
            rb.AddForce(-transform.right * runSpeed);
        }
        if (Input.GetKey(left) && !grounded)
        {
            rb.AddForce(-transform.right * airSpeed);
        }
        if (Input.GetKey(right) && straightLineSpeed <= maxSpeed && grounded)
        {
            rb.AddForce(transform.right * runSpeed);
        }
        if (Input.GetKey(right) && !grounded)
        {
            rb.AddForce(transform.right * airSpeed);
        }
        if (Input.GetKey(jump) && canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, playerCam.GetComponent<cameraMovement>().getCameraHorAxis(), transform.eulerAngles.z);
        Debug.Log(straightLineSpeed);
        // Debug.Log(rb.OnCollisionEnter)
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, rb.GetComponent<Collider>().bounds.extents.y + 0.1f);
    }

    bool ableToJump()
    {
        return isGrounded();
    }

}


