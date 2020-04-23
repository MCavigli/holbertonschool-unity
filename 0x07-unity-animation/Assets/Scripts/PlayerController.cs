using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	float speed = 12f;
	float jump = 2f;
	float gravity = -20f;
	float airControl = 5f;
	float turnSpeed = 200f;
	Vector3 moveDirection = Vector3.zero;
	CharacterController cc;
	Transform pos;
	Animator anim;
	// Vector3 velocity;

	void Start()
	{
		cc = GetComponent<CharacterController>();
		pos = GetComponent<Transform>();
		anim = transform.GetChild(0).GetComponent<Animator>();
	}
	void FixedUpdate()
	{
		Vector3 input = new Vector3(
			Input.GetAxis("Horizontal"),
			0,
			Input.GetAxis("Vertical")
		);

		input *= speed;
		input = transform.TransformDirection(input);
		if (cc.isGrounded)
		{
			if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
			{
				anim.SetBool("runs", true);
			}
			else
			{
				anim.SetBool("runs", false);
			}

			moveDirection = input;
			// if (moveDirection.y < 0)
			// 	moveDirection.y = -2f;
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = Mathf.Sqrt(-2 * gravity * jump);
				anim.SetTrigger("jumps");
			}
			else
			{
				moveDirection.y = 0;

			}
		}
		else
		{
			input.y = moveDirection.y;
			moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
		}
		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		moveDirection.y += gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);

		if (pos.position.y < -30f)
		{
			pos.position = new Vector3(0, 50, 0);
			TimeToFall();
		}

		void TimeToFall()
		{
			anim.SetBool("falling", true);
			if (pos.position.y < 6)
			{
				anim.SetBool("falling", false);
			}
		}
	}




	// Second attempt
	// void Update()
	// {
	// 	float moveHorizontal = Input.GetAxis("Horizontal");
	// 	float moveVertical = Input.GetAxis("Vertical");
	// 	Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
	// 	if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
	// 	{
	// 		anim.SetTrigger("runs");
	// 	}

	// 	// This causes the character to face the correct direction
	// 	// but it breaks jumping
	// 	// if (moveHorizontal == 0 && moveVertical == 0)
	// 	// 	return;

	// 	if (cc.isGrounded && velocity.y < 0)
	// 	{
	// 		velocity.y = -2f;
	// 	}
	// 	if (Input.GetButtonDown("Jump") && cc.isGrounded)
	// 	{
	// 		velocity.y = Mathf.Sqrt(jump * -2f * gravity);
	// 		anim.SetTrigger("jumps");
	// 	}


	// 	// Makes model face the direction they're moving
	// 	transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

	// 	velocity.y += gravity * Time.deltaTime;
	// 	cc.Move(velocity * Time.deltaTime);

	// 	if (movement != Vector3.zero)
	// 	{
	// 		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
	// 		anim.SetTrigger("idle");
	// 	}

	// 	// Allows model to move in world
	// 	transform.Translate(movement * speed * Time.deltaTime, Space.World);

	// 	if (pos.position.y < -30f)
	// 	{
	// 		pos.position = new Vector3(0, 50, 0);
	// 		anim.SetTrigger("falling");
	// 	}
	// }




	// Original movement code
	// void Update()
	// {
	// 	float x = Input.GetAxis("Horizontal");
	// 	float z = Input.GetAxis("Vertical");


	// 	if (cc.isGrounded && velocity.y < 0)
	// 	{
	// 		velocity.y = -2f;
	// 	}
	// 	if (Input.GetButtonDown("Jump") && cc.isGrounded)
	// 	{
	// 		velocity.y = Mathf.Sqrt(jump * -2f * gravity);
	// 	}

	// 	Vector3 move = transform.right * x + transform.forward * z;

	// 	cc.Move(move * speed * Time.deltaTime);

	// 	velocity.y += gravity * Time.deltaTime;

	// 	cc.Move(velocity * Time.deltaTime);
	// 	if (pos.position.y < -30f)
	// 	{
	// 		pos.position = new Vector3(0, 50, 0);
	// 	}
	// }
}
