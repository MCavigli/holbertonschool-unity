using UnityEngine;

public class Rotator : MonoBehaviour
{
	void Update()
	{
		transform.Rotate(0, Time.deltaTime * 45, 0, Space.World);
	}
}
