using Common;
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
        
        public override void InstallBindings()
        {
            Container.InstallRegistry(_sceneManager);
            Container.InstallRegistry(_uiController);
            Container.InstallRegistry(_playerController);
            Container.InstallService<InputService>();
        }
    }
}