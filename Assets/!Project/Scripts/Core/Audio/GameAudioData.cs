using UnityEngine;

namespace _Project.Scripts.Core.Audio
{
    [CreateAssetMenu(menuName = "SO/Create GameAudioData", fileName = "GameAudio", order = 0)]
    public class GameAudioData : ScriptableObject
    {
        [field: SerializeField] public AudioClip ButtonClickAudio { get; private set; }
    }
}