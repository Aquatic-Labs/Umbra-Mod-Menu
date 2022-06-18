using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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

            Logo.Location = new Point(14, 25);

            // Fix top from logo changes
            TopSep.Location = new Point(0, Logo.Bottom);
            NavPanel.Location = new Point(0, Logo.Bottom);
            NavPanel.Size = new Size(NavSep.Left, Height);
            NavSep.Top = TopSep.Bottom;

            Size = new Size(450, 350);
            Title.AutoSize = true;
            Title.Location = new Point(Width - Title.Width, Logo.Bottom - Title.Height * 2);
            
            // Change version to GitHub link
            Version.Text = "GitHub";
            Version.Location = new Point(Width - Version.Width, Title.Bottom);
            Version.Click += (sender, args) =>
            {
                Utils.OpenBrowserUrl(Program.REPO_URL);
            };
            
            // Add close X button on top
            var topPanel = new Panel
            {
                Size = new Size(Width, 25),
                Location = new Point(0, 0),
                BackColor = ColorTranslator.FromHtml("#333333")
            };
            Controls.Add(topPanel);

            var closeButton = new Button
            {
                Text = "X",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Size = new Size(23, 23),
                Location = new Point(Width - 25, topPanel.Height / 2 - 11)
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (sender, e) =>
            {
                Owner.Close();
            };
            topPanel.MouseDown += (sender, e) => { Focus(); };
            topPanel.Controls.Add(closeButton);
            
            // Add Nav Buttons and their panels
            var defScene = new EmptyScene(this);
            var homeScene = new HomeScene(this, defScenePos, defSceneSize);

            NextNavButton = 2;
            AddNavButton(new MainNavButton("Home", Styles.DefaultMainNavButtonStyle, homeScene, true));
            AddNavButton(new MainNavButton("About", Styles.DefaultMainNavButtonStyle, defScene));
        }
    }
}
