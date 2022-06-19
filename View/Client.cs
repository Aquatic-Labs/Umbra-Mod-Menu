using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.Storage.Pickers.Provider;
using Umbra_Mod_Menu.Model;
using Umbra_Mod_Menu.Model.Controls;
using Umbra_Mod_Menu.View.ClientScenes;

namespace Umbra_Mod_Menu.View
{
    internal class Client : Menu
    {
        //private System.Windows.Forms.Timer _gameRunning;
        public Client(Background background) : base(background, Styles.DefaultMenuStyle, "Umbra Client", 20, new Point(10, 10))
        {
            var defScenePos = new Point(TopSep.Location.X + 2, TopSep.Location.Y - 30);
            var defSceneSize = new Size(Width, Height - 75);
            
            // Custom Menu Setup
            Opacity = .99;
            Location = new Point(300, 300);
            ShowInTaskbar = true;
            CloseButton.Click += (sender, e) =>
            {
                Owner.Close();
            };

            // Fix top from logo changes
            TopSep.Location = new Point(0, Logo.Bottom);
            NavPanel.Location = new Point(0, Logo.Bottom);
            NavPanel.Size = new Size(NavSep.Left, Height);
            NavSep.Top = TopSep.Bottom;

            Size = new Size(450, 350);
            Title.AutoSize = true;
            Title.Location = new Point(Width - Title.Width, 0);
            Content.Width = Width;
            CloseButton.Text = "✕";
            CloseButton.Size = new Size(25, 25);
            CloseButton.Location = new Point(Width - CloseButton.Width, 0);

            // Change version to GitHub link
            Version.Text = "GitHub";
            Version.Location = new Point(Width - Version.Width, Title.Bottom);
            Version.Click += (sender, args) =>
            {
                Utils.OpenBrowserUrl(Program.REPO_URL);
            };

            // Add Nav Buttons and their panels
            var defScene = new EmptyScene(this);
            var homeScene = new HomeScene(this, defScenePos, defSceneSize);

            NextNavButton = 2;
            AddNavButton(new MainNavButton("Home", Styles.DefaultMainNavButtonStyle, homeScene, true));
            AddNavButton(new MainNavButton("About", Styles.DefaultMainNavButtonStyle, defScene));
        }
    }
}
