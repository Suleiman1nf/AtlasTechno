using UnityEngine;

namespace _Project.Scripts.Core.Audio
{
    public class AudioService : MonoBehaviour
    {
        [field: SerializeField] public GameAudioData GameAudioData { get; private set; }
        [SerializeField] private AudioSource _audioSourceFX;

        public void MuteFX()
        {
            _audioSourceFX.mute = true;
        }

        public void UnmuteFX()
        {
            _audioSourceFX.mute = false;
        }

        public void PlayFX(AudioClip clip)
        {
            _audioSourceFX.PlayOneShot(clip);
        }
    }
}