using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeImage : MonoBehaviour {

	public float fadeDuration = 3.0f;
	float fadeTimer = 0.0f;
	public AnimationCurve animCurve;

	Image controlDiagram;

	public void InitializeVariables()
	{
		controlDiagram = transform.root.Find("UI").Find("Controls").GetComponent<Image>();
	}

	public IEnumerator FadeOut()
	{
		while (fadeTimer <= fadeDuration)
		{
			fadeTimer += Time.deltaTime;

			controlDiagram.color = new Color(controlDiagram.color.r,
											 controlDiagram.color.g,
											 controlDiagram.color.b,
											 Mathf.Lerp(1.0f, 0.0f, animCurve.Evaluate(fadeTimer/fadeDuration)));

			yield return null;
		}

		fadeTimer = 0.0f;

		yield break;
	}
}
