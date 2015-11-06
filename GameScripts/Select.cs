using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Select : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	public RectTransform selector;
	public GameObject selectorBoxCol;
	Vector2 sceneMousePositionBegin;
	Vector2 sceneMousePositionEnd;
	PointerEventData eventData = null;
	public NanoByteIns nanoByteInspector;
	public bool canDrag;
	public bool isDragging;
	public bool clickedEnemy;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)) //&& isDragging)
		{
			OnPointerUp(eventData);
			//Debug.Log(nanoByteInspector.nanoBits.Count);
			canDrag = false;
			for(int i = 0; i < nanoByteInspector.nanoBits.Count; ++i)
			{
				//Debug.Log("Selected?: " + nanoByteInspector.nanoBits[i].isSelected);
				if(nanoByteInspector.nanoBits[i].isSelected)
				{
					nanoByteInspector.nanoBits[i].setSelection(false);
					//Debug.Log("Deselected: " + nanoByteInspector.holderForBits[i].name);
				}
			}
		}

	}

	public void ClickedEnemy(Transform enemyPos)
	{
		clickedEnemy = true;
		for(int i = 0; i < nanoByteInspector.holderForBits.Count; ++i)
		{
			if(nanoByteInspector.holderForBits[i].GetComponent<NanoBitIns>().nanobit.getSelection())
			{
				nanoByteInspector.holderForBits[i].GetComponent<NanoBitIns>().nanobit.setEnemyPos(enemyPos);
				nanoByteInspector.holderForBits[i].GetComponent<NanoBitIns>().nanobit.isAttacking = true;
			}
		}
	}

	public void OnPointerDown (PointerEventData eventData)
	{

		sceneMousePositionBegin = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		selector.anchoredPosition = sceneMousePositionBegin;
		for(int i = 0; i < nanoByteInspector.nanoBits.Count; ++i)
		{
			//Debug.Log("Selected?: " + nanoByteInspector.nanoBits[i].isSelected);
			if(nanoByteInspector.nanoBits[i].isSelected)
			{
				if(!clickedEnemy)
				{
					nanoByteInspector.nanoBits[i].setSelection(false);
				}
				//Debug.Log("Deselected: " + nanoByteInspector.holderForBits[i].name);
			}
		}
	}

	public void OnDrag (PointerEventData eventData)
	{

		if(canDrag)
		{
			isDragging = true;
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
			selectorBoxCol.GetComponent<BoxCollider2D>().size = difference;
		}

	}
	
	public void OnPointerUp (PointerEventData eventData)
	{
		canDrag = true;
		isDragging = false;
		clickedEnemy = false;
		selector.anchoredPosition = Vector2.zero;
		selector.sizeDelta = Vector2.zero;
		sceneMousePositionBegin = Vector2.zero;
		selectorBoxCol.GetComponent<BoxCollider2D>().size = Vector2.zero;
	}

}
