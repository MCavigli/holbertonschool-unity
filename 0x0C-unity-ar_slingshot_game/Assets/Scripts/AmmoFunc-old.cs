using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AmmoFuncold : MonoBehaviour
{
	ARRaycastManager m_RaycastManager;
	ARReferencePointManager m_ReferencePoint;
	List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
	List<GameObject> bullets = new List<GameObject>();
	Pose ammoPose = new Pose(new Vector3(0.0f, 0.0f, 0.3f), Quaternion.identity);
	Rigidbody rb;
	Vector3 centerPos;
	Vector3 touchPos;
	Vector3 direction;
	AmmoFunc ammoFuncScript;
	SelectPlane selectPlaneScript;
	bool outOfAmmo = false;
	int flag = 0;
	int score = 0;

	public GameObject ammo;
	public GameObject targetPrefab;
	public GameObject gameCanvas;
	public GameObject quitCanvas;
	public GameObject replayCanvas;
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;
	public GameObject bullet4;
	public GameObject bullet5;
	public GameObject bullet6;
	public GameObject bullet7;

	public Text scoreText;
	public ARReferencePoint spawnedObjectRef;
	public ARSession currentSession;

	// public GameObject spawnedObjectRef { get; private set; }
	public Camera mainCamera;

	void Awake()
	{
		m_RaycastManager = GetComponent<ARRaycastManager>();
		m_ReferencePoint = GetComponent<ARReferencePointManager>();
		ammoFuncScript = GetComponent<AmmoFunc>();
		selectPlaneScript = GetComponent<SelectPlane>();

	}

	void FixedUpdate()
	{
		if (outOfAmmo)
			replayCanvas.SetActive(true);

		if (flag == 0)
		{
			// spawnedObjectRef = Instantiate(ammo, new Vector3(0f, 0f, 0.3f), Quaternion.identity);
			// spawnedObjectRef.transform.SetParent(mainCamera.transform, false);
			// Vector3 centerPos = spawnedObjectRef.position;
			// flag = 1;
			gameCanvas.SetActive(true);

			spawnedObjectRef = m_ReferencePoint.AddReferencePoint(ammoPose);
			spawnedObjectRef.transform.SetParent(mainCamera.transform, false);
			ammo = mainCamera.gameObject.transform.GetChild(0).gameObject;
			Debug.Log("*** ammo variable: " + ammo + " ***");
			Debug.Log("*** ammo variable type: " + ammo.GetType() + " ***");
			centerPos = spawnedObjectRef.transform.position;
			Debug.Log("*** centerPos: " + centerPos + " ***");
			flag = 1;
		}
		if (spawnedObjectRef && Input.touchCount > 0)
		{
			if ((Input.GetTouch(0).phase == TouchPhase.Moved))
			{
				Touch touch = Input.GetTouch(0);
				Debug.Log("*** Got here, but.... ***");
				if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.FeaturePoint))
				{
					Debug.Log("***** GET HERE? ***");
					// Vector3 pos = touch.position;

					// ammo.transform.position = touch.position;
					ammo.transform.position = s_Hits[0].pose.position + Vector3.zero;

					// spawnedObjectRef.transform.position = new Vector3(
					// 	spawnedObjectRef.transform.position.x + touch.deltaPosition.x * speed,
					// 	spawnedObjectRef.transform.position.y,
					// 	spawnedObjectRef.transform.position.z + touch.deltaPosition.y * speed
					// );

					// touchPos = mainCamera.ScreenToWorldPoint(touch.position);
					// touchPos.z = 0;
					// direction = (touchPos - transform.position);
					// rb = spawnedObjectRef.GetComponent<Rigidbody>();
					// rb.velocity = new Vector2(direction.x, direction.y) * speed;

				}

			}
			if (Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				ammo.transform.position = centerPos;
				scoreText.text = "Score: " + score.ToString();
				score += 5;
				if (bullet7.activeSelf)
					bullet7.SetActive(false);
				else if (bullet6.activeSelf)
					bullet6.SetActive(false);
				else if (bullet5.activeSelf)
					bullet5.SetActive(false);
				else if (bullet4.activeSelf)
					bullet4.SetActive(false);
				else if (bullet3.activeSelf)
					bullet3.SetActive(false);
				else if (bullet2.activeSelf)
					bullet2.SetActive(false);
				else if (bullet1.activeSelf)
				{
					bullet1.SetActive(false);
					outOfAmmo = true;
				}
			}
		}
	}

	public void restartGame()
	{
		scoreText.text = "Score: 0";
		score = 0;
		bullet1.SetActive(true);
		bullet2.SetActive(true);
		bullet3.SetActive(true);
		bullet4.SetActive(true);
		bullet5.SetActive(true);
		bullet6.SetActive(true);
		bullet7.SetActive(true);

		// selectPlaneScript.enabled = true;
		// ammoFuncScript.enabled = false;
		// currentSession.Reset();
	}

	public void quitGame()
	{
		gameCanvas.SetActive(false);
		quitCanvas.SetActive(true);
	}

	public void quitYes()
	{
		Application.Quit();
	}

	public void quitNo()
	{
		gameCanvas.SetActive(true);
		quitCanvas.SetActive(false);
	}
}
