using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using RoR2;
using UnityEngine;
using Octokit;

namespace UmbraMenu
{
    public class Loader
    {
        public static GameObject gameObject;

        public static void Load()
        {
            //RoR2.RoR2Application.isModded = true;
            while (gameObject = GameObject.Find("Umbra Menu"))
                UnityEngine.Object.Destroy(gameObject);
            gameObject = new GameObject("Umbra Menu");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);
            var types = Assembly.GetExecutingAssembly().GetTypes().ToList().Where(t => t.BaseType == typeof(MonoBehaviour) && !t.IsNested);
            foreach (var type in types)
            {
                var component = (MonoBehaviour)gameObject.AddComponent(type);
                component.enabled = false;
            }
            LoadAssembly();
            CheckForUpdate();
            gameObject.GetComponent<UmbraMenu>().enabled = true;
            gameObject.SetActive(true);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
        }

        private static void LoadAssembly()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                String resourceName = "UmbraMenu." +
                   new AssemblyName(args.Name).Name + ".dll";

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }

        public static bool updateAvailable, devBuild, upToDate = true;
        public static string latestVersion;
        private static async void CheckForUpdate()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("UmbraUpdateCheck"));
                var releases = await client.Repository.Release.GetAll("Acher0ns", "Umbra-Mod-Menu").ConfigureAwait(false);
                var latest = releases[0];
                latestVersion = latest.TagName;

                string[] versionSplit = UmbraMenu.VERSION.Split('.');
                string[] latestVersionSplit = latestVersion.Split('.');

                for (int i = 0; i < versionSplit.Length; i++)
                {
                    int versionNumber = int.Parse(versionSplit[i]);
                    int latestVersionNumber = int.Parse(latestVersionSplit[i]);
                    if (versionNumber < latestVersionNumber)
                    {
                        upToDate = false;
                        updateAvailable = true;
                        break;
                    }
                    else if (versionNumber > latestVersionNumber)
                    {
                        upToDate = false;
                        devBuild = true;
                        break;
                    }
                }
            }
            catch (RateLimitExceededException)
            {
                upToDate = true;
            }
        }
    }
}
