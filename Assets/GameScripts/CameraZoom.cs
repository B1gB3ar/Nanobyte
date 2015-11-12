using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	public float zoom = 0.0f;

	public float zoomFactor = 0.0f;

	//TODO Doesn't work because we are working with only x y plane
	void Update () {

		zoomFactor = Input.GetAxis("Mouse ScrollWheel");
		Debug.Log(zoom);

		if(zoomFactor > 0 || zoomFactor < 0)
		{
			if(zoom > 0 && zoom < 10)
				zoom += zoomFactor;
		}

		transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, 
		                                                                  transform.position.z - zoom), Time.deltaTime * 2);
	}
}
