using Zenject;

namespace _Project.Scripts.OutlineService
{
    public class OutlineServiceInstaller : Installer<OutlineServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<OutlineService>().FromNewComponentOnNewGameObject()
                .UnderTransformGroup("Services").AsSingle().NonLazy();
        }
    }
}