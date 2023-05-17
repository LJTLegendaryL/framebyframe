using UnityEngine;

public class PanelSlot : MonoBehaviour
{
	public MouseControls mouseControls;
	public PanelSlotChecker panelSlotChecker;
	public PanelRack panelRack;
	public float proximityDistance;
	float distance;
	int correctionBit;
	bool correct;

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

					correct = (placeObject == panelRack.comicPanels[targetIndex].transform);
					
					if(correct)
					{
						panelSlotChecker.totalSlotsCorrect++;
						correctionBit = 1;
					}
					else if(correctionBit > 0)
					{
						panelSlotChecker.totalSlotsCorrect--;
						correctionBit = 0;
					}
					
				}
			}
			else
				mouseControls.setPosition = null;
		}
	}
}