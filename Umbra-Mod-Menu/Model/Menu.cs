using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Umbra_Mod_Menu.Model.Controls;

namespace Umbra_Mod_Menu.Model
{
    internal class Menu : DefaultForm
    {
        public Text Title { get; set; }
        public Text Footer { get; set; }
        public Text Subtitle { get; set; }
        public PictureBox Logo { get; set; }
        public Separator TopSep { get; set; }
        public Separator NavSep { get; set; }
        public Button CloseButton { get; set; }
        
        public Panel Content { get; set; }
        public Panel NavPanel { get; set; }

        public int NextNavButton = 1;
        
        public LinkedList<Scene> Scenes = new();

        public Menu(Form background, MenuStyle menuStyle, string titleText, int cornerRadius, Point location)
        {
            FormBorderStyle = menuStyle.BorderStyle;
            BackColor = menuStyle.BackColor;
            Opacity = menuStyle.Opacity;
            StartPosition = menuStyle.FormStartPosition;
            DesktopLocation = PointToScreen(location);
            ClientSize = menuStyle.Size;
            Owner = background;
            ShowInTaskbar = true;
            TopMost = menuStyle.TopMost;
            Region = Region.FromHrgn(Utils.CreateRoundRectRgn(0, 0, Width, Height, cornerRadius, cornerRadius));
            if (menuStyle.Draggable)
            {
                Load += (sender, e) =>
                {
                    ControlExtension.Draggable(this, true);
                };
            }

            var closeButton = new Button
            {
                Text = "━",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Size = new Size(27, 27),
                Location = new Point(Width - 27, 27 / 2 - 15),
                Font = Styles.DefaultTitleStyle.Font
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (sender, e) =>
            {
                WindowState = FormWindowState.Minimized;
            };
            Controls.Add(closeButton);
            CloseButton = closeButton;

            var content = new Panel
            {
                Size = new Size(Width, Height - 25),
                Location = new Point(0, 25),
                BackColor = ColorTranslator.FromHtml("#222222")
            };

            var title = new Text(titleText, new Point(Width - Styles.DefaultTitleStyle.Size.Width), Styles.DefaultTitleStyle);
            content.Controls.Add(title);
            Title = title;
            
            var subtitle = new Text($"v{Program.VERSION}", new Point(Width - 48, title.Bottom), Styles.DefaultTitleStyle);
            subtitle.ForeColor = ColorTranslator.FromHtml("#40CCFF");
            subtitle.AutoSize = true;
            subtitle.Font = new Font("Arial", 10, FontStyle.Regular);
            content.Controls.Add(subtitle);
            Subtitle = subtitle;

            var footer = new Text("Copyright © 2022 Aquatic Labs", new Point(Width - Styles.DefaultFooterStyle.Size.Width, Height - Styles.DefaultFooterStyle.Size.Height - 4), Styles.DefaultFooterStyle);
            content.Controls.Add(footer);
            Footer = footer;

            // Logo Container
            var logo = new PictureBox
            {
                Location = new Point(14, 0),
                Size = new Size(55, 55),
                Image = menuStyle.Logo,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            content.Controls.Add(logo);
            Logo = logo;
            
            var topSep = new Separator(new Point(0, logo.Bottom), Width, ColorTranslator.FromHtml("#333333"));
            content.Controls.Add(topSep);
            TopSep = topSep;

            var navSep = new Separator(new Point(Styles.DefaultMainNavButtonStyle.Size.Width, logo.Height), Height - logo.Height, ColorTranslator.FromHtml("#333333"), false);
            content.Controls.Add(navSep);
            NavSep = navSep;

            var navPanel = new Panel()
            {
                Size = new Size(navSep.Left, Height - topSep.Bottom),
                Location = new Point(0, topSep.Bottom)
            };
            content.Controls.Add(navPanel);
            NavPanel = navPanel;
            
            SizeChanged += (sender, e) =>
            {
                Region = Region.FromHrgn(Utils.CreateRoundRectRgn(0, 0, Width, Height, cornerRadius, cornerRadius));
            };
            Controls.Add(content);
            Content = content;
        }

        protected void AddNavButton(MainNavButton button)
        {
            button.Location = new Point(NavPanel.Left, NextNavButton);
            NextNavButton += button.Size.Height;
            NavPanel.Controls.Add(button);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            foreach (var scene in Scenes)
            {
                scene.Location = new Point(NavSep.Right, TopSep.Bottom);
            }
        }
    }
}
