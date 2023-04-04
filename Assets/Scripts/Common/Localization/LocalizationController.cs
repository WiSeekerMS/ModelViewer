using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Common.Localization
{
    public class LocalizationController : MonoBehaviour
    {
        public LocalizedString myString;
        
        public IEnumerator LocalizationInitialization()
        {
            yield return LocalizationSettings.InitializationOperation;
        }
    }
}