using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SelectPlaneold : MonoBehaviour
{
	ARPlaneManager m_PlaneManager;
	ARRaycastManager m_RaycastManager;
	// GameObject m_placedPrefab;
	float i = 0.07f;
	float k = -0.07f;

	AmmoFunc ammoFuncScript;
	SelectPlane selectPlaneScript;

	static ARPlane chosenPlane;
	static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
	static int flag;

	public int numberOfTargets;
	public GameObject spawnedObject { get; private set; }
	public GameObject startButton;
	public GameObject placedPrefab;

	void Awake()
	{
		m_RaycastManager = GetComponent<ARRaycastManager>();
		m_PlaneManager = GetComponent<ARPlaneManager>();
		ammoFuncScript = GetComponent<AmmoFunc>();
		selectPlaneScript = GetComponent<SelectPlane>();
		flag = 0;
	}

	void FixedUpdate()
	{
		if (Input.touchCount > 0 && flag == 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Ended)
			{
				if (Input.touchCount == 1)
				{
					if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
					{
						chosenPlane = m_PlaneManager.GetPlane(s_Hits[0].trackableId);
						Vector3 newCenter = new Vector3(chosenPlane.center.x, chosenPlane.center.y, chosenPlane.center.z);
						spawnedObject = Instantiate(placedPrefab, newCenter, Quaternion.identity);
						for (int j = 1; j < numberOfTargets; i += 0.07f, j++, k -= 0.07f)
						{
							spawnedObject = Instantiate(placedPrefab, newCenter + new Vector3(i, 0, k), Quaternion.identity);
						}
						foreach (var plane in m_PlaneManager.trackables)
						{
							plane.gameObject.SetActive(false);
						}
						startGame();
						flag = 1;
					}
				}
			}
		}
	}
	void startGame()
	{
		startButton.SetActive(true);
	}

	public void populatePlane()
	{
		startButton.SetActive(false);
		ammoFuncScript.enabled = true;
		selectPlaneScript.enabled = false;

		// float i = 0.0f;

		// Debug.Log("***chosenplane.center: " + chosenPlane.center);
		// Vector3 newCenter = new Vector3(chosenPlane.center.x, chosenPlane.center.y, chosenPlane.center.z);
		// Debug.Log("***newCenter: " + newCenter);

		// List<Vector2> boundaryPts = new List<Vector2>();
		// foreach (Vector2 point in chosenPlane.boundary)
		// {
		// 	Debug.Log("***Point" + i + ": " + point);
		// 	Debug.Log("Type of Point: " + point.GetType());
		// 	boundaryPts[i] = point;
		// 	// Debug.Log(i + ": " + boundaryPts[i]);
		// 	i++;
		// }

		// boundaryPts = chosenPlane.boundary;
		// Debug.Log("***Boundary points from boundaryPts: " + boundaryPts);

		// for (int j = 0; j < numberOfTargets; i += 0.02f)
		// {
		// 	spawnedObject = Instantiate(m_placedPrefab, new Vector3(i * 1.0f, 0, i * 1.0f) + newCenter, Quaternion.identity);
		// 	j += 1;
		// }

		// spawnedObject = Instantiate(m_placedPrefab, newCenter, Quaternion.identity);


		// foreach (var plane in m_PlaneManager.trackables)
		// {
		// 	plane.gameObject.SetActive(false);
		// }

	}
}
