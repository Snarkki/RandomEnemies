using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using Kingmaker.Blueprints.JsonSystem;
using RandomEnemies.Config;
using RandomEnemies.Utilities;
//using Kingmaker.Blueprints.JsonSystem;
using UnityEngine;
using UnityModManagerNet;
using Kingmaker.Localization;
using static Kingmaker.TurnBasedMode.Controllers.CombatAction;
using Kingmaker.EntitySystem.Entities;
using TurnBased.Controllers;
using static TurnBased.Controllers.CombatController;
using EnemyDifficultyMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
//using static UnityModManagerNet.UnityModManager;
namespace RandomEnemies
{
    public class Main
    {
        public static string ModPath;
        private const string CombatSpeed = "Change Combat Speed";
        private static bool Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);
            var harmony = new Harmony(modEntry.Info.Id);

            Main.settings = UnityModManager.ModSettings.Load<Settings>(modEntry);
            ModSettings.ModEntry = modEntry;
            ModPath = modEntry.Path;
            ModSettings.LoadAllSettings();
            modEntry.OnGUI = new Action<UnityModManager.ModEntry>(Main.OnGUI);
            modEntry.OnSaveGUI = new Action<UnityModManager.ModEntry>(Main.OnSaveGUI);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            PostPatchInitializer.Initialize();
            return true;
        }
        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Main.iAmEnabled = value;
            return true;
        }

        private static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            Main.settings.Save(modEntry);
        }

        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (!Main.iAmEnabled)
            {
                return;
            }

            GUILayout.Space(5f);

            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            settings.ChanceForRandomEncounter = GUILayout.HorizontalSlider(settings.ChanceForRandomEncounter, 0.0f, 100.0f, GUILayout.Width(100f));
            GUILayout.Label("Chance for additional encounter: " + Math.Round(settings.ChanceForRandomEncounter, 0));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            settings.ChanceForLootDrop = GUILayout.HorizontalSlider(settings.ChanceForLootDrop, 0.0f, 100.0f, GUILayout.Width(100f));
            GUILayout.Label("Chance for additional loot: " + Math.Round(settings.ChanceForLootDrop, 0));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            Settings.UseRandomEncounters = GUILayout.Toggle(Settings.UseRandomEncounters, "Enable random encounters");
            GUILayout.EndHorizontal();


        }
        public static bool GetInteger(string stringToConvert, out int intOutValue, int minLimit, int maxLimit)
        {
            bool parsed = int.TryParse(stringToConvert, out intOutValue);
            return parsed && intOutValue >= minLimit && intOutValue <= maxLimit;
        }
 
        private static bool iAmEnabled;

        public static Settings settings;

        public static List<string> unitGroupId = new List<string>();
        public static List<string> unitGroupByName = new List<string>();
        public static List<BlueprintUnit> unitBlackListBP = new List<BlueprintUnit>();
        public static List<string> SpawnedUnitId = new List<string>();
        public static Dictionary<string, BlueprintItem> SpawnedUnitsLoots = new Dictionary<string, BlueprintItem>();

        public static void Log(string msg)
        {
            ModSettings.ModEntry.Logger.Log(msg);
        }
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogDebug(string msg)
        {
            ModSettings.ModEntry.Logger.Log(msg);
        }
        public static void LogPatch(string action, [NotNull] IScriptableObjectWithAssetId bp)
        {
            Log($"{action}: {bp.AssetGuid} - {bp.name}");
        }
        public static void LogHeader(string msg)
        {
            Log($"--{msg.ToUpper()}--");
        }
        public static Exception Error(String message)
        {
            Log(message);
            return new InvalidOperationException(message);
        }

        public static LocalizedString MakeLocalizedString(string key, string value)
        {
            LocalizationManager.CurrentPack.Strings[key] = value;
            LocalizedString localizedString = new LocalizedString();
            typeof(LocalizedString).GetField("m_Key", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(localizedString, key);
            return localizedString;
        }
    }
}