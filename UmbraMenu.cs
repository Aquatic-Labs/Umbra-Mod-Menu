using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.SceneManagement;
using System.Linq;

namespace UmbraMenu
{
    public class UmbraMenu : MonoBehaviour
    {
        public const string
            NAME = "U M B R A",
            VERSION = "2.0.0";

        public static string log = "[" + NAME + "] ";

        // Used to unlock all items
        public List<string> unlockableNames;

        // These Values are needed for navigation to create Enumerable and indexable values with the items I've excluded
        public List<GameObject> bodyPrefabs;
        public List<EquipmentIndex> equipment;
        public List<ItemIndex> items;
        public List<SpawnCard> spawnCards;

        // These Are updated in FixedUpdate for performance reasons
        public List<HurtBox> hurtBoxes;
        public Scene currentScene;

        // Used for RollItems
        public WeightedSelection<List<ItemIndex>> weightedSelection;

        private void OnGUI()
        {
            Menus menus = new Menus();
            menus.BuildAllMenus();
        }

        public void Start()
        {
            Menus.WriteToLog("Locked & Loaded");
        }

        public void Update()
        {

        }

        public void FixedUpdate()
        {

        }
    }
}
