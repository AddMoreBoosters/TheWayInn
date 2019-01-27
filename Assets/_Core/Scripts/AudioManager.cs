using DG.Tweening;
using UnityEngine;

namespace Assets._Core.Scripts
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

			if (clip)
			{
				bgFader.onComplete += delegate
				{
					Background.clip = clip;
					Background.Play();
					bgFader.onComplete = null;
					Background.DOFade(.5f, .2f);
				};
			}

			else
			{
				Background.clip = null;
			}
		}
	}
}