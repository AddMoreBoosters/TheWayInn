using UnityEngine;

namespace Assets._Core.Scripts
{
	public class DungeonSequence
	{
		public DungeonTrap Trap { get; }
		public DungeonItem CorrectItem { get; }
		public DungeonItem EquippedItem { get; }

		public Sprite BeforeSequenceSnap { get; }
		public Sprite AfterSequenceSnap { get; }

		public bool Success => CorrectItem == EquippedItem;

		public DungeonSequence(DungeonTrap trap, DungeonItem correctItem, DungeonItem equippedItem, Sprite beforeSnap, Sprite afterSnap)
		{
			Trap = trap;
			CorrectItem = correctItem;
			EquippedItem = equippedItem;

			BeforeSequenceSnap = beforeSnap;
			AfterSequenceSnap = afterSnap;
		}
	}

	public class DungeonTrap
	{
		public string Name { get; }

		public DungeonTrap(string name)
		{
			Name = name;
		}
	}
	
	public class DungeonItem
	{
		public string Name { get; }
		public Sprite Sprite { get; }

		public DungeonItem(string name)
		{
			Name = name;
			//'Sprite = sprite;
		}
	}
}