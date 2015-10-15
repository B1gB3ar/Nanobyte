using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	public GameObject selector;
	public Vector3 initScale;

	/******
	 * 
	 * TODO Create a function that if shift is hold make the box proportional, if not then don't
	 * 
	 * 
	**/ 
	public void OnPointerDown (PointerEventData eventData)
	{
		Debug.Log("Begin Click");
		selector.gameObject.SetActive(true);
		Vector3 sceneMousePositionBegin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		sceneMousePositionBegin.z = 0;
		selector.transform.position = sceneMousePositionBegin;
		initScale = selector.transform.localScale;
	}

	public void OnDrag (PointerEventData eventData)
	{

		Vector3 sceneMousePositionEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		sceneMousePositionEnd.z = 0;
		selector.transform.localScale = new Vector3(-sceneMousePositionEnd.x, sceneMousePositionEnd.y, 0);
		Debug.Log("Dragging: " + sceneMousePositionEnd);
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		Debug.Log("End Click");
		selector.transform.localScale = initScale;
		selector.gameObject.SetActive(false);
	}
	
}
