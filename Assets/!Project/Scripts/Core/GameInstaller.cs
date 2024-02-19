using _Project.Scripts.Core.Audio;
using _Project.Scripts.OutlineService;
using _Project.Scripts.Selection;
using _Project.Scripts.ToolTip;
using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        public override void InstallBindings()
        {
            Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle().NonLazy();
            Container.Bind<SceneContentProvider>().FromComponentInHierarchy().AsSingle().NonLazy();
            AudioServiceInstaller.Install(Container);
            SelectServiceInstaller.Install(Container);
            OutlineServiceInstaller.Install(Container);
            ToolTipServiceInstaller.Install(Container);
            UIServiceInstaller.Install(Container);
        }
    }
}
