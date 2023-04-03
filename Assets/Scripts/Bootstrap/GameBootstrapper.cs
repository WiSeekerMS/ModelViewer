using UnityEngine;

namespace Bootstrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}