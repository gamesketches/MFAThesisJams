using UnityEngine;
using System.Collections;

public class UpdateCameraPosition : MonoBehaviour {

	public Transform targetTransform;

	// Use this for initialization
	void Start () {
		if (targetTransform == null)
			targetTransform = transform.parent.FindChild("Trailer");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);
	}
}
