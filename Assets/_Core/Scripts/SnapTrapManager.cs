using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Core.Scripts
{
	// Phone-manager or snapchat-manager
	// Rename to [nameof snapchat-clone]Manager
	public class SnapTrapManager : MonoBehaviour
	{
		[SerializeField] private Image _snapSpriteTarget; // Also has button

		private List<Sprite> _savedSnaps;

		private bool _inited;

		public void SetNewSnaps(List<DungeonSequence> sequences)
		{
			if (!_inited)
			{
				// Set click-events for button

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
	}
}
