using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terresquall;

public class Movement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = new Vector2(VirtualJoystick.GetAxis("Horizontal"), VirtualJoystick.GetAxis("Vertical"));
        moveVelocity = movementInput.normalized * speed;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }
}
