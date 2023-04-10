using UnityEngine;

public class MouseDragging : MonoBehaviour
{
	public Camera mainCamera;
	public LayerMask interactableMask;

	public Transform selectedObject;
	bool selectableObjectInRange;
	Vector2 mousePoint;

	void Update()
	{
		CalculateMousePosition();

		if(selectedObject != null)
			selectedObject.position = Vector3.Lerp(selectedObject.position, mousePoint, 10 * Time.deltaTime);
	}
	
	void CalculateMousePosition()
	{
		mousePoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hitData2D = Physics2D.Raycast(mousePoint, Vector2.zero, Mathf.Infinity, interactableMask);
		
		if(selectedObject == null)
		{
			if(Input.GetMouseButtonDown(0) && hitData2D.transform != null)
				selectedObject = hitData2D.transform;
		}
		else
			if(Input.GetMouseButtonDown(0))
				selectedObject = null;
	}
	
	private void OnDrawGizmos() {
		Gizmos.DrawRay(transform.position, mousePoint);
	}
}