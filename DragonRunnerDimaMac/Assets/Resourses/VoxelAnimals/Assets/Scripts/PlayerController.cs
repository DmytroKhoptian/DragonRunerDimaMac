using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private float timeBeforeNextJump = 1.2f;
    private float canJump;

    Animator anim;
    Rigidbody rb;
    Vector3 movement;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControllPlayer();
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * Time.deltaTime * movementSpeed);
    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); //-1 0 1
        movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        if (movement != Vector3.zero)
        {
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            anim.SetTrigger("jump");
        }
    }
}