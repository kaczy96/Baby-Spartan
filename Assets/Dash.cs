using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    private Rigidbody2D rb;
    private bool facingRight = PlayerController.TurnRight;
    private int direction;
    public DashState dashState;
    public float dashTimer;
    public float maxDash = 20f;
    public float dashSpeed;

    public Vector2 savedVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                if (isDashKeyDown & PlayerController.TurnRight)
                {
                    savedVelocity = rb.velocity;
                    rb.velocity = new Vector2(rb.velocity.x * dashSpeed, rb.velocity.y);
                    dashState = DashState.Dashing;
                }
                else if (isDashKeyDown & !PlayerController.TurnRight)
                {
                    savedVelocity = rb.velocity;
                    rb.velocity = new Vector2(rb.velocity.x * -dashSpeed, rb.velocity.y);
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    rb.velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}


