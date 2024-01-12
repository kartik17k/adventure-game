using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    PlayerController controller;
    float direction = 0f;
    public int speed = 250;
    public float jumpForce = 5;
    bool isGrounded;
    int NoOfJumps = 0;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D playerRB;
    public Animator animator;
    public bool isFacingRight = true;


    private void Awake()
    {
        controller = new PlayerController();  // to acess playercontroller script 
        controller.Enable();   // to enable all functions


        controller.land.move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();  // ctx returns the button pressed value like A or D or LEFT or RIGHT
        };

        controller.land.jump.performed += ctx => Jump();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded" , isGrounded);
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0) {
            Flip();  // <0 means  - means left
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            NoOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            AudioManager.instance.Play("firstJump");
            NoOfJumps++;
        }
        else
        {
            if(NoOfJumps == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                AudioManager.instance.Play("secondJump");
                NoOfJumps++;
            }
        }

    }
}
