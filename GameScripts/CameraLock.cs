using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {
	public Transform target;
	private float distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z - distance);
	}
}
