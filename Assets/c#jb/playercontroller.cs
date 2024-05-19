using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float runSpead;
    public float jumpSpead;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Filp();
        Jump();
        CheckGrounded();
    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(isGround);
    }
    void Filp()
    {
        bool playerhasxaxisspeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerhasxaxisspeed)
        {
            if(myRigidbody.velocity.x>0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
     }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(isGround)
            {
                Vector2 jumpvel = new Vector2(0.0f, jumpSpead);
                myRigidbody.velocity = Vector2.up * jumpvel;
            }
        }
    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpead,myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        bool playerhasxaixsspeed = Math.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("run", playerhasxaixsspeed);
    }
}
