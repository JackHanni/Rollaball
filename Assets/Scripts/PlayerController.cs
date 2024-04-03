using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    private int count;
    public GameObject winTextObject;
    public float jumpSpeed;
    private int nJumps = 0;
    private bool isJump = false;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        isGrounded = true;
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 6)
        {
            winTextObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (isGrounded)
        {
            nJumps = 0;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || nJumps == 1)
            {
                isJump = true;
                nJumps += 1;
                isGrounded = false;
            }
        }
        if (isJump)
        {
            rb.velocity += new Vector3(0,jumpSpeed,0);
            isJump = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f,movementY)*speed;
        rb.AddForce(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
/*
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
*/
}
