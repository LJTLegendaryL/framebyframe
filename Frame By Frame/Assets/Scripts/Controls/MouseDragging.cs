using UnityEngine;

public class MouseDragging : MonoBehaviour
{
	public PanelRack panelRack;
	public Camera mainCamera;
	public LayerMask interactableMask;

	public Transform selectedObject;
	public bool isSwapping;
	
	bool selectableObjectInRange;
	Vector2 mousePoint;
	
	public bool GetSelectionState()
	{
		return selectedObject != null;
	}

	void Update()
	{
		CalculateMousePosition();

		if(GetSelectionState())
			selectedObject.position = Vector3.Lerp(selectedObject.position, mousePoint, 10 * Time.deltaTime);
	}
	
	void CalculateMousePosition()
	{
		if(!GetSelectionState())
		{
			mousePoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hitData2D = Physics2D.Raycast(mousePoint, Vector2.zero, Mathf.Infinity, interactableMask);
			
			if(hitData2D.transform != null)
			{
				var panelComponent = hitData2D.transform.gameObject.GetComponent<ComicPanel>();
				panelRack.SetPanelIndex(panelComponent.panelIndex);

				if(Input.GetMouseButtonDown(0))
					selectedObject = hitData2D.transform;
			}
		}
		else
			if(Input.GetMouseButtonDown(0) && !isSwapping)
				selectedObject = null;
	}
	
	private void OnDrawGizmos() {
		Gizmos.DrawRay(transform.position, mousePoint);
	}
}