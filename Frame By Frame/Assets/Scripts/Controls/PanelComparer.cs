using UnityEngine;

public class PanelComparer : MonoBehaviour
{
	public MouseDragging mouseDragging;
	public ComicPanel occupiedPanel;

	public float acceptableDistance;
	public int expectedIndex;
	public float panelDistace;

	void Update()
	{
		if(mouseDragging.GetSelectionState())
			panelDistace = Vector2.Distance(mouseDragging.selectedObject.position, transform.position);

		if(panelDistace <= acceptableDistance && mouseDragging.GetSelectionState())
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(occupiedPanel != null && mouseDragging.selectedObject != occupiedPanel.transform)
				{
					mouseDragging.isSwapping = true;
					mouseDragging.selectedObject = occupiedPanel.transform;
				}

				occupiedPanel = mouseDragging.panelRack.GetCurrentPanel();
				occupiedPanel.transform.position = transform.position;

				if(expectedIndex == occupiedPanel.panelIndex)
					Debug.Log("Proper panel in place!");
			}
			else
			{
				if(mouseDragging.isSwapping)
					mouseDragging.isSwapping = false;
			}
		}
		else if(occupiedPanel != null && mouseDragging.selectedObject == occupiedPanel.transform)
			occupiedPanel = null;
	}
}