using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	public RectTransform selector;
	Vector2 sceneMousePositionBegin;
	Vector2 sceneMousePositionEnd;

	/******
	 * 
	 * TODO Create a function that if shift is hold make the box proportional, if not then don't
	 * 
	 * 
	**/ 
	public void OnPointerDown (PointerEventData eventData)
	{
		sceneMousePositionBegin = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		selector.anchoredPosition = sceneMousePositionBegin;
	}

	public void OnDrag (PointerEventData eventData)
	{
		sceneMousePositionEnd = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 startPoint = sceneMousePositionBegin;
		Vector2 difference = sceneMousePositionEnd - startPoint;

		if (difference.x < 0)
		{
			startPoint.x = sceneMousePositionEnd.x;
			difference.x = -difference.x;
		}
		if (difference.y < 0)
		{
			startPoint.y = sceneMousePositionEnd.y;
			difference.y = -difference.y;
		}

		selector.anchoredPosition = startPoint;
		selector.sizeDelta = difference;
	}
	
	public void OnPointerUp (PointerEventData eventData)
	{
		selector.anchoredPosition = Vector2.zero;
		selector.sizeDelta = Vector2.zero;
		sceneMousePositionBegin = Vector2.zero;
	}
	
}
