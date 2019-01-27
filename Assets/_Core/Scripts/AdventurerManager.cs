using System.Collections.Generic;
using UnityEngine;

namespace Assets._Core.Scripts
{
	public class AdventurerManager : MonoBehaviour
	{
		public List<string> EquippedItems { get; private set; }
		public List<DungeonSequenceObject> DungeonSequences;

		public void Equip(List<string> items)
		{
			EquippedItems = items;

			FindObjectOfType<MainManager>().SendOffAdventurer();
		}
	}
}
