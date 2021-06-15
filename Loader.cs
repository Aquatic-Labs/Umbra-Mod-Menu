using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Octokit;
using UmbraMod = UmbraMenu.Model.UmbraMod;
using UmbraModGUI = UmbraMenu.View.UmbraModGUI;

namespace UmbraMenu
{
    public class Loader
    {
        public static GameObject umbraMod;
        public static GameObject umbraModGUI;

        public static void Load()
        {
            //RoR2.RoR2Application.isModded = true;
            while (umbraMod = GameObject.Find("Umbra Mod"))
                UnityEngine.Object.Destroy(umbraMod);
            while (umbraMod = GameObject.Find("Umbra Mod GUI"))
                UnityEngine.Object.Destroy(umbraMod);

            umbraMod = new GameObject("Umbra Mod");
            umbraModGUI = new GameObject("Umbra Mod GUI");
            umbraMod.AddComponent<UmbraMod>();
            umbraModGUI.AddComponent<UmbraModGUI>();

            UnityEngine.Object.DontDestroyOnLoad(umbraMod);
            UnityEngine.Object.DontDestroyOnLoad(umbraModGUI);

            LoadAssembly();
            CheckForUpdate();
            //gameObject.GetComponent<UmbraMod>().enabled = true;
            //gameObject.GetComponent<UmbraModGUI>().enabled = true;
            //gameObject.SetActive(true);
        }

        public static void Unload()
        {
            Model.Utility.SaveSettings();
            UnityEngine.Object.Destroy(umbraMod);
            UnityEngine.Object.Destroy(umbraModGUI);
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

                string[] versionSplit = Model.UmbraMod.VERSION.Split('.');
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
