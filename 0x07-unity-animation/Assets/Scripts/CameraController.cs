using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	// public GameObject player;
	// public Vector3 offset;
	public float mouseSensitivity = 150f;

	public Transform lookAt;
	public Transform camTransform;

	public bool isInverted;

	private Camera cam;
	private float distanceZ = 5.0f;
	private float distanceY = 2.0f;
	private float currentX = 0f;
	private float currentY = 0f;
	// public Transform camBody;
	// float xRotation = 0f;

	void Start()
	{
		if (PlayerPrefs.GetString("Inverted") != "")
			isInverted = false;
		else
			isInverted = true;
		// int isInverted = PlayerPrefs.GetInt("Inverted");
		Cursor.lockState = CursorLockMode.Locked;
		camTransform = transform;
		cam = Camera.main;
	}

	void Update()
	{
		currentX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		currentY += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * (isInverted ? -1 : 1);
		currentY = Mathf.Clamp(currentY, -25f, 50f);

	}
	void LateUpdate()
	{
		Vector3 dir = new Vector3(0, distanceY, -distanceZ);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt(lookAt.position);
	}
}
