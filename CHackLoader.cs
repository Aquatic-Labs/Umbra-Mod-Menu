using UnityEngine;

namespace UmbraRoR
{
    public class Loader
    {
        static GameObject gameObject;

        public static void Load()
        {
            gameObject = new GameObject();
            gameObject.AddComponent<Main>();
            Object.DontDestroyOnLoad(gameObject);
            Utility.LoadAssembly();
            Updates.CheckForUpdate();
        }

        public static void Unload()
        {
            Object.Destroy(gameObject);
        }
    }
}
