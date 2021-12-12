using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Items;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic.Groups;
using RandomEnemies.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static RandomEnemies.Mechanics.SpawnUnitHelper;
using static RandomEnemies.Equipment.LootTypes;
using Kingmaker.AreaLogic.SummonPool;
using HarmonyLib;
using Kingmaker.View.Spawners;
using Kingmaker.UnitLogic;
using Kingmaker.Blueprints.Classes.Experience;
using RandomEnemies.Extensions;

namespace RandomEnemies.Mechanics
{
    internal class RandomSpawnLogic// : IUnitSpawnHandler, ISubscriber, IGlobalSubscriber
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


        //public void InitializeProceduralSpawn()
        //{

        //    EventBus.Subscribe(this);
        //}

        [HarmonyPatch(typeof(UnitSpawnerBase), "Spawn")]
        internal static class UnitSpawner2_Spawn_Patch
        {
            public static void Prefix(UnitSpawnerBase __instance, out bool __state)
            {
                __state = false;
                BlueprintUnit originalBP = __instance.Blueprint;
                Main.LogDebug(" Loaded area" + Game.Instance.CurrentlyLoadedArea.AreaName + " " + Game.Instance.CurrentlyLoadedArea.AreaName.Key);
                bool cutsceneCheck = !Game.Instance.CutsceneLock.Active && !AreaEdits.ProceduralSpawnAreaBlacklist.Any((BlueprintArea x) => x.name == Game.Instance.CurrentlyLoadedArea.name);
                if (cutsceneCheck)
                {
                    // Main.LogDebug("Passed CutsCeneCheck");
                    bool factionCheck = (__instance.Blueprint.Faction == Factions.FactionMobs || __instance.Blueprint.Faction == Factions.FactionWildAnimals);
                    if (factionCheck)
                    {
                        // Main.LogDebug("Passed factionCheck");
                        bool unitCheck = (!__instance.Blueprint.IsFake && !__instance.Blueprint.IsCheater);
                        if (unitCheck)
                        {
                            //Main.LogDebug("Passed unitCheck");
                            // blacklist already handled groups & allowed enemy lists & blacklisted unitgroup names (these are added as some are used for cinematic triggers)
                            if (Units.UnitLists.allowedEnemiesList.Contains(__instance.Blueprint)) // 
                            {
                                // Main.LogDebug("Passed listChecks");
                                BlueprintUnit result = RandomSpawnLogic.TryCreateEncounter(__instance.Blueprint);
                                if (result != null)
                                {
                                    __state = true;
                                    __instance.Blueprint = result;
                                    Main.LogDebug(originalBP + " CR: " + originalBP.CR + " changed blueprint to " + result + " , CR: " + result.CR); 
                                    
                                }

                            }
                            else { Main.LogDebug(originalBP + "Not valid unit blueprint");}
                            }
                        else { Main.LogDebug(originalBP + "Unit bp was fake/cheater"); }
                    }
                    else { Main.LogDebug(originalBP + "Faction is not mobs, they are " + __instance.Blueprint.Faction); }
                }
                else { Main.LogDebug(originalBP + "Cutscene active or blacklisted area" + Game.Instance.CurrentlyLoadedArea.AreaName + " " + Game.Instance.CurrentlyLoadedArea.AreaName.Key); }
            }
            // Handle loot for spawned units. Postfix so unit is spawned.
            public static void Postfix(UnitSpawnerBase __instance, bool __state)
            {
                UnitEntityData entityData = __instance.Data.SpawnedUnit.Value;
                if (entityData != null)
                {
                    //Main.LogDebug(entityData + "State is " + __state);
                    if (__state)
                    {
                        //entityData.Descriptor.Faction = Factions.FactionMobs;
                        entityData.Descriptor.SwitchFactions(Factions.FactionMobs, true);
                        entityData.GiveExperienceOnDeath = true;
                        //summons etc are unlootable -> need to make them lootable if such thing is spawned 
                        if (entityData.Descriptor.State.HasCondition(UnitCondition.Unlootable))
                        {
                            entityData.Descriptor.State.RemoveCondition(UnitCondition.Unlootable);
                        }
                        
                        string charName = entityData.CharacterName;
                        if (charName.Contains("Summoned"))
                        { charName = charName.Replace("Summoned", "");
                          entityData.Descriptor.CustomName = charName;
                        }                             
                    }
                    if (!Main.SpawnedUnitId.Contains(entityData.UniqueId))
                    {
                        TryCreateLoot(entityData);
                        Main.SpawnedUnitId.Add(entityData.UniqueId);
                    }
                }
            }
        }


        public static BlueprintUnit TryCreateEncounter(BlueprintUnit blueprintUnit)
        {
            bool rollForEncounter = SpawnUnitHelper.rollForEncounter();
            if (!rollForEncounter) { return null; }

            SpawnUnitHelper.PlayerLevel = Game.Instance.Player.MainCharacter.Value.Descriptor.Progression.CharacterLevel;
            if (SpawnUnitHelper.PlayerLevel > 20) { SpawnUnitHelper.PlayerLevel = 20; } // For legend -> scaling stops at lvl20
            string encounterType = SpawnUnitHelper.getEncounterType();
            SpawnUnitHelper.CalculateCRs(encounterType, blueprintUnit);

            if (SpawnUnitHelper.MaxCR == 0) { return null; }
            BlueprintUnit result = chooseResultUnit(chosenTheme, backupTheme, MinCR, MaxCR);
            if (result == null) { return null; }

            return result;

        }
    

        public static void TryCreateLoot(UnitEntityData entityData)
        {
            LootType lootType = LootHandler.RollForLootType();
            if (lootType == LootType.None) { return; }
            UnityEngine.RangeInt range = LootHandler.CreateRangeForLoot(entityData);
            BlueprintItem Loot = LootHandler.CreateLootItem(lootType, range);
            Main.LogDebug("Adding loot " + Loot.Name + "to entity " + entityData.CharacterName);
            if (Loot != null)
            {
                entityData.Inventory.Add(Loot);
            }
        }

    }
}

//public void HandleUnitSpawned(UnitEntityData entityData)
//{
//    bool cutsceneCheck = !Game.Instance.CutsceneLock.Active && !AreaEdits.ProceduralSpawnAreaBlacklist.Any((BlueprintArea x) => x.name == Game.Instance.CurrentlyLoadedArea.name);
//    if (cutsceneCheck)
//    {
//        bool spawnedUnit = (Main.SpawnedUnitId.Contains(entityData.View.UniqueId));
//        if (!spawnedUnit) { 
//       // Main.LogDebug("Passed CutsCeneCheck");
//            bool factionCheck = (entityData.Descriptor.Faction == Factions.FactionMobs); //|| entityData.Descriptor.Faction == Factions.FactionWildAnimals);
//            if (factionCheck)
//            {
//               // Main.LogDebug("Passed factionCheck");
//                bool unitCheck = (!entityData.IsDeadAndHasLoot && !entityData.m_IsDeathRevealed && entityData.MaxHP > 5);
//                if (unitCheck)
//                {
//                    //Main.LogDebug("Passed unitCheck");
//                    // blacklist already handled groups & allowed enemy lists & blacklisted unitgroup names (these are added as some are used for cinematic triggers)
//                    if (Units.allowedEnemiesList.Contains(entityData.Blueprint) && !Main.unitGroupByName.Contains(entityData.Group.ToString())) // 
//                    {
//                        // Main.LogDebug("Passed listChecks");
//                        //Main.unitGroupId.Add(entityData.Group.Id);
//                        RandomSpawnLogic.TryCreateEncounter(entityData);
//                    }
//                    // if the unit is from a already handled group AND it is NOT a newly created unit -> mark it for destroy
//                    // the other units from the group do not exist until the spawnunithandler creates them so we do it this way.. 
//                    //else if (!SpawnUnitHelper.createdUnitID.Contains(entityData.View.UniqueId)) { entityData.MarkForDestroy(); }
//                    //else { TryCreateLoot(entityData); }
//                }
//            }
//        }
//    }
//}