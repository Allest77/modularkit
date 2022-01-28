using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonMovement : MonoBehaviour {
    public CharacterController controller;
    public Rigidbody rb;
    public BoxCollider playerCollider;
    public Transform cam;
    public float speed = 7.0f, turnSmoothTime = 0.1f, turnSmoothVelocity, jumpForce = 4, threshold = 56;

    void Update() {
        //Movement
        float horziontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = (transform.right * horziontal) + (transform.forward * vertical);

        controller.Move(direction * speed * Time.deltaTime);
    }
}
