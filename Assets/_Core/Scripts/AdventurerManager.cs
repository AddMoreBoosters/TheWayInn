using System.Collections.Generic;
using UnityEngine;

namespace Assets._Core.Scripts
{
	public class AdventurerManager : MonoBehaviour
	{
		private List<string> _equippedItems;
		public List<DungeonSequenceObject> DungeonSequences;

		public void Equip(List<string> items)
		{
			_equippedItems = items;

			FindObjectOfType<MainManager>().SendOffAdventurer();
		}
	}
}
