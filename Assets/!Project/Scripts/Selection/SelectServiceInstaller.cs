using Zenject;

namespace _Project.Scripts.Selection
{
    public class SelectServiceInstaller : Installer<SelectServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SelectService>().FromNewComponentOnNewGameObject()
                .UnderTransformGroup("Services").AsSingle().NonLazy();
        }
    }
}