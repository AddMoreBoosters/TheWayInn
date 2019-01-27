using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._Core.Scripts
{
	// Phone-manager or snapchat-manager
	// Rename to [nameof snapchat-clone]Manager
	public class SnapTrapManager : MonoBehaviour
	{
		[SerializeField] private GameObject _snapTrapScreen;
		[SerializeField] private Button _snapTargetButton; // Also has image
		private Image SnapImage => _snapTargetButton.GetComponent<Image>();

		private Stack<Sprite> _newSnaps;
		private List<Sprite> _savedSnaps;

		private bool _inited;

		public void SetNewSnaps(List<DungeonSequenceObject> sequences, List<string> eqippedItems)
		{
			if (!_inited)
			{
				// Set click-events for button
				_snapTargetButton.onClick.AddListener(OnSnapClick);

				_inited = true;
			}

			_newSnaps = new Stack<Sprite>();
			for (var i = 0; i < sequences.Count; i++)
			{
				DungeonSequenceObject s = sequences[i];
				_newSnaps.Push(s.BeforeSequenceSnap);

				// Matching item
				if (s.CorrectItemName == eqippedItems[i])
				{
					_newSnaps.Push(s.AfterSequenceSnap);
					print($"{s.TrapName} was successful");
				}

				else
				{
					print($"{s.TrapName} failed");
					break;
				}
			}

			MainManager.ShowOnly(_snapTrapScreen);
			SnapImage.sprite = _newSnaps.Pop();
		}

		private void OnSnapClick()
		{
			SnapImage.sprite = _newSnaps.Pop();
		}

		public void SetTriggerEvent(EventTrigger trigger, EventTriggerType triggerType, Action callAction)
		{
			EventTrigger.Entry entry = new EventTrigger.Entry { eventID = triggerType };
			entry.callback.AddListener(_ => callAction());
			trigger.triggers.Add(entry);
		}
	}
}
