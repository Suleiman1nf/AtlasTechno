using _Project.Scripts.Selection;
using _Project.Scripts.ToolTip;
using Zenject;

namespace _Project.Scripts.Core
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneContentProvider>().FromComponentInHierarchy().AsSingle().NonLazy();
            SelectServiceInstaller.Install(Container);
            ToolTipServiceInstaller.Install(Container);
        }
    }
}
