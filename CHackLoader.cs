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
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
