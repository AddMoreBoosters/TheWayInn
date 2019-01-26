using UnityEngine;

namespace Assets._Core.Scripts
{
	[CreateAssetMenu(menuName = "Dungeon/New Dungeon Sequence")]
	public class DungeonSequenceObject : ScriptableObject
	{
		public string TrapName;
		public string CorrectItemName;

		public Sprite BeforeSequenceSnap;
		public Sprite AfterSequenceSnap;
	}
}
