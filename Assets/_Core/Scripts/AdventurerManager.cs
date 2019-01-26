using System.Collections.Generic;
using UnityEngine;

namespace Assets._Core.Scripts
{
	public class AdventurerManager : MonoBehaviour
	{
		private List<DungeonItem> _equippedItems;
		private List<DungeonItem> _allItems;
		private List<DungeonTrap> _allTraps;
		public List<DungeonSequence> Sequences { get; private set; }

		public List<DungeonSequenceObject> DungeonSequences;

		public void Equip(List<DungeonItem> items)
		{
			_equippedItems = items;

			_allItems = new List<DungeonItem>
			{
				new DungeonItem("Silver rapier"),
				new DungeonItem("Strength potion"),
				new DungeonItem("Holy water")
			};

			_allTraps = new List<DungeonTrap>
			{
				new DungeonTrap("Werewolf"),
				new DungeonTrap("Falling rocks"),
				new DungeonTrap("Demons")
			};
			
			Sequences = new List<DungeonSequence>
			{
				new DungeonSequence(_allTraps[0], _allItems[0],_allItems[0], null, null),
				new DungeonSequence(_allTraps[1], _allItems[1],_allItems[1], null, null),
				new DungeonSequence(_allTraps[2], _allItems[2],_allItems[2], null, null)
			};
		}

		public void TempFixedEquip()
		{
			Equip(_allItems);
		}
	}
}
