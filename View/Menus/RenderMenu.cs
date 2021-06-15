using System;
using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using Render = UmbraMenu.Model.Cheats.Render;

namespace UmbraMenu.View
{
    public class RenderMenu : NormalMenu
    {
        public TogglableButton toggleActiveMods;
        public TogglableButton toggleInteractESP;
        public TogglableButton toggleMobESP;

        public RenderMenu() : base(6, 0, new Rect(10, 795, 20, 20), "RENDER MENU")
        {
            if (UmbraModGUI.Instance.lowResolutionMonitor)
            {
                toggleActiveMods = new TogglableButton(this, 1, "ACTIVE MODS : OFF", "ACTIVE MODS : ON", ToggleRenderMods, ToggleRenderMods);
            }
            else
            {
                toggleActiveMods = new TogglableButton(this, 1, "ACTIVE MODS : OFF", "ACTIVE MODS : ON", ToggleRenderMods, ToggleRenderMods, true);
            }
            toggleInteractESP = new TogglableButton(this, 2, "INTERACTABLES ESP : OFF", "INTERACTABLES ESP : ON", ToggleRenderInteractables, ToggleRenderInteractables);
            toggleMobESP = new TogglableButton(this, 3, "MOB ESP : OFF", "MOB ESP : ON", ToggleRenderMobs, ToggleRenderMobs);

            AddButtons(new List<Button>()
            {
                toggleActiveMods,
                toggleInteractESP,
                toggleMobESP
            });
            ActivatingButton = UmbraModGUI.Instance.mainMenu.toggleRender;
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }

        public override void Reset()
        {
            Render.renderMobs = false;
            Render.renderInteractables = false;
            Render.renderMods = UmbraModGUI.Instance.lowResolutionMonitor ? false : true;
            Render.DisableInteractables();
            base.Reset();
        }

        private void ToggleRenderInteractables()
        {
            if (Render.renderInteractables)
            {
                Render.DisableInteractables();
            }
            else
            {
                Render.EnableInteractables();
            }
            Render.renderInteractables = !Render.renderInteractables;
        }

        private void ToggleRenderMods()
        {
            Render.renderMods = !Render.renderMods;
        }

        private void ToggleRenderMobs()
        {
            Render.renderMobs = !Render.renderMobs;
        }
    }
}