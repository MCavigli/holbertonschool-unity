using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController cc;
	public float speed = 12f;
	public float jump = 4.5f;
	public float gravity = -9.81f * 2;
	Vector3 velocity;
	Transform pos;

	void Start()
	{
		pos = GetComponent<Transform>();
	}

	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// This causes the character to face the correct direction
		// but it breaks jumping
		// if (moveHorizontal == 0 && moveVertical == 0)
		// 	return;

		if (cc.isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
		if (Input.GetButtonDown("Jump") && cc.isGrounded)
		{
			velocity.y = Mathf.Sqrt(jump * -2f * gravity);
		}
		Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

		velocity.y += gravity * Time.deltaTime;
		cc.Move(velocity * Time.deltaTime);


		if (movement != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
		}
		transform.Translate(movement * speed * Time.deltaTime, Space.World);
		if (pos.position.y < -30f)
		{
			pos.position = new Vector3(0, 50, 0);
		}
	}
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
