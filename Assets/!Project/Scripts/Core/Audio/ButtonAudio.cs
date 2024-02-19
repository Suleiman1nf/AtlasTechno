using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Audio
{
    public class ButtonAudio : MonoBehaviour
    {
        private AudioService _audioService;
        
        [Inject]
        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }

        public void PlayClick()
        {
            _audioService.PlayFX(_audioService.GameAudioData.ButtonClickAudio);
        }
    }
}