using UnityEngine;

namespace Assets._Core.Scripts
{
	public class DialogueManager : MonoBehaviour
	{
		// Name of current speaker
		// Slideshow-system for next text-slide
		// Visual feedback for current speaker

		private int _currentLineIndex;


		public void ShowDialogues(bool restart = false)
		{
			gameObject.SetActive(true);

			if (restart)
				_currentLineIndex = 0;

			MainManager.ShowOnly(transform.GetChild(_currentLineIndex).gameObject);
		}

		public void NextLine()
		{
			ShowDialogues();
			_currentLineIndex++;
			MainManager.ShowOnly(transform.GetChild(_currentLineIndex).gameObject);
		}

		public void HideDialogues()
		{
			foreach (Transform line in transform)
			{
				line.gameObject.SetActive(false);
			}
		}
	}
}