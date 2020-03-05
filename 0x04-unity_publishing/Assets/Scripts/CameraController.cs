using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	public Vector3 offset;

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.position = player.transform.position + offset;
	}
}
