using _Project.Scripts.Core.Audio;
using _Project.Scripts.OutlineService;
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
            AudioServiceInstaller.Install(Container);
            SelectServiceInstaller.Install(Container);
            OutlineServiceInstaller.Install(Container);
            ToolTipServiceInstaller.Install(Container);
        }
    }
}
