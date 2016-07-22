using UnityEngine;
using System.Collections;

public class WinLoseManager : MonoBehaviour {

	public IEnumerator PlayerWins()
	{
		Debug.Log ("Into PlayerWin");
		yield return StartCoroutine(GetComponent<OpenClose>().GoToWaitLoc());

		yield return StartCoroutine(GetComponent<OpenClose>().Close());

		yield return StartCoroutine(transform.root.Find("UI").Find("Win text").GetComponent<FadeText>().FadeIn());

		yield break;
	}

	public IEnumerator PlayerLoses()
	{
		yield return StartCoroutine(GetComponent<OpenClose>().GoToWaitLoc());

		yield return StartCoroutine(GetComponent<OpenClose>().Close());

		yield return StartCoroutine(transform.root.Find("UI").Find("Lose text").GetComponent<FadeText>().FadeIn());

		yield break;
	}
}
