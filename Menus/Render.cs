using System;
using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using UmbraMenu.monsoon;

namespace UmbraMenu.Menus
{
    public class Render : Menu
    {
        private static readonly IMenu render = new NormalMenu(6, new Rect(10, 795, 20, 20), "RENDER MENU");

        private static Camera camera;

        public static List<PurchaseInteraction> purchaseInteractions = new List<PurchaseInteraction>();
        public static List<BarrelInteraction> barrelInteractions = new List<BarrelInteraction>();
        public static List<PressurePlateController> secretButtons = new List<PressurePlateController>();
        public static List<ScrapperController> scrappers = new List<ScrapperController>();
        public static List<HurtBox> hurtBoxes;
        public static bool onRenderIntEnable = true, renderMobs, renderInteractables, renderMods = true;

        public Button toggleActiveMods;
        public Button toggleInteractESP;
        public Button toggleMobESP;

        public Render() : base(render)
        {
            if (UmbraMenu.characterCollected)
            {
                if (UmbraMenu.lowResolutionMonitor)
                {
                    toggleActiveMods = new Button(new TogglableButton(this, 1, "ACTIVE MODS : OFF", "ACTIVE MODS : ON", ToggleRenderMods, ToggleRenderMods));
                }
                else
                {
                    toggleActiveMods = new Button(new TogglableButton(this, 1, "ACTIVE MODS : OFF", "ACTIVE MODS : ON", ToggleRenderMods, ToggleRenderMods, true));
                }
                toggleInteractESP = new Button(new TogglableButton(this, 2, "INTERACTABLES ESP : OFF", "INTERACTABLES ESP : ON", ToggleRenderInteractables, ToggleRenderInteractables));
                toggleMobESP = new Button(new TogglableButton(this, 3, "MOB ESP : OFF", "MOB ESP : ON", ToggleRenderMobs, ToggleRenderMobs));

                AddButtons(new List<Button>()
                {
                    toggleActiveMods,
                    toggleInteractESP,
                    toggleMobESP
                });
                SetActivatingButton(Utility.FindButtonById(0, 6));
                SetPrevMenuId(0);
            }
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
            renderMobs = false;
            renderInteractables = false;
            // Add check here later for low resolution monitors
            renderMods = true;
            DisableInteractables();
            base.Reset();
        }

        private void ToggleRenderInteractables()
        {
            if (renderInteractables)
            {
                DisableInteractables();
            }
            else
            {
                EnableInteractables();
            }
            renderInteractables = !renderInteractables;
        }

        private void ToggleRenderMods()
        {
            renderMods = !renderMods;
        }

        private void ToggleRenderMobs()
        {
            renderMobs = !renderMobs;
        }

        public static void EnableInteractables()
        {
            if (onRenderIntEnable)
            {
                DumpInteractables(null);
                SceneDirector.onPostPopulateSceneServer += DumpInteractables;
                onRenderIntEnable = false;
            }
        }

        public static void DisableInteractables()
        {
            if (!onRenderIntEnable)
            {
                SceneDirector.onPostPopulateSceneServer -= DumpInteractables;
                onRenderIntEnable = true;
            }
        }

        public static void DumpInteractables(SceneDirector obj)
        {
            barrelInteractions = MonoBehaviour.FindObjectsOfType<BarrelInteraction>().ToList();
            purchaseInteractions = MonoBehaviour.FindObjectsOfType<PurchaseInteraction>().ToList();
            secretButtons = MonoBehaviour.FindObjectsOfType<PressurePlateController>().ToList();
            scrappers = MonoBehaviour.FindObjectsOfType<ScrapperController>().ToList();
        }

        public static void DrawTeleporter() {
            camera = Camera.main;

            if (TeleporterInteraction.instance)
            {
                var teleporterInteraction = TeleporterInteraction.instance;
                float distanceToObject = Vector3.Distance(camera.transform.position, teleporterInteraction.transform.position);
                Vector3 Position = camera.WorldToScreenPoint(teleporterInteraction.transform.position);
                var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                if (BoundingVector.z > 0.01)
                {
                    int distance = (int)distanceToObject;
                    string friendlyName = "Teleporter";
                    string status = "" + (
                        teleporterInteraction.isIdle ? "Idle" :
                        teleporterInteraction.isCharging ? "Charging" :
                        teleporterInteraction.isCharged ? "Charged" :
                        teleporterInteraction.isActiveAndEnabled ? "Idle" :
                        teleporterInteraction.isIdleToCharging ? "Idle-Charging" :
                        teleporterInteraction.isInFinalSequence ? "Final-Sequence" :
                        "???");
                    string boxText = $"{friendlyName}\n{status}\n{distance}m";
                    monsoon.Renderer.DrawString(new Vector2(BoundingVector.x, (float)Screen.height - BoundingVector.y),
                        boxText, Styles.TeleporterStyle);
                }
            }
        }

        public static void DrawInteractables()
        {
            for (int i = 0; i < purchaseInteractions.Count; i++)
            {
                PurchaseInteraction purchaseInteraction = purchaseInteractions[i];

                if (purchaseInteraction.available)
                {
                    string dropName = null;
                    var chest = purchaseInteraction?.gameObject.GetComponent<ChestBehavior>();
                    if (chest)
                    {
                        dropName = Util.GenerateColoredString(Language.GetString(chest.dropPickup.GetPickupNameToken()), chest.dropPickup.GetPickupColor());
                    }

                    float distanceToObject = Vector3.Distance(camera.transform.position, purchaseInteraction.transform.position);
                    Vector3 Position = camera.WorldToScreenPoint(purchaseInteraction.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);

                    if (BoundingVector.z > 0.01)
                    {
                        int distance = (int)distanceToObject;
                        string friendlyName = purchaseInteraction.GetDisplayName();
                        int cost = purchaseInteraction.cost;

                        string boxText;
                        if (friendlyName.Contains("Mountain") || friendlyName.Contains("Combat") || friendlyName.Contains("Printer"))
                        {
                            boxText = $"{friendlyName}\n{distance}m";
                        }
                        else
                        {
                            boxText = dropName != null 
                                ? $"{friendlyName}\n{BuyingUnit(friendlyName, cost)}\n{distance}m\n{dropName}" 
                                : $"{friendlyName}\n{BuyingUnit(friendlyName, cost)}\n{distance}m";
                        }
                        monsoon.Renderer.DrawString(new Vector2(BoundingVector.x, (float)Screen.height - BoundingVector.y),
                            boxText, ChooseStyle(friendlyName));
                    }
                }

            }
        }

        public static void DrawBarrels()
        {
            for (int i = 0; i < barrelInteractions.Count; i++)
            {
                BarrelInteraction barrel = barrelInteractions[i];

                if (!barrel.Networkopened)
                {
                    string friendlyName = "Barrel";
                    Vector3 Position = camera.WorldToScreenPoint(barrel.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                    if (BoundingVector.z > 0.01)
                    {
                        float distance = (int)Vector3.Distance(camera.transform.position, barrel.transform.position);
                        string boxText = $"{friendlyName}\n{distance}m";
                        monsoon.Renderer.DrawString(new Vector2(BoundingVector.x, Screen.height - BoundingVector.y),
                            boxText, ChooseStyle(friendlyName));
                    }
                }
            }
        }

        public static void DrawPressurePlates()
        {
            for (int i = 0; i < secretButtons.Count; i++)
            {
                PressurePlateController secretButton = secretButtons[i];
                if (secretButton)
                {
                    string friendlyName = "Secret Button";
                    Vector3 Position = camera.WorldToScreenPoint(secretButton.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                    if (BoundingVector.z > 0.01)
                    {
                        float distance = (int)Vector3.Distance(camera.transform.position, secretButton.transform.position);
                        string boxText = $"{friendlyName}\n{distance}m";
                        monsoon.Renderer.DrawString(new Vector2(BoundingVector.x, (float)Screen.height - BoundingVector.y),
                            boxText, ChooseStyle(friendlyName));
                    }
                }
            }
        }

        public static void DrawScrappers()
        {
            for (int i = 0; i < scrappers.Count; i++)
            {
                ScrapperController scrapper = scrappers[i];
                if (scrapper)
                {
                    string friendlyName = "Scrapper";
                    Vector3 Position = camera.WorldToScreenPoint(scrapper.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                    if (BoundingVector.z > 0.01)
                    {
                        float distance = (int)Vector3.Distance(camera.transform.position, scrapper.transform.position);
                        string boxText = $"{friendlyName}\n{distance}m";
                        monsoon.Renderer.DrawString(new Vector2(BoundingVector.x, (float)Screen.height - BoundingVector.y),
                            boxText, ChooseStyle(friendlyName));
                    }
                }
            }
        }

        private static string BuyingUnit(string name, int cost)
        {
            if (name.Contains("Newt") || name.Contains("Lunar") || name.Contains("Order") || name.Contains("Slab"))
                return cost + "LC";
            else if (name.Contains("Void") || name.Contains("Blood"))
                return cost + "%HP";
            return "$" + cost;
        }
        private static GUIStyle ChooseStyle(string name)
        {
            if (name.Contains("Newt"))
                return Styles.NewtStyle;
            else if (name.Contains("Chest") || name.Contains("Multishop") || name.Contains("Printer"))
                return Styles.ChestStyle;
            else if (name.Contains("Equipment"))
                return Styles.EquipmentStyle;
            else if (name.Contains("Lunar"))
                return Styles.LunarStyle;
            else if (name.Contains("Void"))
                return Styles.VoidStyle;
            else if (name.Contains("Gold") || name.Contains("Chance"))
                return Styles.ChanceStyle;
            else if (name.Contains("Blood"))
                return Styles.BloodStyle;
            else if (name.Contains("Combat") || name.Contains("Order"))
                return Styles.CombatStyle;
            else if (name.Contains("Mountain"))
                return Styles.MountainStyle;
            else if (name.Contains("Woods"))
                return Styles.WoodsStyle;
            return Styles.DefaultStyle;
        }

        public static void Mobs()
        {
            for (int i = 0; i < hurtBoxes.Count; i++)
            {
                var mob = HurtBox.FindEntityObject(hurtBoxes[i]);
                if (mob)
                {
                    Vector3 MobPosition = camera.WorldToScreenPoint(mob.transform.position);
                    var MobBoundingVector = new Vector3(MobPosition.x, MobPosition.y, MobPosition.z);
                    float distanceToMob = Vector3.Distance(camera.transform.position, mob.transform.position);
                    if (MobBoundingVector.z > 0.01)
                    {
                        float width = 100f * (distanceToMob / 100);
                        if (width > 125)
                        {
                            width = 125;
                        }
                        float height = 100f * (distanceToMob / 100);
                        if (height > 125)
                        {
                            height = 125;
                        }
                        string mobName = mob.name.Replace("Body(Clone)", "");
                        int mobDistance = (int)distanceToMob;
                        string mobBoxText = $"{mobName}\n{mobDistance}m";
                        GUI.Label(new Rect(MobBoundingVector.x - 50f, (float)Screen.height - MobBoundingVector.y + 50f, 100f, 50f), mobBoxText, Styles.RenderMobsStyle);
                        ESPHelper.DrawBox(MobBoundingVector.x - width / 2, (float)Screen.height - MobBoundingVector.y - height / 2, width, height, new Color32(255, 0, 0, 255));
                    }
                }
            }
        }

        public static void ActiveMods()
        {
            List<string> modsActive = new List<string>();
            Dictionary<string, bool> allMods = new Dictionary<string, bool>()
            {
                { "Aimbot", Menus.Player.AimBotToggle },
                { "Always-Sprint", Menus.Movement.alwaysSprintToggle },
                { "Drop-Items", Items.isDropItemForAll },
                { "Drop-Items-from-Inventory", Items.isDropItemFromInventory },
                { "Flight", Menus.Movement.flightToggle },
                { "God-Mode", Menus.Player.GodToggle },
                { "Jump-Pack", Menus.Movement.jumpPackToggle },
                { "Keyboard-Navigation", UmbraMenu.navigationToggle },
                { "Modified-Armor", StatsMod.armorToggle },
                { "Modified-Attack Speed", StatsMod.attackSpeedToggle },
                { "Modified-Crit", StatsMod.critToggle },
                { "Modified-Damage", StatsMod.damageToggle },
                { "Modified-Move-Speed", StatsMod.moveSpeedToggle },
                { "Modified-Regen", StatsMod.regenToggle },
                { "No-Equipment-Cooldown", Items.noEquipmentCD },
                { "No-Skill-Cooldowns", Menus.Player.SkillToggle },
                { "Render-Interactables", renderInteractables },
                { "Render-Mobs", renderMobs }
            };

            string modsBoxText = "";
            Vector2 bottom = new Vector2(0, Screen.height);

            foreach (string modName in allMods.Keys)
            {
                allMods.TryGetValue(modName, out bool active);
                if (active)
                {
                    modsActive.Add(modName);
                }
                else if (modsActive.Contains(modName))
                {
                    modsActive.Remove(modName);
                }
            }

            if (modsActive != null)
            {
                for (int i = 0; i < modsActive.Count; i++)
                {
                    //modsBoxText += $"{modsActive[i]}\n";
                    modsBoxText += $"{modsActive[i]}    ";
                }

                if (modsBoxText != "")
                {
                    GUI.Label(new Rect(Screen.width / 16, bottom.y - 55f, 200, 50f), "Active Mods: ", Styles.ActiveModsStyle);
                    GUI.Label(new Rect((Screen.width / 16) + 124, bottom.y - 55f, Screen.width - (Screen.width / 6), 50f), modsBoxText, Styles.ActiveModsStyle);
                }
            }
        }
    }
}