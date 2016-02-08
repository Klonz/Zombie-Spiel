using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public Transform CameraTarget;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		
		transform.position = CameraTarget.transform.position;
		transform.position = new Vector3 (CameraTarget.transform.position.x, CameraTarget.transform.position.y, -10);

	}
}
