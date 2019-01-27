using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Core.Scripts
{
	// Phone-manager or snapchat-manager
	// Rename to [nameof snapchat-clone]Manager
	public class SnapTrapManager : MonoBehaviour
	{
		[SerializeField] private GameObject _snapTrapScreen;
		[SerializeField] private Button _snapTargetButton; // Also has image
		[SerializeField] private Button _nextButton;
		private Image SnapImage => _snapTargetButton.GetComponent<Image>();
		[Space]
		public AudioClip Vibrate;
		public AudioClip NextSnap;
		[Space]
		public Sprite[] GoblinSnaps;
		public Sprite WinSnap;

		private Stack<Sprite> _newSnaps;
		private List<Sprite> _savedSnaps;

		private bool _successfulAdventure = false;

		private bool _inited;

		public void SetNewSnaps(List<DungeonSequenceObject> sequences, List<string> eqippedItems)
		{
			if (!_inited)
			{
				// Set click-events for button
				_snapTargetButton.onClick.AddListener(OnSnapClick);

				_inited = true;
			}

			_successfulAdventure = true;


			List<Sprite> snapList = new List<Sprite>();
			for (var i = 0; i < sequences.Count; i++)
			{
				DungeonSequenceObject s = sequences[i];
				snapList.Add(s.BeforeSequenceSnap);

				// Matching item
				if (s.CorrectItemName == eqippedItems[i])
				{
					snapList.Add(s.AfterSequenceSnap);
					print($"{s.TrapName} was successful");
				}

				else
				{
					print($"{s.TrapName} failed");
					_successfulAdventure = false;
					snapList.Add(GoblinSnaps[Random.Range(0, GoblinSnaps.Length - 1)]);
					break;
				}
			}

			if (_successfulAdventure)
				snapList.Add(WinSnap);

			_newSnaps = new Stack<Sprite>();

			for (int i = snapList.Count - 1; i >= 0; i--)
			{
				Sprite sprite = snapList[i];
				_newSnaps.Push(sprite);
			}

			FindObjectOfType<AudioManager>().PlayAudio(Vibrate);
			_nextButton.interactable = false;
			MainManager.ShowOnly(_snapTrapScreen);
			SnapImage.color = Color.clear;
		}

		private void OnSnapClick()
		{
			SnapImage.color = Color.white;

			if (_newSnaps.Count > 0)
			{
				SnapImage.sprite = _newSnaps.Pop();
				FindObjectOfType<AudioManager>().PlayAudio(NextSnap);
			}
			
			if (_newSnaps.Count == 0)
			{
				_nextButton.onClick.RemoveAllListeners();
				_nextButton.interactable = true;
				if (_successfulAdventure)
				{
					_nextButton.onClick.AddListener(FindObjectOfType<MainManager>().SetWinScreen);
				}

				else
				{
					_nextButton.onClick.AddListener(FindObjectOfType<MainManager>().NewAdventurer);
				}
			}
		}

		public void RestartGame()
		{
			//restart
		}
	}
}
