using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using Umbra_Mod_Menu.Model;
using Umbra_Mod_Menu.View;
using versionmanagernet;
using Utils = Umbra_Mod_Menu.Model.Utils;

namespace Umbra_Mod_Menu
{
    internal static class Program
    {
        public const string VERSION = "3.0.0",
            REPO_OWNER = "Aquatic-Labs",
            REPO_NAME = "Umbra-Mod-Menu",
            REPO_URL = $"https://github.com/{REPO_OWNER}/{REPO_NAME}";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var vm = new VersionManager(REPO_OWNER, REPO_NAME, VERSION);
            vm.OnOutdated += (sender, eventArgs) => {
                if (MessageBox.Show($"Version v{eventArgs.tag_name} is now available. Visit release page now?", "Update Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    Utils.OpenBrowserUrl($"{REPO_URL}/releases/latest");
                }
            };
            vm.CheckStatus();

            ApplicationConfiguration.Initialize();

            var background = new Background();
            var client = new Client(background);
            var mainMenu = new MainMenu(background);

            Application.Run(client);
        }
    }
}