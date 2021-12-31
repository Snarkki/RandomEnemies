using Kingmaker.Blueprints.Classes;
using ModMaker.Utility;
using System.Collections.Generic;
using UnityModManagerNet;

namespace RandomEnemies
{
    public class Settings : UnityModManager.ModSettings
    {

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            UnityModManager.ModSettings.Save<Settings>(this, modEntry);
        }


        public static bool UseRandomEncounters = true;
        public static bool UseRandomLoot = true;
        
        public float ChanceForRandomEncounter = 75;
        public float ChanceForLootDrop = 10;

        public static int EasierEncounterChance = 20;
        public static int PowerfulEncounterChance = 7;
        public static int RareEncounterChance = 3;

        public const string CommonEncounterName = "Common";
        public const string RareEncounterName = "Rare";
        public const string PowerfulEncounterName = "Powerful";
        public const string EasyEncounterName = "Easy";

        public static float EasyEncounterModifier = 0.9f;
        public static float CommonEncounterModifier = 1.0f;
        public static float PowerfulEncounterModifier = 1.1f;
        public static float RareEncounterModifier = 1.1f;

        public string lastModVersion;
        public string localizationFileName;
        public SerializableDictionary<string, HashSet<string>> containersChecked;
        public SerializableDictionary<string, HashSet<string>> itemsGiven;

    }
}
