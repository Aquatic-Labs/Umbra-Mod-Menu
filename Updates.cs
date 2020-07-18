using Octokit;

namespace UmbraRoR
{
    class Updates
    {
        public static bool updateAvailable, devBuild, upToDate = true;
        public static string latestVersion;

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
