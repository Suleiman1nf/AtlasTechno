using System;
using _Project.Scripts.Core;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Selection
{
    public class SelectService : MonoBehaviour
    {
        public event Action<ISelectable> OnSelect;
        public event Action<ISelectable> OnDeselect;
        
        private SceneContentProvider _sceneContentProvider;
        
        private ISelectable _lastSelectable;

        [Inject]
        public void Construct(SceneContentProvider sceneContentProvider)
        {
            _sceneContentProvider = sceneContentProvider;
        }
        
        public void Update()
        {
            Ray ray = _sceneContentProvider.Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                ISelectable selectable = hit.transform.GetComponent<ISelectable>();
                if (selectable == _lastSelectable)
                {
                    return;
                }
                
                if (selectable != null) 
                {
                    Select(selectable);
                }
                else if(_lastSelectable != null)
                {
                    Deselect(_lastSelectable);
                }
            }
        }

        private void Select(ISelectable selectable)
        {
            if (_lastSelectable != null) 
            {
                Deselect(_lastSelectable);
            }

            _lastSelectable = selectable;
            OnSelect?.Invoke(selectable);
        }

        private void Deselect(ISelectable selectable)
        {
            OnDeselect?.Invoke(selectable);
            if (selectable == _lastSelectable)
            {
                _lastSelectable = null;
            }
        }
    }
}