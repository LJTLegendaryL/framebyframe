using UnityEngine;

public class PanelSlot : MonoBehaviour
{
	public MouseControls mouseControls;
	public PanelRack panelRack;
	public float proximityDistance;
	float distance;

	public Transform placeObject;
	public int targetIndex;

	void Update()
	{
		if(mouseControls.isDragging())
		{
			distance = Vector3.Distance(mouseControls.selectedObject.position, transform.position);

			if(distance <= proximityDistance)
			{
				mouseControls.setPosition = transform;
				
				if(Input.GetMouseButtonDown(0))
				{
					placeObject = mouseControls.selectedObject;

					if(placeObject == panelRack.comicPanels[targetIndex].transform)
						Debug.Log("Correct Panel in place!");
				}
			}
			else
				mouseControls.setPosition = null;
		}
	}
}