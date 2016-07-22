using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	void Awake()
	{
		GetComponent<OpenClose>().InitializeVariables();
		transform.root.Find("UI").Find("Controls").GetComponent<FadeImage>().InitializeVariables();
		transform.root.Find("UI").Find("Win text").GetComponent<FadeText>().InitializeVariables();

		SetUpPlayer();
		SetUpFlower();
	}

	void SetUpPlayer()
	{
		Transform player = transform.root.Find("Boy");
		player.GetComponent<WinTest>().InitializeVariables();
	}

	void SetUpFlower()
	{
		Transform flower = transform.root.Find("Tulip");

		foreach (Transform petal in flower)
		{
			if (petal.name.Contains("Petal")) { petal.GetComponent<ValueChanger>().InitializeVariables(); }
		}
	}

	void Start()
	{
		StartCoroutine(BeginGame());
	}

	IEnumerator BeginGame()
	{
		yield return StartCoroutine(GetComponent<OpenClose>().Open());

		yield return StartCoroutine(GetComponent<OpenClose>().GoToStart());

		yield return StartCoroutine(
									transform.root.Find("UI").Find("Controls").GetComponent<FadeImage>().FadeOut());

		yield break;
	}
}
