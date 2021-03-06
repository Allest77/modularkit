using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonMovement : MonoBehaviour {
    //Publics 
    public CharacterController controller;
    public BoxCollider playerCollider;
    public Transform cam;
    public float speed = 30.0f, turnSmoothTime = 0.1f, turnSmoothVelocity, threshold = 56, jumpHeight = 30.2f, jumpForce = 20, gravity = -20.0f;
    public bool isGrounded = true;

    //Privates
    Rigidbody rb;

    void Start() {
        //GetComponents
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        //Move horizontally.
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(hInput, 0.0f, vInput);
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed * turnSmoothTime * turnSmoothVelocity);
    }

    private void FixedUpdate() {
        //Jump input.
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.up) * jumpHeight * jumpForce);
            Debug.Log("Jumping");
        }
        else {
            if (Input.GetButtonUp("Jump") && !isGrounded) {
                GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.down) * gravity);
                Debug.Log("HOLY AAAAAAAHHHHHHHHHHHHHH-");
            }
        }
    }

    void OnCollisionEnter (Collision hit) {
        if (hit.gameObject.CompareTag("Wall")) {
            isGrounded = false;
        }
        else {
            isGrounded = true;
        }
    }
}
