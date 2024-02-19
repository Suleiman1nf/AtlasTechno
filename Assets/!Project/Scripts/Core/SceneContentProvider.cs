using _Project.Scripts.Gameplay;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public class SceneContentProvider : MonoBehaviour
    {
        [field: SerializeField] public Camera Camera { get; private set; }
        [field: SerializeField] public Fan Fan { get; private set; }
    }
}