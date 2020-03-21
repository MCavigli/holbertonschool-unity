using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController cc;
	public float speed = 12f;
	public float jump = 2f;
	public float gravity = -9.81f * 2;
	Vector3 velocity;
	// private Vector3 moveDirection = Vector3.zero;


	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		if (cc.isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
		if (Input.GetButtonDown("Jump") && cc.isGrounded)
		{
			velocity.y = Mathf.Sqrt(jump * -2f * gravity);
		}

		Vector3 move = transform.right * x + transform.forward * z;

		cc.Move(move * speed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;

		cc.Move(velocity * Time.deltaTime);
	}
	// void Start()
	// {
	// 	cc = GetComponent<CharacterController>();
	// }

	// void Update()
	// {
	// 	if (cc.isGrounded)
	// 	{
	// 		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 1.13f, Input.GetAxis("Vertical"));
	// 		moveDirection *= speed;
	// 		if (Input.GetKeyDown(KeyCode.Space))
	// 		{
	// 			moveDirection.y = jump;
	// 		}

	// 	}
	// 	moveDirection.y -= gravity * Time.deltaTime;

	// 	if (Input.GetKey("w"))
	// 	{
	// 		// moveDirection += Vector3.forward;
	// 		cc.Move(moveDirection * Time.deltaTime);
	// 	}
	// 	if (Input.GetKey("s"))
	// 	{
	// 		cc.Move(moveDirection * Time.deltaTime);
	// 	}
	// 	if (Input.GetKey("a"))
	// 	{
	// 		cc.Move(moveDirection * Time.deltaTime);
	// 	}
	// 	if (Input.GetKey("d"))
	// 	{
	// 		cc.Move(moveDirection * Time.deltaTime);
	// 	}

	// }
}
