using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Gameplay
{
    public class Button3D : MonoBehaviour
    {
        private const float ANIMATION_DURATION = 0.1f;
        private const float CLICK_Y_SCALE = 0.1f;
        
        [SerializeField] private Transform _model;
        [Space(20)]
        public UnityEvent onClick;
        
        private float _startYScale;
        private bool _enabled;
        private bool _isPressed;

        private void Awake()
        {
            _startYScale = _model.localScale.y;
        }

        private void OnMouseDown()
        {
            _model.DOScaleY(CLICK_Y_SCALE, ANIMATION_DURATION);
        }

        private void OnMouseUp()
        {
            _model.DOScaleY(_startYScale, ANIMATION_DURATION);
        }

        private void OnMouseUpAsButton()
        {
            onClick?.Invoke();
        }
    }
}
