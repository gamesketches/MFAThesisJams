using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeText : MonoBehaviour {

	public float fadeDuration = 3.0f;
	float fadeTimer = 0.0f;
	public AnimationCurve animCurve;

	Text text;

	public void InitializeVariables()
	{
		text = transform.root.Find("UI").Find("Win text").GetComponent<Text>();
	}

	public IEnumerator FadeIn()
	{
		while (fadeTimer <= fadeDuration)
		{
			fadeTimer += Time.deltaTime;

			text.color = new Color(text.color.r,
								   text.color.g,
								   text.color.b,
								   Mathf.Lerp(0.0f, 1.0f, animCurve.Evaluate(fadeTimer/fadeDuration)));

			yield return null;
		}

		fadeTimer = 0.0f;

		yield break;
	}
}

