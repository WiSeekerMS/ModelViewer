using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Common.Localization
{
    public class LocalizationController : MonoBehaviour
    {
        public IEnumerator LocalizationInitialization()
        {
            yield return LocalizationSettings.InitializationOperation;
        }
    }
}