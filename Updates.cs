using Octokit;
using System;

namespace UmbraRoR
{
    class Updates
    {
        public static bool updateAvailable;
        public static string latestVersion;
        public static async void CheckForUpdate()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("UmbraUpdateCheck"));
                var releases = await client.Repository.Release.GetAll("Acher0ns", "Umbra-Mod-Menu").ConfigureAwait(false);
                var latest = releases[0];
                latestVersion = latest.TagName;

                updateAvailable = latestVersion != Main.VERSION;
            }
            catch(Exception e)
            {
                UnityEngine.Debug.Log(e);
            }
        }
    }
}
