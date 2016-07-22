using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform Target;
    public float CameraMoveSpeed;

	// Update is called once per frame
	void Update () {
        FollowTarget();
	}

    void FollowTarget() {
        transform.position = Vector3.Lerp(transform.position, Target.position + Vector3.back * 10, CameraMoveSpeed * Time.deltaTime);
    }
}
