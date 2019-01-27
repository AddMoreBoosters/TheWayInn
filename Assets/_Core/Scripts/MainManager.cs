using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Core.Scripts
{
	/// <summary> Manager for next scene/background (slideshow-system) </summary>
	public class MainManager : MonoBehaviour
	{
		[SerializeField] private Button _startButton;
		[Space]
		[SerializeField] private AdventurerManager _adventurerManager;
		[SerializeField] private DialogueManager _dialogueManager;
		[SerializeField] private SnapTrapManager _snapTrapManager;
		[Space]
		[SerializeField] private GameObject _startScreen;
		[SerializeField] private Transform _introContainer;
		[SerializeField] private Transform _backgroundContainer;
		[SerializeField] private GameObject _winScreen;
		[Space]
		public AudioClip InnBgAudio;
		
		private void Start()
		{
			_startButton.onClick.AddListener(StartIntro);
			_startScreen.SetActive(true);
			_introContainer.gameObject.SetActive(false);
			_backgroundContainer.gameObject.SetActive(false);
			_winScreen.SetActive(false);
			FindObjectOfType<DialogueManager>().HideDialogues();
		}

		private void StartIntro()
		{
			_startScreen.SetActive(false);
			_introContainer.gameObject.SetActive(true);

			FindObjectOfType<AudioManager>().SetBackground(InnBgAudio);

			// Play video, slides, or w/e

			// temp intro skip
			NewAdventurer();
		}

		/// <summary> Starting the adventurer-cycle </summary>
		public void NewAdventurer()
		{
			// Randomize adventurer-silhouette or w/e

			// Fade or animate into first game-slide?
			_introContainer.gameObject.SetActive(false);
			_backgroundContainer.gameObject.SetActive(true);
			ShowOnly(_backgroundContainer.GetChild(0).gameObject);
		}

		/// <summary> Wake up, fade in screen with phone, and new notifications </summary>
		public void SendOffAdventurer()
		{
			_backgroundContainer.gameObject.SetActive(false);
			StartCoroutine(NewDayTimer());
		}
		
		// Animates sequence, going to bed, waking up, checking phone
		private IEnumerator NewDayTimer()
		{
			print("Bye adventurer");
			yield return new WaitForSeconds(1);
			print("Goodnight");
			yield return new WaitForSeconds(1);
			print("Good morning");
			yield return new WaitForSeconds(1);
			print("Checks phone");
			ShowOnly(_backgroundContainer.gameObject);
			_snapTrapManager.SetNewSnaps(_adventurerManager.DungeonSequences, _adventurerManager.EquippedItems);
		}

		public void ShowOnlyNS(GameObject slide)
		{
			ShowOnly(slide);
		}

		/// <summary> Deactivates all siblings except one </summary>
		public static void ShowOnly(GameObject slide)
		{
			foreach (Transform sibling in slide.transform.parent)
			{
				sibling.gameObject.SetActive(false);
			}

			slide.SetActive(true);
		}
	}
}
