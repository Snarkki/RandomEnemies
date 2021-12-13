using HarmonyLib;
using Kingmaker;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomEnemies.Mechanics;
using Kingmaker.UnitLogic;
using Kingmaker.RuleSystem.Rules;
using TurnBased.Controllers;
using RandomEnemies.Utilities;
using static Kingmaker.EntitySystem.Stats.ModifiableValue;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Items;
using Kingmaker.Blueprints.Items;
using Kingmaker.Controllers.Units;
using Kingmaker.UnitLogic.Groups;
using static RandomEnemies.Equipment.LootTypes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.View.Spawners;
using Kingmaker.Blueprints.Area;

namespace RandomEnemies.Mechanics
{
    internal class HarmonySpawnLogic// : IUnitSpawnHandler, ISubscriber, IGlobalSubscriber
    {
        [HarmonyPatch(typeof(Game), "OnAreaLoaded")]
        internal static class UnitSpawner1_Spawn_Patch
        {
            public static void Prefix()
            {
                // Set Theme on area load. 
                SpawnUnitHelper.chosenTheme = SpawnUnitHelper.ChooseTheme();
                SpawnUnitHelper.backupTheme = SpawnUnitHelper.ChooseBackupTheme(SpawnUnitHelper.chosenTheme);
            }
        }


        [HarmonyPatch(typeof(UnitSpawnerBase), "Spawn")]
        internal static class UnitSpawner2_Spawn_Patch
        {

            public static void Postfix(UnitSpawnerBase __instance)
            {
                UnitEntityData entityData = __instance.Data.SpawnedUnit.Value;
                if (entityData != null)
                {
                    Main.LogDebug(" Loaded area" + Game.Instance.CurrentlyLoadedArea.AreaName + " " + Game.Instance.CurrentlyLoadedArea.AreaName.Key);
                    bool cutsceneCheck = !Game.Instance.CutsceneLock.Active && !AreaEdits.ProceduralSpawnAreaBlacklist.Any((BlueprintArea x) => x.name == Game.Instance.CurrentlyLoadedArea.name);
                    if (cutsceneCheck)
                    {
                        // Main.LogDebug("Passed CutsCeneCheck");
                        bool factionCheck = (entityData.Faction == Factions.FactionMobs || entityData.Faction == Factions.FactionWildAnimals);
                        if (factionCheck)
                        {
                            // Main.LogDebug("Passed factionCheck");
                            bool unitCheck = (!entityData.IsDeadAndHasLoot && !entityData.m_IsDeathRevealed && entityData.MaxHP > 5);
                            if (unitCheck)
                            {
                                //Main.LogDebug("Passed unitCheck");
                                // blacklist already handled groups & allowed enemy lists & blacklisted unitgroup names (these are added as some are used for cinematic triggers)
                                if (Units.UnitLists.allowedEnemiesList.Contains(entityData.Blueprint)) // 
                                {
                                    // Main.LogDebug("Passed listChecks");
                                    UnitEntityData result = RandomSpawnLogic.TryCreateEncounter(entityData);
                                    if (result != null)
                                    {
                                        Main.LogDebug(entityData + " CR: " + entityData.CR + " changed blueprint to " + result + " , CR: " + result.CR);
                                        RandomSpawnLogic.TryCreateLoot(entityData);
                                    }

                                }
                                else {
                                    RandomSpawnLogic.TryCreateLoot(entityData);
                                    Main.LogDebug(entityData + "Not valid unit blueprint"); 
                                }
                            }
                            else { Main.LogDebug(entityData + "Unit bp was fake/cheater"); }
                        }
                        else { Main.LogDebug(entityData + "Faction is not mobs, they are " + __instance.Blueprint.Faction); }
                    }
                    else { Main.LogDebug(entityData + "Cutscene active or blacklisted area" + Game.Instance.CurrentlyLoadedArea.AreaName + " " + Game.Instance.CurrentlyLoadedArea.AreaName.Key); }
                }
            }
        }
    }
}