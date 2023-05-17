using System.Collections;
using UnityEngine;

public class MouseControls : MonoBehaviour
{
	public Camera renderCamera;
	public LayerMask interactionMask;
	Vector2 mouseRay;

	public Transform selectedObject, setPosition;

	public bool isDragging()
	{
		return selectedObject != null;
	}

	void Update()
	{
		SetClickState();

		if(isDragging())
			selectedObject.position = Vector3.Lerp(selectedObject.position, mouseRay, 10 * Time.deltaTime);
	}

	void SetClickState()
	{
		mouseRay = renderCamera.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hitData = Physics2D.Raycast(mouseRay, Vector2.zero, Mathf.Infinity, interactionMask);

		if(Input.GetMouseButtonDown(0))
			StartCoroutine(OnClick(hitData));
	}

	void ResetObjectState()
	{
		selectedObject.gameObject.layer = 6;
		
		if(setPosition != null)
			selectedObject.position = setPosition.position;
	}
	
	IEnumerator OnClick(RaycastHit2D hit2D)
	{
		if(hit2D.transform != null && (!isDragging() || selectedObject != hit2D.transform))
		{
			yield return new WaitForEndOfFrame();

			if(isDragging())
				ResetObjectState();

			selectedObject = hit2D.transform;
			selectedObject.gameObject.layer = 2;
		}
		else if(isDragging())
		{
			yield return new WaitForEndOfFrame();

			ResetObjectState();
			selectedObject = null;
		}
	}
}