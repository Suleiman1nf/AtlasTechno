using System;
using Cinemachine;
using UnityEngine;

namespace _Project.Scripts.Camera
{
    [SaveDuringPlay]
    [RequireComponent(typeof(CinemachineFreeLook))]
    class CinemachineFreeLookZoom : MonoBehaviour
    {
        public CinemachineFreeLook.Orbit[] originalOrbits = Array.Empty<CinemachineFreeLook.Orbit>();

        [Range(0.01f, 1f)]
        public float minOrbitScale = 0.5f;

        [Range(1F, 5f)]
        public float maxOrbitScale = 1;

        [AxisStateProperty]
        public AxisState zAxis = new AxisState(0, 1, false, true, 50f, 0.1f, 0.1f, "Mouse ScrollWheel", false);

        private CinemachineFreeLook _freeLook;

        private void OnValidate()
        {
            minOrbitScale = Mathf.Max(0.01f, minOrbitScale);
            maxOrbitScale = Mathf.Max(minOrbitScale, maxOrbitScale);
        }

        private void Awake()
        {
            _freeLook = GetComponentInChildren<CinemachineFreeLook>();
            if (_freeLook != null && originalOrbits.Length == 0)
            {
                zAxis.Update(Time.deltaTime);
                float scale = Mathf.Lerp(minOrbitScale, maxOrbitScale, zAxis.Value);
                for (int i = 0; i < Mathf.Min(originalOrbits.Length, _freeLook.m_Orbits.Length); i++)
                {
                    _freeLook.m_Orbits[i].m_Height = originalOrbits[i].m_Height * scale;
                    _freeLook.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius * scale;
                }
            }
        }

        private void Update()
        {
            if (_freeLook == null)
            {
                return;
            }
            
            if (originalOrbits.Length != _freeLook.m_Orbits.Length)
            {
                originalOrbits = new CinemachineFreeLook.Orbit[_freeLook.m_Orbits.Length];
                Array.Copy(_freeLook.m_Orbits, originalOrbits, _freeLook.m_Orbits.Length);
            }
            zAxis.Update(Time.deltaTime);
            float scale = Mathf.Lerp(minOrbitScale, maxOrbitScale, zAxis.Value);
            for (int i = 0; i < Mathf.Min(originalOrbits.Length, _freeLook.m_Orbits.Length); i++)
            {
                _freeLook.m_Orbits[i].m_Height = originalOrbits[i].m_Height * scale;
                _freeLook.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius * scale;
            }
        }
    }
}
