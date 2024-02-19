using _Project.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private Slider _fanSlider;
        [SerializeField] private Slider _bodySlider;
        
        private GameSettings _gameSettings;
        private SceneContentProvider _sceneContentProvider;
        
        [Inject]
        public void Construct(GameSettings gameSettings, SceneContentProvider sceneContentProvider)
        {
            _gameSettings = gameSettings;
            _sceneContentProvider = sceneContentProvider;
        }

        public void Start()
        {
            _fanSlider.minValue = _gameSettings.MinFanSpeed;
            _fanSlider.maxValue = _gameSettings.MaxFanSpeed;

            _bodySlider.minValue = _gameSettings.MinBodySpeed;
            _bodySlider.maxValue = _gameSettings.MaxBodySpeed;

            _fanSlider.onValueChanged.AddListener(OnFanSliderChanged);
            _bodySlider.onValueChanged.AddListener(OnBodySliderChanged);

            _fanSlider.value = _fanSlider.minValue + (_fanSlider.maxValue - _fanSlider.minValue) / 2;
            _bodySlider.value = _bodySlider.minValue + (_bodySlider.maxValue - _bodySlider.minValue) / 2;
        }

        public void OnDestroy()
        {
            _fanSlider.onValueChanged.RemoveListener(OnFanSliderChanged);
            _bodySlider.onValueChanged.RemoveListener(OnBodySliderChanged);
        }

        private void OnFanSliderChanged(float val)
        {
            _sceneContentProvider.Fan.ChangeFanMaxSpeed(val);
        }
        
        private void OnBodySliderChanged(float val)
        {
            _sceneContentProvider.Fan.ChangeHingeMaxSpeed(val);
        }
    }
}