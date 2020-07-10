using Octokit;
using System;

namespace UmbraRoR
{
    class Updates
    {
        public static bool updateAvailable;
        public static string latestVersion;
        public static bool devBuild;
        public static bool upToDate;

        public static async void CheckForUpdate()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("UmbraUpdateCheck"));
                var releases = await client.Repository.Release.GetAll("Acher0ns", "Umbra-Mod-Menu").ConfigureAwait(false);
                var latest = releases[0];
                latestVersion = latest.TagName;

                string[] versionSplit = Main.VERSION.Split('.');
                string[] latestVersionSplit = latestVersion.Split('.');

                for (int i = 0; i < versionSplit.Length; i++)
                {
                    int versionNumber = int.Parse(versionSplit[i]);
                    int latestVersionNumber = int.Parse(latestVersionSplit[i]);
                    if (versionNumber < latestVersionNumber)
                    {
                        updateAvailable = true;
                        break;
                    }
                    else if (versionNumber > latestVersionNumber)
                    {
                        devBuild = true;
                        break;
                    }
                }
                
                if (!devBuild && !updateAvailable)
                {
                    upToDate = true;
                }
            }
            catch(Exception e)
            {
                UnityEngine.Debug.Log(e);
            }
        }
    }
}
