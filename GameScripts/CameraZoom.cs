using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public Camera zoomedCamera;
	public Camera mainCamera;

	//TODO Doesn't work because we are working with only x y plane
	void Update () {

		if(Input.GetKey(KeyCode.M))
		{
			mainCamera.enabled = false;
			zoomedCamera.gameObject.SetActive(true);
		}
		else
		{
			mainCamera.enabled = true;
			zoomedCamera.gameObject.SetActive(false);
		}
		transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
