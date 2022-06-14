using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public InputAction playerControls;
    public bool canJump = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new InputAction();
        playerControls.Enable();
    }
    private void OnEnable(){
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }

    private void OnMove(InputValue value){
        moveDirection = value.Get<Vector2>();

        if(moveDirection.x > 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if(moveDirection.x < 0)
            transform.localScale = new Vector3(1f, 1f, 1f);

        Debug.Log(moveDirection);
    }
    public void Update(){
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    private void OnJump(){
        if(!canJump) return;
        canJump = false;
        rb.velocity = Vector2.up * jumpForce;
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        canJump = true;
    }
}
