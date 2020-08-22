using System.Linq;
using System.Reflection;
using UnityEngine;

namespace UmbraRoR
{
    public class Loader
    {
        //static GameObject gameObject;

        /*public static void Load()
        {
            gameObject = new GameObject();
            gameObject.AddComponent<Main>();
            Object.DontDestroyOnLoad(gameObject);
            Utility.LoadAssembly();
            Updates.CheckForUpdate();
        }*/

        public static GameObject gameObject;

        public static void Load()
        {
            //RoR2.RoR2Application.isModded = true;
            while (gameObject = GameObject.Find("Umbra Menu"))
                GameObject.Destroy(gameObject);
            gameObject = new GameObject("Umbra Menu");
            Object.DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);
            var types = Assembly.GetExecutingAssembly().GetTypes().ToList().Where(t => t.BaseType == typeof(MonoBehaviour) && !t.IsNested);
            foreach (var type in types)
            {
                var component = (MonoBehaviour)gameObject.AddComponent(type);
                component.enabled = false;
            }
            gameObject.GetComponent<Main>().enabled = true;
            gameObject.SetActive(true);
            Utility.LoadAssembly();
            Updates.CheckForUpdate();
        }

        public static void Unload()
        {
            Object.Destroy(gameObject);
        }
    }
}
