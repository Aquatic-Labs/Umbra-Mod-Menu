using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbra_Mod_Menu.Model;
using Umbra_Mod_Menu.Model.Controls;
using Umbra_Mod_Menu.View.MainMenuScenes;

namespace Umbra_Mod_Menu.View
{
    internal class MainMenu : Menu
    {
        public MainMenu(Background background) : base(background, Styles.DefaultMenuStyle, "Umbra Mod Menu", 20, new Point(10, 10))
        {
            var defScenePos = new Point(TopSep.Location.X + 2, TopSep.Location.Y - 30);
            var defSceneSize = new Size(Width, Height - 75);
            
            var defScene = new EmptyScene(this);
            var playerScene = new PlayerScene(this, defScenePos, defSceneSize);

            AddNavButton(new MainNavButton("Player", Styles.DefaultMainNavButtonStyle, playerScene, true));
            AddNavButton(new MainNavButton("Render", Styles.DefaultMainNavButtonStyle, defScene));
            AddNavButton(new MainNavButton("World", Styles.DefaultMainNavButtonStyle, defScene));
            AddNavButton(new MainNavButton("Lobby", Styles.DefaultMainNavButtonStyle, defScene));
            AddNavButton(new MainNavButton("Misc", Styles.DefaultMainNavButtonStyle, defScene));
        }
    }
}
