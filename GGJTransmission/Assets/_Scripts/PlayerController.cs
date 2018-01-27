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

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        float moveHorizontal = Input.GetAxis(horizontalJoystick);
        float moveVertical = Input.GetAxis(verticalJoystick);

        Vector3 dir = new Vector3(moveHorizontal, moveVertical, 0f);

        float dash = 1;

        if (gameObject.name == "Player 1")
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                dash = 5f;
                dashCD = true;
                Invoke("DashCooldown", 1f);
            }
        }

        if (gameObject.name == "Player 2")
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button10))
            {
                dash = 5f;
                dashCD = true;
                Invoke("DashCooldown", 1f);
            }
        }

        transform.position += dir.normalized * moveSpeed * dash * Time.fixedDeltaTime;
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

    private void HitWallCooldown()
    {
        hitWallCD = false;
    }

    private void DashCooldown()
    {
        dashCD = false;
    }
}
