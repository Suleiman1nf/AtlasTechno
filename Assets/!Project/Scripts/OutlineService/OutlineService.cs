using _Project.Scripts.Selection;
using QuickOutline.Scripts;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.OutlineService
{
    public class OutlineService : MonoBehaviour
    {
        private SelectService _selectService;
        
        [Inject]
        public void Construct(SelectService selectService)
        {
            _selectService = selectService;
        }

        public void Start()
        {
            _selectService.OnSelect += OnSelect;
            _selectService.OnDeselect += OnDeselect;
        }

        public void OnDestroy()
        {
            _selectService.OnSelect -= OnSelect;
            _selectService.OnDeselect -= OnDeselect;
        }
        
        private void OnSelect(ISelectable selectable)
        {
            if(selectable is MonoBehaviour mono)
            {
                mono.gameObject.AddComponent<Outline>();
            }
        }

        private void OnDeselect(ISelectable selectable)
        {
            if(selectable is MonoBehaviour mono)
            {
                Destroy(mono.gameObject.GetComponent<Outline>());
            }
        }
    }
}