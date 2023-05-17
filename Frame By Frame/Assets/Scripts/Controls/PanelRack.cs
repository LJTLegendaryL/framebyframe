using UnityEngine;

public class PanelRack : MonoBehaviour
{
	public ComicPanel[] comicPanels;
	public int currentIndex;

	public void SetPanelIndex(int index)
	{
		currentIndex = index;
	}

	public ComicPanel GetCurrentPanel()
	{
		return comicPanels[currentIndex];
	}
}