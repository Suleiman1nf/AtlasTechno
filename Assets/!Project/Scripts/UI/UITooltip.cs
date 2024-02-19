using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class UITooltip : MonoBehaviour, ITooltip
    {
        private const float FADE_DURATION = 0.5f;
        
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text _text;
        
        private void Awake()
        {
            Hide(0);
        }

        public void Show(string text)
        {
            _text.SetText(text);
            _canvasGroup.DOFade(1, FADE_DURATION);
        }

        public void Hide()
        {
            Hide(FADE_DURATION);
        }

        private void Hide(float duration)
        {
            _canvasGroup.DOFade(0, duration);
        }
    }
}
