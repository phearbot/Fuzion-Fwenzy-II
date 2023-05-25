using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerState state;
    public float crouchDuration;
    float crouchTimer = 0;


    public float jumpDuration;
    float jumpTimer = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		HandleInput();

		if (state == PlayerState.Crouching)
            HandleCrouch();
        else if (state == PlayerState.Jumping)
            HandleJump();
    }

    void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && state == PlayerState.Idle) 
        {
            print("jumping, yo");
			state = PlayerState.Jumping;
		}

        if (Input.GetButtonDown("Crouch") && state == PlayerState.Idle)
        {
			print("crouching for " + crouchDuration + " seconds!");
            state = PlayerState.Crouching;

            // replace this with a crouching animation
            transform.localScale = new Vector3(1, .7f, 1);
		}
    }

    void HandleCrouch()
    {
        crouchTimer += Time.deltaTime;

        if (crouchTimer > crouchDuration)
        {
            state = PlayerState.Idle;
			crouchTimer = 0; 
            transform.localScale = Vector3.one;

            print("done crouching, boss");
		}
    }

    void HandleJump()
    {
		jumpTimer += Time.deltaTime;

		if (jumpTimer > jumpDuration)
		{
			state = PlayerState.Idle;
			jumpTimer = 0;

			print("done jumping, boss");
		}
        
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Obstacle")
        {
            // player is hit
        }
	}

    void GetHit()
    {

    }

	enum PlayerState
    {
        Idle, Jumping, Crouching
    }
}
