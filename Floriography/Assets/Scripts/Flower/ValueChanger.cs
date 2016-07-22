using UnityEngine;
using System.Collections;

public class ValueChanger : MonoBehaviour {

	public string propertyName;
	public float gameDuration = 120.0f;
	float timer = 0.0f;
	public float startValue = 300.0f;
	public float endValue = 1000.0f;
	public AnimationCurve animCurve;
	Material mat;

	public void InitializeVariables()
	{
		mat = GetComponent<Renderer>().material;
	}

	void Update ()
	{
		timer += Time.deltaTime;

		ChangeMultiplier();
	}

	void ChangeMultiplier()
	{
		float newMult = Mathf.Lerp(startValue, endValue, animCurve.Evaluate(timer/gameDuration));
		mat.SetFloat(propertyName, newMult);
	}
}
