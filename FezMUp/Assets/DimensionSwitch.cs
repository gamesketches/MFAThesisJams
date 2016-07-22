using UnityEngine;
using System.Collections;

public class DimensionSwitch : MonoBehaviour 
{

	BoxCollider collider;
	bool xyMode;
	// Use this for initialization
	void Start () 
	{
		xyMode = true;
		collider = GetComponent<BoxCollider>();
		collider.size = new Vector3(1, 1, 100);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space)) {
			if(xyMode) {
				collider.size = new Vector3(1, 100, 1);
			}
			else {
				collider.size = new Vector3(1, 1, 100);
			}
			xyMode = !xyMode;
		}
	}
}
