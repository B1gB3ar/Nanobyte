using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	public RectTransform selector;
	public TestIns testInspector;
	Vector2 sceneMousePositionBegin;
	Vector2 sceneMousePositionEnd;
	public PolygonCollider2D zoneForSelection;
	
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
		Debug.Log("Size: " + zoneForSelection.bounds.size);
		for(int i = 0; i < testInspector.nanoBits.Count; ++i)
		{
			Debug.Log("NanoBits Location: " + i + testInspector.nanoBits[i].getLocation());
			if(testInspector.nanoBits[i].isSelected && testInspector.nanoBits[i].getLocation().x >= 
			   zoneForSelection.bounds.size.x)
			{

				Debug.Log(i + " Contained");
			}
		}

		selector.anchoredPosition = Vector2.zero;
		selector.sizeDelta = Vector2.zero;
		sceneMousePositionBegin = Vector2.zero;
	}
	
}
