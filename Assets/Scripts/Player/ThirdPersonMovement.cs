using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    Animator animator;
    public CharacterController controller;
    Camera cam;

    public ToolbarObject toolbar;

    public float speed;
    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask, WhatIsGround;

    Vector3 velocity;
    bool isGrounded;

    Vector3 moveDir = Vector3.zero;

    //Start
    void Start()
    {
        speed = walkSpeed;
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }

    //Update
    void Update()
    {
        HandleMovement();
        GetInput();
    }

    //Movement
    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(velocity * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        //Walk
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            if (animator.GetBool("Attacking") == true)
            {
                return;
            }
            else if(animator.GetBool("Attacking") == false)
            {
                animator.SetBool("Moving", true);
                animator.SetInteger("Condition", 1);
                controller.Move(move * speed * Time.deltaTime);

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
                {
                    if (StaminaBar.instance.currentStamina > 1)
                    {
                        animator.SetBool("Moving", true);
                        animator.SetInteger("Condition", 2);
                        speed = sprintSpeed;
                        StaminaBar.instance.UseStamina(0.2f);
                        controller.Move(move * speed * Time.deltaTime);
                    }
                }
            }
        }

        //Backwards Animation
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("Condition", 3);
        }

        //Left Strafe Animation
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("Condition", 4);
        }

        //Right Strafe Animation
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("Condition", 5);
        }

        //Stop Moving & Move Animations
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Moving", false);
            animator.SetInteger("Condition", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        //Jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Jump();
        }
    }

    //Handle Mouse Input For Attacking
    void GetInput()
    {
        if (controller.isGrounded)
        {
            if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if(animator.GetBool("Moving") == true)
                {
                    animator.SetBool("Moving", false);
                    animator.SetInteger("Condition", 0);
                }
                if (animator.GetBool("Moving") == false && Input.GetMouseButtonDown(0))
                {
                    RangedAttack();
                }
                if (animator.GetBool("Moving") == false && Input.GetMouseButtonDown(1))
                {
                    MeleeAttack();
                }
            }
        }
    }

    //Melee Attack
    void MeleeAttack()
    {
        StartCoroutine(FinishMeleeAttack());
    }

    //Ranged Attack
    void RangedAttack()
    {
        StartCoroutine(FinishRangedAttack());
    }

    //Jump Animation Coroutine
    void Jump()
    {
        StartCoroutine(FinishJump());
    }

    //Jump Animation
    IEnumerator FinishJump()
    {
        animator.SetInteger("Condition", 6);
        yield return new WaitForSeconds(0.1f);
        animator.SetInteger("Condition", 0);
    }

    //Melee Animation
    IEnumerator FinishMeleeAttack()
    {
        animator.SetBool("Attacking", true);
        animator.SetInteger("Condition", 8);
        yield return new WaitForSeconds(0.2f);
        animator.SetInteger("Condition", 0);
        animator.SetBool("Attacking", false);
    }

    //Ranged Animation
    IEnumerator FinishRangedAttack()
    {
        animator.SetBool("Attacking", true);
        animator.SetInteger("Condition", 9);
        yield return new WaitForSeconds(1);
        animator.SetInteger("Condition", 0);
        animator.SetBool("Attacking", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();

        if (item)
        {
            toolbar.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
}