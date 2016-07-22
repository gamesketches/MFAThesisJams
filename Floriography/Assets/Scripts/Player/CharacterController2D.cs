using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {
	Rigidbody2D rb2D;

	public float speed = 3f;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += new Vector3 (0f, 0f, -1f) * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += new Vector3 (0f, 0f, 1f)* Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-1f, 0f, 0f)* Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (1f, 0f, 0f)* Time.deltaTime * speed;
		}
	}
}
