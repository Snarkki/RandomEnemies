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
using Owlcat.Runtime.Core.Utils;
using System.Runtime.CompilerServices;
using UnityEngine;
using Xunit.Sdk;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.ElementsSystem;
using Kingmaker.Controllers.Combat;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem;

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
            //public static void Postfix()
            //{
            //    // luo lootit
            //    foreach (UnitGroup unitgroup in Game.Instance.UnitGroups)
            //    {
            //        foreach (UnitEntityData entityData in unitgroup)
            //        {
            //            bool factionCheck = (entityData.Descriptor.Faction == Factions.FactionMobs);
            //            if (factionCheck)
            //            {
            //                bool unitCheck = (!entityData.IsDeadAndHasLoot && !entityData.m_IsDeathRevealed && entityData.MaxHP > 5 && !entityData.Descriptor.State.HasCondition(UnitCondition.Unlootable));
            //                if (unitCheck)
            //                {
            //                    RandomSpawnLogic.TryCreateLoot(entityData);
            //                }
            //            }
            //        }
            //    }
            //}
        }
        //[HarmonyPatch(typeof(RuleInitiativeRoll), "OnTrigger")]
        //internal static class UnitQuit_Patch
        //{
        //    public static void Postfix(RuleInitiativeRoll __instance)
        //    {
        //        bool flag0 = (__instance.Initiator != null);
        //        if (flag0)
        //        {
        //            UnitEntityData entityData = __instance.Initiator;
        //            bool factionCheck = (entityData.Descriptor.Faction == Factions.FactionMobs);
        //            if (factionCheck)
        //            {
        //                bool unitCheck = (!entityData.IsDeadAndHasLoot && !entityData.m_IsDeathRevealed && entityData.MaxHP > 5) && !entityData.Descriptor.State.HasCondition(UnitCondition.Unlootable); 
        //                if (unitCheck)
        //                {
        //                    RandomSpawnLogic.TryCreateLoot(entityData);

        //                } else { Main.LogDebug("Unitcheck for loot failed "); }
        //            }
        //        }
        //    }
        //}

        //[HarmonyPatch(typeof(UnitCombatState), "JoinCombat")]
        //internal static class UnitQuit_Patch
        //{
        //    public static void Postfix(UnitCombatState __instance)
        //    {


        //        if (__instance.m_InCombat == false)
        //        {
        //            return;
        //        }

        //        UnitEntityData eData = __instance.Unit;
        //        if (Main.unitGroupId.Contains(eData.GroupId))
        //        {
        //            return;
        //        }
        //        Main.unitGroupId.Add(eData.GroupId);
        //        foreach (UnitEntityData entityData in eData.Group)
        //        {
        //            Main.LogDebug("In postfix " + entityData.Descriptor.Faction);

        //            bool factionCheck = (entityData.Descriptor.Faction == Factions.FactionMobs);
        //            if (factionCheck)
        //            {
        //                bool unitCheck = (!entityData.IsDeadAndHasLoot && !entityData.m_IsDeathRevealed && entityData.MaxHP > 5 && !entityData.IsPet) ;
        //                if (unitCheck)
        //                {
        //                    if (entityData.Descriptor.State.HasCondition(UnitCondition.Unlootable) && !entityData.IsSummoned())
        //                    {
        //                        Main.LogDebug("Removed condition unlootable ");
        //                        entityData.Descriptor.State.RemoveCondition(UnitCondition.Unlootable);
        //                    }
        //                    Main.LogDebug("Trying to create loot ");
        //                    RandomSpawnLogic.TryCreateLoot(entityData);


        //                }
        //                else { Main.LogDebug("Unitcheck for loot failed "); }
        //            }
        //        }
        //    }
        //}

        //[HarmonyPatch(typeof(Game), "HandleQuit")]
        //internal static class UnitQuit_Patch
        //{
        //    public static void Prefix()
        //    {
        //        DestroyAddedLoots();


        //    }
        //}

        //[HarmonyPatch(typeof(Game), "LoadGame")]
        //internal static class UnitLoad_Patch
        //{
        //    public static void Prefix()
        //    {
        //        Main.unitGroupId.Clear();
        //    }
        //}


        //static void DestroyAddedLoots()
        //{
        //    foreach (UnitGroup unitgroup in Game.Instance.UnitGroups)
        //    {
        //        foreach (UnitEntityData entityData in unitgroup)
        //        {
        //            foreach (KeyValuePair<string, BlueprintItem> entry in Main.SpawnedUnitsLoots)
        //            {
        //                if (entityData.UniqueId == entry.Key)
        //                {
        //                    entityData.Inventory.Remove(entry.Value);
        //                }
        //            }
        //        }
        //    }
        //}

        //[HarmonyPatch(typeof(UnitSpawnerBase), "Spawn")]
        //internal static class UnitSpawner2_Spawn_Patch
        //{
        //    public static void Postfix(UnitSpawnerBase __instance)
        //    {
        //        if (__instance == null) { return; }

        //        UnitEntityData entityData = __instance.Data.SpawnedUnit.Value;
        //        if (entityData != null && !__instance.Data.HasDied && __instance.Data.IsInGame && !__instance.SpawnedUnitHasDied && __instance.Data.HasSpawned && !__instance.m_Blueprint.IsEmpty())
        //        { 
        //                // Main.LogDebug("Passed CutsCeneCheck");
        //                bool factionCheck = (entityData.IsPlayersEnemy && entityData.CutsceneControlledUnit == null);
        //                if (factionCheck)
        //                {

        //                    //(Descriptor.State.IsFinallyDead && !entityData.Descriptor.State.Features.SuppressedDecomposition && !IsDeadAndHasLoot && !IsPlayerFaction && !Descriptor.State.Features.Immortality)
        //                    // Main.LogDebug("Passed factionCheck");
        //                    bool unitCheck = (!entityData.IsDeadAndHasLoot && !entityData.m_IsDeathRevealed && entityData.MaxHP > 5);
        //                    if (unitCheck)
        //                    {
        //                        Main.LogDebug("Trying to create loot ");
        //                        RandomSpawnLogic.TryCreateLoot(entityData);

        //                    //Main.LogDebug("Passed unitCheck");
        //                    // blacklist already handled groups & allowed enemy lists & blacklisted unitgroup names (these are added as some are used for cinematic triggers)

        //                }
        //                else { Main.LogDebug(entityData + "Unit bp was fake/cheater"); }
        //                }
        //                else { Main.LogDebug(entityData + "Faction is not mobs, they are " + __instance.Blueprint.Faction); }
        //            }
        //            else { Main.LogDebug(entityData + "Cutscene active or blacklisted area " + Game.Instance.CurrentlyLoadedArea.AreaName + " " + Game.Instance.CurrentlyLoadedArea.AreaName.Key); }
                
        //    }
        //}

        [HarmonyPatch(typeof(UnitSpawnerBase), "Spawn")]
        internal static class UnitSpawner3_Spawn_Patch
        {

            public static void Prefix(UnitSpawnerBase __instance)
            { //            if (Game.Instance.CurrentlyLoadedArea.GetComponent<CombatRandomEncounterAreaSettings>() == null && (!HasSpawned || (SpawnedUnitHasDied && m_RespawnIfDead)) && m_SpawnOnSceneInit && CheckConditions())
                if (!Settings.UseRandomEncounters)
                {
                    return;
                }
                
                if (__instance.HasSpawned)
                {
                    Main.LogDebug("Unit has already spawned");
                    return;
                }
                if (__instance.m_Blueprint.IsEmpty())
                {
                    Main.LogDebug("BP is empty");
                    return;
                }

                List<IUnitSpawnRestriction> results = TempList.Get<IUnitSpawnRestriction>();
                __instance.GetComponents<IUnitSpawnRestriction>(results);
                UnitSpawnRestrictionResult restrictionResult = UnitSpawnRestrictionResult.CanSpawn;
                foreach (IUnitSpawnRestriction unitSpawnRestriction in results)
                {
                    UnitSpawnRestrictionResult restrictionResult2 = unitSpawnRestriction.CanSpawn();
                    if (restrictionResult2 > restrictionResult)
                    {
                        restrictionResult = restrictionResult2;
                    }
                }
                if (restrictionResult == UnitSpawnRestrictionResult.Delay)
                {
                    Main.LogDebug("Restriction result: Delay");
                    return;
                }
                if (restrictionResult == UnitSpawnRestrictionResult.Disable)
                {
                    Main.LogDebug("Restriction result: Disable");
                    return;
                }
                bool cutsceneCheck = !AreaEdits.ProceduralSpawnAreaBlacklist.Any((BlueprintArea x) => x.name == Game.Instance.CurrentlyLoadedArea.name);
                if (cutsceneCheck)
                {
                    if (__instance.Blueprint.Faction == Factions.FactionMobs && !__instance.Blueprint.IsCheater && !__instance.Blueprint.IsFake && Units.UnitLists.allowedEnemiesList.Contains(__instance.Blueprint))
                    {
                        BlueprintUnit originalBP = __instance.Blueprint;
                        BlueprintUnit result = RandomSpawnLogic.TryChangeBp(__instance.Blueprint);
                        if (result != null && result.Name != "<null>" && result.Name != "")
                        {
                            __instance.Blueprint = result;
                            Main.LogDebug("Changed Bp from to " + originalBP + " " + __instance.Blueprint);
                        }
                        else Main.LogDebug("result BP was null");


                    }
                }
                return;
                
            }
            public static void Postfix(UnitSpawnerBase __instance)
            {
                if (__instance == null) { return; }

                UnitEntityData entityData = __instance.Data.SpawnedUnit.Value;
                if (entityData != null && !__instance.Data.HasDied && __instance.Data.IsInGame && !__instance.SpawnedUnitHasDied && __instance.Data.HasSpawned && !__instance.m_Blueprint.IsEmpty())
                {
                    // Main.LogDebug("Passed CutsCeneCheck");
                    bool factionCheck = (entityData.IsPlayersEnemy && entityData.CutsceneControlledUnit == null);
                    if (factionCheck)
                    {

                        //(Descriptor.State.IsFinallyDead && !entityData.Descriptor.State.Features.SuppressedDecomposition && !IsDeadAndHasLoot && !IsPlayerFaction && !Descriptor.State.Features.Immortality)
                        // Main.LogDebug("Passed factionCheck");
                        bool unitCheck = (!entityData.IsDeadAndHasLoot && !entityData.m_IsDeathRevealed && entityData.MaxHP > 5);
                        if (unitCheck)
                        {
                            Main.LogDebug("Trying to create loot ");
                            int level = LootHandler.CalculateLevel();
                            LootHandler.GiveRandom(entityData, level);

                            //Main.LogDebug("Passed unitCheck");
                            // blacklist already handled groups & allowed enemy lists & blacklisted unitgroup names (these are added as some are used for cinematic triggers)

                        }
                        else { Main.LogDebug(entityData + "Unit bp was fake/cheater"); }
                    }
                    else { Main.LogDebug(entityData + "Faction is not mobs, they are " + __instance.Blueprint.Faction); }
                }
                else { Main.LogDebug(entityData + "Cutscene active or blacklisted area " + Game.Instance.CurrentlyLoadedArea.AreaName + " " + Game.Instance.CurrentlyLoadedArea.AreaName.Key); }

            }
        }
    }
    }
