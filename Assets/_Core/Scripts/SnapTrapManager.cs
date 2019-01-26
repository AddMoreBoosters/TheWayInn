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
		[SerializeField] private Button _snapTargetButton; // Also has image

		private List<Sprite> _newSnaps;
		private List<Sprite> _savedSnaps;

		private bool _inited;

		public void SetNewSnaps(List<DungeonSequence> sequences)
		{
			if (!_inited)
			{
				// Set click-events for button
				_snapTargetButton.onClick.AddListener(OnSnapClick);

				_inited = true;
			}

			List<Sprite> newSnaps = new List<Sprite>();
			foreach (DungeonSequence s in sequences)
			{
				newSnaps.Add(s.BeforeSequenceSnap);

				if (s.Success)
				{
					newSnaps.Add(s.AfterSequenceSnap);
					print($"{s.Trap.Name} was successful");
				}

				else
				{
					print($"{s.Trap.Name} failed");
					break;
				}
			}
		}

		private void OnSnapClick()
		{

		}

		public void SetTriggerEvent(EventTrigger trigger, EventTriggerType triggerType, Action callAction)
		{
			EventTrigger.Entry entry = new EventTrigger.Entry { eventID = triggerType };
			entry.callback.AddListener(_ => callAction());
			trigger.triggers.Add(entry);
		}
	}
}
