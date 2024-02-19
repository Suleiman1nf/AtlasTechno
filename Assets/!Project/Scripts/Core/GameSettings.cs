using UnityEngine;

namespace _Project.Scripts.Core
{
    [CreateAssetMenu(menuName = "SO/Create GameSettings", fileName = "GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField] public float MinFanSpeed { get; private set; }
        [field: SerializeField] public float MaxFanSpeed { get; private set; }
        [field: SerializeField] public float MinBodySpeed { get; private set; }
        [field: SerializeField] public float MaxBodySpeed { get; private set; }
    }
}