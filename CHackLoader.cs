using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

namespace RoRCheats
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
