using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class Fan : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _audioCurve;
        [Header("Hinge")]
        [SerializeField] private Transform _hingeModel;
        [SerializeField] private float _hingeSpeed;
        [SerializeField] private float _minHingeAngle;
        [SerializeField] private float _maxHingeAngle;
        [Header("Fan")]
        [SerializeField] private Transform _fanModel;
        [SerializeField] private float _fanSpeed;
        [SerializeField] private float _fanAcceleration;
        
        private bool _fanEnabled = true;
        private float _fanCurrentSpeed;
        private bool _hingeEnabled;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Update()
        {
            RotateFan();

            if (_hingeEnabled)
            {
                RotateHinge();
            }
        }

        public void ToggleHinge()
        {
            _hingeEnabled = !_hingeEnabled;
        }

        public void ToggleFan()
        {
            _fanEnabled = !_fanEnabled;
        }

        private void RotateFan()
        {
            _fanCurrentSpeed += (_fanEnabled ? _fanAcceleration : -_fanAcceleration) * Time.deltaTime;
            _fanCurrentSpeed = Mathf.Clamp(_fanCurrentSpeed, 0, _fanSpeed);
            
            _fanModel.localEulerAngles += Vector3.forward * (_fanCurrentSpeed * Time.deltaTime);
            _audioSource.volume = _audioCurve.Evaluate(_fanCurrentSpeed / _fanSpeed);
        }

        private void RotateHinge()
        {

            _hingeModel.transform.localEulerAngles += Vector3.up * (_hingeSpeed * Time.deltaTime);

            float angle = _hingeModel.transform.localEulerAngles.y;
            if (angle > 180)
            {
                angle -= 360;
            }
            
            if (_hingeSpeed > 0 && angle >= _maxHingeAngle)
            {
                _hingeSpeed *= -1;
            }
            else if (_hingeSpeed < 0 && angle <= _minHingeAngle)
            {
                _hingeSpeed *= -1;
            }
        }
    }
}
