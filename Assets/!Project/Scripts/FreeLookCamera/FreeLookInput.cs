using Cinemachine;
using UnityEngine;

namespace _Project.Scripts.FreeLookCamera
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class FreeLookInput : MonoBehaviour
    {
        private CinemachineFreeLook _freeLookCamera;

        private readonly string _xAxisName = "Mouse X";
        private readonly string _yAxisName = "Mouse Y";

        private void Start()
        {
            _freeLookCamera = GetComponent<CinemachineFreeLook>();
            _freeLookCamera.m_XAxis.m_InputAxisName = "";
            _freeLookCamera.m_YAxis.m_InputAxisName = "";
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _freeLookCamera.m_XAxis.m_InputAxisValue = Input.GetAxis(_xAxisName);
                _freeLookCamera.m_YAxis.m_InputAxisValue = Input.GetAxis(_yAxisName);
            }
            else
            {
                _freeLookCamera.m_XAxis.m_InputAxisValue = 0;
                _freeLookCamera.m_YAxis.m_InputAxisValue = 0;
            }
        }
    }
}
