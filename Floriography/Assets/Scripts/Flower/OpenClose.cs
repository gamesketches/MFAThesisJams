using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenClose : MonoBehaviour {

	Transform petal1;
	Transform petal2;
	Transform petal3;
	Transform petal4;
	Transform petal5;
	Transform petal6;

	Transform boy;
	Transform girl;

	List<Transform> petals = new List<Transform>();
	Dictionary<Transform, Vector3> closedPos = new Dictionary<Transform, Vector3>();
	Dictionary<Transform, Vector3> openPos = new Dictionary<Transform, Vector3>();

	public void InitializeVariables()
	{
		AssignTransforms();
		SetUpDataStructures();
	}

	public float petalDuration = 3.0f;
	float petalTimer = 0.0f;
	public AnimationCurve petalAnimCurve;

	public IEnumerator Open()
	{
		while (petalTimer <= petalDuration)
		{
			petalTimer += Time.deltaTime;

			foreach (Transform petal in petals)
			{
				Vector3 rot = Vector3.Lerp(closedPos[petal], openPos[petal], petalAnimCurve.Evaluate(petalTimer/petalDuration));
				petal.localEulerAngles = rot;
			}

			yield return null;
		}

		petalTimer = 0.0f;

		yield break;
	}

	public IEnumerator Close()
	{
		while (petalTimer <= petalDuration)
		{
			petalTimer += Time.deltaTime;

			foreach (Transform petal in petals)
			{
				Vector3 rot = Vector3.Lerp(openPos[petal], closedPos[petal], petalAnimCurve.Evaluate(petalTimer/petalDuration));
				petal.localEulerAngles = rot;
			}

			yield return null;
		}

		petalTimer = 0.0f;

		yield break;
	}

	public float moveDuration = 3.0f;
	float moveTimer = 0.0f;
	public AnimationCurve moveAnimCurve;

	public IEnumerator GoToStart()
	{
		while (moveTimer <= moveDuration)
		{
			moveTimer += Time.deltaTime;

			Vector3 boyLoc = Vector3.Lerp(closedPos[boy], openPos[boy], moveAnimCurve.Evaluate(moveTimer/moveDuration));
			boy.transform.position = boyLoc;

			Vector3 girlLoc = Vector3.Lerp(closedPos[girl], openPos[girl], moveAnimCurve.Evaluate(moveTimer/moveDuration));
			girl.transform.position = girlLoc;

			yield return null;
		}

		moveTimer = 0.0f;

		yield break;
	}

	public IEnumerator GoToWaitLoc()
	{
		Vector3 boyStart = transform.root.Find("Boy").position;
		Vector3 girlStart = transform.root.Find("Bee").position;

		while (moveTimer <= moveDuration)
		{
			moveTimer += Time.deltaTime;

			Vector3 boyLoc = Vector3.Lerp(boyStart, closedPos[boy], moveAnimCurve.Evaluate(moveTimer/moveDuration));
			boy.transform.position = boyLoc;

			Vector3 girlLoc = Vector3.Lerp(girlStart, closedPos[girl], moveAnimCurve.Evaluate(moveTimer/moveDuration));
			girl.transform.position = girlLoc;

			yield return null;
		}

		moveTimer = 0.0f;

		yield break;
	}

	void AssignTransforms()
	{
		petal1 = transform.root.Find("Tulip").Find("Petal 1");
		petal2 = transform.root.Find("Tulip").Find("Petal 2");
		petal3 = transform.root.Find("Tulip").Find("Petal 3");
		petal4 = transform.root.Find("Tulip").Find("Petal 4");
		petal5 = transform.root.Find("Tulip").Find("Petal 5");
		petal6 = transform.root.Find("Tulip").Find("Petal 6");

		boy = transform.root.Find("Boy");
		girl = transform.root.Find("Bee");
	}

	void SetUpDataStructures()
	{
		List<GameObject> petalObjs = new List<GameObject>();
		petalObjs.AddRange(GameObject.FindGameObjectsWithTag("Petal"));
		foreach (GameObject petal in petalObjs) { petals.Add(petal.transform); }

		closedPos.Add(petal1, new Vector3(-25.08f, 7.35f, 10.91f));
		closedPos.Add(petal2, new Vector3(0.0f, 20.65f, 0.0f));
		closedPos.Add(petal3, new Vector3(-20.58f, -16.9f, 0.0f));
		closedPos.Add(petal4, new Vector3(0.0f, -26.31f, 0.0f));
		closedPos.Add(petal5, new Vector3(29.7f, 42.4f, 36.9f));
		closedPos.Add(petal6, new Vector3(23.6f, 5.5f, 0.0f));
		closedPos.Add(girl, new Vector3(0.02f, 5.93f, 0.14f));
		closedPos.Add(boy, new Vector3(-0.05f, 5.9f, 0.18f));

		openPos.Add(petal1, new Vector3(0.0f,0.0f,0.0f));
		openPos.Add(petal2, new Vector3(0.0f,0.0f,0.0f));
		openPos.Add(petal3, new Vector3(0.0f,0.0f,0.0f));
		openPos.Add(petal4, new Vector3(0.0f,0.0f,0.0f));
		openPos.Add(petal5, new Vector3(15.0f,61.0f,20.0f));
		openPos.Add(petal6, new Vector3(0.0f,0.0f,0.0f));
		openPos.Add(girl, new Vector3(-0.07f, 5.21f, 0.18f));
		openPos.Add(boy, new Vector3(-0.45f, 5.54f, 0.55f));
	}
}
