using DG.Tweening;
using UnityEngine;

namespace Assets
{
	public class AudioManager : MonoBehaviour
	{
		public AudioSource Background;
		public AudioSource Effects;

		public void PlayAudio(AudioClip clip)
		{
			Effects.PlayOneShot(clip);
		}

		public void SetLoopingEffect(AudioClip clip)
		{
			Effects.clip = clip;
			Effects.loop = true;
		}

		public void StopLoopingEffect()
		{
			Effects.clip = null;
		}

		public void SetBackground(AudioClip clip)
		{
			Tweener bgFader = Background.DOFade(0, .2f);
			bgFader.onComplete += delegate
			{
				Background.clip = clip;
				bgFader.onComplete = null;
				Background.DOFade(1, .2f);
			};
		}
	}
}
