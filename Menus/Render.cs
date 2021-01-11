using System;
using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using EntityStates.Scrapper;

namespace UmbraMenu.MenuButtons
{
    public class Render
    {
        private static readonly Menu currentMenu = null;// (Menu)Utility.FindMenuById(6);

        public static TogglableButton toggleActiveMods = new TogglableButton(currentMenu, 1, "A C T I V E   M O D S : O F F", "A C T I V E   M O D S : O N", ToggleRenderMods, ToggleRenderMods, true);
        public static TogglableButton toggleInteractESP = new TogglableButton(currentMenu, 2, "I N T E R A C T A B L E S   E S P : O F F", "I N T E R A C T A B L E S   E S P : O N", ToggleRenderInteractables, ToggleRenderInteractables);
        public static TogglableButton toggleMobESP = new TogglableButton(currentMenu, 3, "M O B   E S P : O F F\n<color=red>Warning: May lag/crash game </color>", "M O B   E S P : O N\n<color=red>Warning: May lag/crash game </color>", ToggleRenderMobs, ToggleRenderMobs);

        private static List<IButton> buttons = new List<IButton>()
        {
            toggleActiveMods,
            toggleInteractESP,
            toggleMobESP
        };

        public static void AddButtonsToMenu()
        {
            //currentMenu.Buttons = buttons;
        }

        public static List<PurchaseInteraction> purchaseInteractions = new List<PurchaseInteraction>();
        public static List<BarrelInteraction> barrelInteractions = new List<BarrelInteraction>();
        public static List<PressurePlateController> secretButtons = new List<PressurePlateController>();
        public static List<ScrapperController> scrappers = new List<ScrapperController>();
        public static List<HurtBox> hurtBoxes;
        public static bool onRenderIntEnable = true, renderMobs, renderInteractables, renderMods = true;

        private static void ToggleRenderInteractables()
        {
            if (renderInteractables || toggleInteractESP.Enabled)
            {
                DisableInteractables();
            }
            else
            {
                EnableInteractables();
            }
            renderInteractables = !renderInteractables;
        }

        private static void ToggleRenderMods()
        {
            renderMods = !renderMods;
        }

        private static void ToggleRenderMobs()
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

        private static void DumpInteractables(SceneDirector obj)
        {
            Debug.Log("Dumping Interactables");
            barrelInteractions = MonoBehaviour.FindObjectsOfType<BarrelInteraction>().ToList();
            purchaseInteractions = MonoBehaviour.FindObjectsOfType<PurchaseInteraction>().ToList();
            secretButtons = MonoBehaviour.FindObjectsOfType<PressurePlateController>().ToList();
            scrappers = MonoBehaviour.FindObjectsOfType<ScrapperController>().ToList();
        }

        public static void Interactables()
        {
            if (TeleporterInteraction.instance)
            {
                var teleporterInteraction = TeleporterInteraction.instance;
                float distanceToObject = Vector3.Distance(Camera.main.transform.position, teleporterInteraction.transform.position);
                Vector3 Position = Camera.main.WorldToScreenPoint(teleporterInteraction.transform.position);
                var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                if (BoundingVector.z > 0.01)
                {
                    Styles.RenderTeleporterStyle.normal.textColor =
                        teleporterInteraction.isIdle ? Color.magenta :
                        teleporterInteraction.isIdleToCharging || teleporterInteraction.isCharging ? Color.yellow :
                        teleporterInteraction.isCharged ? Color.green : Color.yellow;
                    int distance = (int)distanceToObject;
                    String friendlyName = "Teleporter";
                    string status = "" + (
                        teleporterInteraction.isIdle ? "Idle" :
                        teleporterInteraction.isCharging ? "Charging" :
                        teleporterInteraction.isCharged ? "Charged" :
                        teleporterInteraction.isActiveAndEnabled ? "Idle" :
                        teleporterInteraction.isIdleToCharging ? "Idle-Charging" :
                        teleporterInteraction.isInFinalSequence ? "Final-Sequence" :
                        "???");
                    string boxText = $"{friendlyName}\n{status}\n{distance}m";
                    GUI.Label(new Rect(BoundingVector.x - 50f, (float)Screen.height - BoundingVector.y, 100f, 50f), boxText, Styles.RenderTeleporterStyle);
                }
            }

            for (int i = 0; i < barrelInteractions.Count; i++)
            {
                BarrelInteraction barrel = barrelInteractions[i];

                if (!barrel.Networkopened)
                {
                    string friendlyName = "Barrel";
                    Vector3 Position = Camera.main.WorldToScreenPoint(barrel.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                    if (BoundingVector.z > 0.01)
                    {
                        float distance = (int)Vector3.Distance(Camera.main.transform.position, barrel.transform.position);
                        string boxText = $"{friendlyName}\n{distance}m";
                        GUI.Label(new Rect(BoundingVector.x - 50f, (float)Screen.height - BoundingVector.y, 100f, 50f), boxText, Styles.RenderInteractablesStyle);
                    }
                }
            }

            for (int i = 0; i < secretButtons.Count; i++)
            {
                PressurePlateController secretButton = secretButtons[i];
                if (secretButton)
                {
                    string friendlyName = "Secret Button";
                    Vector3 Position = Camera.main.WorldToScreenPoint(secretButton.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                    if (BoundingVector.z > 0.01)
                    {
                        float distance = (int)Vector3.Distance(Camera.main.transform.position, secretButton.transform.position);
                        string boxText = $"{friendlyName}\n{distance}m";
                        GUI.Label(new Rect(BoundingVector.x - 50f, (float)Screen.height - BoundingVector.y, 100f, 50f), boxText, Styles.RenderSecretsStyle);
                    }
                }
            }

            for (int i = 0; i < scrappers.Count; i++)
            {
                ScrapperController scrapper = scrappers[i];
                if (scrapper)
                {
                    string friendlyName = "Scrapper";
                    Vector3 Position = Camera.main.WorldToScreenPoint(scrapper.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                    if (BoundingVector.z > 0.01)
                    {
                        float distance = (int)Vector3.Distance(Camera.main.transform.position, scrapper.transform.position);
                        string boxText = $"{friendlyName}\n{distance}m";
                        GUI.Label(new Rect(BoundingVector.x - 50f, (float)Screen.height - BoundingVector.y, 100f, 50f), boxText, Styles.RenderInteractablesStyle);
                    }
                }
            }

            for (int i = 0; i < purchaseInteractions.Count; i++)
            {
                PurchaseInteraction purchaseInteraction = purchaseInteractions[i];

                if (purchaseInteraction.available)
                {
                    string dropName = null;
                    var chest = purchaseInteraction?.gameObject.GetComponent<ChestBehavior>();
                    if (chest)
                    {
                        dropName = Util.GenerateColoredString(Language.GetString(chest.GetField<PickupIndex>("dropPickup").GetPickupNameToken()), chest.GetField<PickupIndex>("dropPickup").GetPickupColor());
                    }
                    float distanceToObject = Vector3.Distance(Camera.main.transform.position, purchaseInteraction.transform.position);
                    Vector3 Position = Camera.main.WorldToScreenPoint(purchaseInteraction.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                    if (BoundingVector.z > 0.01)
                    {
                        int distance = (int)distanceToObject;
                        String friendlyName = purchaseInteraction.GetDisplayName();
                        int cost = purchaseInteraction.cost;
                        string boxText = dropName != null ? $"{friendlyName}\n${cost}\n{distance}m\n{dropName}" : $"{friendlyName}\n${cost}\n{distance}m";
                        GUI.Label(new Rect(BoundingVector.x - 50f, (float)Screen.height - BoundingVector.y, 100f, 50f), boxText, Styles.RenderInteractablesStyle);
                    }
                }
            }
        }

        public static void Mobs()
        {
            for (int i = 0; i < hurtBoxes.Count; i++)
            {
                var mob = HurtBox.FindEntityObject(hurtBoxes[i]);

                if (mob)
                {
                    Vector3 MobPosition = Camera.main.WorldToScreenPoint(mob.transform.position);
                    var MobBoundingVector = new Vector3(MobPosition.x, MobPosition.y, MobPosition.z);
                    float distanceToMob = Vector3.Distance(Camera.main.transform.position, mob.transform.position);
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
                //{ "Aimbot", Player.aimBotToggle },
                { "Always-Sprint", Movement.alwaysSprintToggle },
                { "Drop-Items", Items.isDropItemForAll },
                { "Drop-Items-from-Inventory", Items.isDropItemFromInventory },
                { "Flight", Movement.flightToggle },
                //{ "God-Mode", Player.godToggle },
                { "Jump-Pack", Movement.jumpPackToggle },
                { "Keyboard-Navigation", UmbraMenu.navigationToggle },
                { "Modified-Armor", StatsMod.armorToggle },
                { "Modified-Attack Speed", StatsMod.attackSpeedToggle },
                { "Modified-Crit", StatsMod.critToggle },
                { "Modified-Damage", StatsMod.damageToggle },
                { "Modified-Move-Speed", StatsMod.moveSpeedToggle },
                { "Modified-Regen", StatsMod.regenToggle },
                { "No-Equipment-Cooldown", Items.noEquipmentCD },
                //{ "No-Skill-Cooldowns", Player.skillToggle },
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
