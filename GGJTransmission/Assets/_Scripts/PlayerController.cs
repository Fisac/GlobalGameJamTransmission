using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string horizontalJoystick;
    public string verticalJoystick;
    private float moveSpeed = 5f;
    public GameObject hitWall;
    private bool hitWallCD;
    private bool dashCD;
    private Vector3 dir;

    private Animator anim;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(rb.IsSleeping ())
        {
            rb.WakeUp();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw(horizontalJoystick);
        float moveVertical = Input.GetAxisRaw(verticalJoystick);

        dir = new Vector3(moveHorizontal, moveVertical, 0f);

        transform.position += dir.normalized * moveSpeed * Time.fixedDeltaTime;

        if (moveHorizontal > .9f)
        {
            anim.Play("RightMovement");
        }
        else if (moveVertical > .9f)
        {
            anim.Play("VerticalMovement");
        }
        else if (moveHorizontal < -.9f)
        {
            anim.Play("LeftMovement");
        }
        else if (moveVertical < -.9f)
        {
            anim.Play("VerticalMovement_Down");
        }
        else
        {
            anim.Play("Anim_Player1_Idle");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            if (!hitWallCD)
            {
                GameObject newHitWall = Instantiate(hitWall, transform.position, Quaternion.identity);
                Destroy(newHitWall, 1f);
                hitWallCD = true;
                Invoke("HitWallCooldown", .25f);
            }
        }
    }

    private void LateUpdate()
    {
        if (!dashCD)
        {
            if (gameObject.name == "Player 1")
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button4))
                {
                    moveSpeed = 20f;
                    dashCD = true;
                    Invoke("ResetMoveSpeed", .25f);
                    Invoke("DashCooldown", 3f);
                }
            }

            if (gameObject.name == "Player 2")
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button5))
                {
                    moveSpeed = 20f;
                    dashCD = true;
                    Invoke("ResetMoveSpeed", .25f);
                    Invoke("DashCooldown", 3f);
                }
            }
        }
    }

    private void HitWallCooldown()
    {
        hitWallCD = false;
    }

    private void ResetMoveSpeed()
    {
        moveSpeed = 5f;
    }

    private void DashCooldown()
    {
        dashCD = false;
    }
}
