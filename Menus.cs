using RewiredConsts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace UmbraMenu
{
    public class Menus : Styles
    {
        public List<Menu> menus = new List<Menu>();
        public GUIStyle style;
        public float delay = 0, widthSize = 350;

        public class Menu
        {
            public int id;
            public string menuTitle = "Title";
            public bool enabled = false;
            public Rect rect;
            public bool ifDragged = false;
            public int numberOfButtons = 0;

        }

        public void SetBackground(int windowID)
        {
            WriteToLog("Running SetBackground");
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45), "", style);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    //menu.ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                //if (!menu.ifDragged)
                //{
                    //menu.enabled = !menu.enabled;
                //}
                //menu.ifDragged = false;
            }
            GUI.DragWindow();
        }

        public Menu CreateNewMenu(int x, int y, int id, string menuTitle, int numberOfButtons)
        {
            WriteToLog("Rnning CreateNewMenu");
            Menu menu = new Menu();
            menu.id = id;
            menu.menuTitle = menuTitle;
            menu.numberOfButtons = numberOfButtons;
            menu.rect = new Rect(x, y, widthSize, 20);
            menus.Add(menu);
            return menu;
        }

        public Menu GetMenuByWindowID(int windowID)
        {
            WriteToLog("Rnning BuildMenu");
            Menu menu = menus[windowID - 1];
            return menu;
        }

        public Menu BuildMenu(int x, int y, int id, string menuTitle, int numberOfButtons)
        {
            WriteToLog("Rnning BuildMenu");
            var menu = CreateNewMenu(x, y, id, menuTitle, numberOfButtons);
            menu.rect = GUI.Window(id, menu.rect, new GUI.WindowFunction(SetBackground), "", new GUIStyle());
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * numberOfButtons), "", BgStyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), menuTitle, LabelStyle);
            return menu;
        }

        public void BuildAllMenus()
        {
            WriteToLog("Rnning BuildAllMenus");
            BuildStyles();
            style = MainBgStyle;
            var mainMenu = BuildMenu(10, 10, 1, "Main Menu", 10);
            WriteToLog(mainMenu.menuTitle);
        }

        public static void WriteToLog(string logContent)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "UmbraLog.txt"), true))
            {
                outputFile.WriteLine(UmbraMenu.log + logContent);
            }
        }
    }
}
