using Common;
using Common.Localization;
using Services;
using UI;
using UnityEngine;
using Utils.Extensions;
using Zenject;

namespace Bootstrap
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private SceneManager _sceneManager;
        [SerializeField] private UIController _uiController;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private LocalizationController _localizationController;
        
        public override void InstallBindings()
        {
            Container.InstallRegistry(_sceneManager);
            Container.InstallRegistry(_uiController);
            Container.InstallRegistry(_playerController);
            Container.InstallRegistry(_localizationController);
            Container.InstallService<InputService>();
        }
    }
}