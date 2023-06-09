﻿using Common.Extensions;
using Configs;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    [CreateAssetMenu(fileName = "RegistryInstaller", menuName = "Installers/RegistryInstaller")]
    public class RegistryInstaller : ScriptableObjectInstaller<RegistryInstaller>
    {
        [SerializeField] private MainConfig _mainConfig;

        public override void InstallBindings()
        {
            Container.InstallRegistry(_mainConfig);
        }
    }
}