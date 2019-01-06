using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGroud;
    private bool grounded;
    private bool doubleJump;
    private float moveVelocity;
    private GameObject death;
    
    public static bool TurnRight = true;

    

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGroud);
    }

    void Update ()
    {
        #region 
        if (grounded)
        {
            doubleJump = false;
        }

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
        {
            Jump();
            doubleJump = true;
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
            TurnRight = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
            TurnRight = true;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

       
            #endregion
        }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }


    public class PlayerStats
    {
        public int hp = 3;
    }

    PlayerStats playerStats = new PlayerStats();
    public KillPlayer killPlayer;

    public void DamagePlayer(int damage)
    {
        playerStats.hp -= damage;
        Debug.Log(playerStats);
        if (playerStats.hp <= 0)
        {
            killPlayer = GameObject.FindObjectOfType(typeof(KillPlayer)) as KillPlayer;
            killPlayer.Kill();
        }
    }

    
    }

