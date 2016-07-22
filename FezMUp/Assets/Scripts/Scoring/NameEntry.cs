using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NameEntry : MonoBehaviour {

	InputField nameField;

	void Start()
	{
		nameField = GameObject.Find("Name field").GetComponent<InputField>();
		nameField.ActivateInputField();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			ValueHolder.name = nameField.text;
			SceneManager.LoadScene("main");
		}
	}
}
