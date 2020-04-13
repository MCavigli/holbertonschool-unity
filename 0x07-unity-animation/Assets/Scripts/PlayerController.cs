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
		if (pos.position.y < -30f)
		{
			pos.position = new Vector3(0, 50, 0);
		}
	}
}
