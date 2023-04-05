using Common;
using Common.Localization;
using Factories;
using InteractiveObject.Base;
using Inventory;
using Services;
using UI;
using UI.Buttons;
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

            Container.InstallFactory<BaseInteractiveObject, InteractiveObjectFactory>();
            Container.InstallFactory<ObjectButton, ObjectButtonFactory>();

            Container.Bind<InteractiveObjectInventory>().AsSingle();
            Container.Bind<ObjectButtonInventory>().AsSingle();
            Container.Bind<ObjectDataInventory>().AsSingle();
        }
    }
}