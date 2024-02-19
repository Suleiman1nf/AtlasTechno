using _Project.Scripts.UI;
using Zenject;

namespace _Project.Scripts.ToolTip
{
    public class ToolTipServiceInstaller : Installer<ToolTipServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ITooltipViewer>().To<UITooltipViewer>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<ToolTipService>().FromNewComponentOnNewGameObject()
                .UnderTransformGroup("Services").AsSingle().NonLazy();
        }
    }
}