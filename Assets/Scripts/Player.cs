using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float jump;

    public Sprite spL, spR;

    private Vector2 _moveDirection;

    private bool onGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        InputManager.Init(this);
        InputManager.SetGameControls();
    }

    void Update()
    {
        transform.position += (Vector3)(_moveDirection * speed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            onGround = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().sprite = spL;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = spR;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    public void SetMovementDirection(Vector2 currentDirection)
    {
        _moveDirection = currentDirection;
    }
}
