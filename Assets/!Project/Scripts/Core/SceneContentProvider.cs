using UnityEngine;

namespace _Project.Scripts.Core
{
    public class SceneContentProvider : MonoBehaviour
    {
        [field: SerializeField] public Camera Camera { get; private set; }
    }
}