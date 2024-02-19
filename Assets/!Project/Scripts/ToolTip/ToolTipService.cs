using _Project.Scripts.Selection;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.ToolTip
{
    public class ToolTipService : MonoBehaviour
    {
        private SelectService _selectService;
        private ITooltipViewer _tooltipViewer;
        
        [Inject]
        public void Construct(SelectService selectService, ITooltipViewer tooltipViewer)
        {
            _selectService = selectService;
            _tooltipViewer = tooltipViewer;
        }

        public void Start()
        {
            _selectService.OnSelect += OnSelect;
            _selectService.OnDeselect += OnDeselect;
        }

        private void OnSelect(ISelectable selectable)
        {
            if(selectable is ToolTipContainer toolTipContainer)
            {
                _tooltipViewer.Show(toolTipContainer.text);
            }
        }

        private void OnDeselect(ISelectable selectable)
        {
            _tooltipViewer.Hide();
        }

        public void OnDestroy()
        {
            _selectService.OnSelect -= OnSelect;
            _selectService.OnDeselect -= OnDeselect;
        }
    }
}