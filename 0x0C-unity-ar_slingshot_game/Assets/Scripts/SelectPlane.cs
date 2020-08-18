using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SelectPlane : MonoBehaviour
{
	ARPlaneManager m_PlaneManager;
	ARRaycastManager m_RaycastManager;
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
	}
}
