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
        
        public override void InstallBindings()
        {
            Container.InstallRegistry(_sceneManager);
            Container.InstallRegistry(_uiController);
            Container.InstallService<InputService>();
        }
    }
}