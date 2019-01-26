using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dungeon/New Dungeon Sequence")]
public class DungeonSequenceObject : ScriptableObject
{
	public string TrapName;
	public string CorrectItemName;

	public Sprite BeforeSequenceSnap;
	public Sprite AfterSequenceSnap;
}
