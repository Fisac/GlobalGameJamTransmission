using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string horizontalJoystick;
    public string verticalJoystick;
    private float moveSpeed = 10f;
    public GameObject hitWall;
    private bool hitWallCD;

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(horizontalJoystick);
        float moveVertical = Input.GetAxis(verticalJoystick);

        Vector3 dir = new Vector3(moveHorizontal, moveVertical, 0f);

        transform.position += dir.normalized * moveSpeed * Time.fixedDeltaTime;

        if (transform.position.x > 15f)
            transform.position = new Vector3(15f, transform.position.y, 0f);
        else if (transform.position.x < -15f)
            transform.position = new Vector3(-15f, transform.position.y, 0f);
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
}
