using UnityEngine;

public class PanelSlotChecker : MonoBehaviour
{
	public int totalSlotsCorrect, totalSlots;
	
	public void CheckSlots()
	{
		if(totalSlotsCorrect < totalSlots)
			Debug.Log("Not all slots are correct!");
		else
			Debug.Log("All slots are correct!");
	}
}