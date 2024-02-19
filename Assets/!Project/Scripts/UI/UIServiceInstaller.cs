using Zenject;

namespace _Project.Scripts.UI
{
    public class UIServiceInstaller : Installer<UIServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
        }
    }
}