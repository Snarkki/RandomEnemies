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
using Kingmaker.Items;

namespace RandomEnemies.Mechanics
{

    internal class RandomSpawnLogic //: IUnitSpawnHandler, ISubscriber, IGlobalSubscriber
    {

        public static UnitEntityData TryCreateEncounter(UnitEntityData entityData)
        {
            bool rollForEncounter = SpawnUnitHelper.rollForEncounter();
            if (!rollForEncounter) { return null; }

            SpawnUnitHelper.PlayerLevel = Game.Instance.Player.MainCharacter.Value.Descriptor.Progression.CharacterLevel;
            if (SpawnUnitHelper.PlayerLevel > 20) { SpawnUnitHelper.PlayerLevel = 20; } // For legend -> scaling stops at lvl20
            string encounterType = SpawnUnitHelper.getEncounterType();
            SpawnUnitHelper.CalculateCRs(encounterType, entityData.CR);

            if (SpawnUnitHelper.MaxCR == 0) { return null; }
            UnitEntityData newUnit = createNewUnit(entityData);
            if (newUnit == null) { return null; }

            //newUnit.GroupId = entityData.GroupId;
            //entityData.Group.Add(newUnit);

            //newUnit.Descriptor.SwitchFactions(Factions.FactionMobs);
            //newUnit.Descriptor.Faction = Factions.FactionMobs;

            // give guaranteed loot on harder encounters. (we are missing inventories of original mobs so some additional loot should be fine)
            //if (encounterType == Settings.RareEncounterName || encounterType == Settings.PowerfulEncounterName) 
            //{
            //    TryCreateLoot(newUnit, true);
            //}

            Main.SpawnedUnitId.Add(newUnit.UniqueId);

            newUnit.GiveExperienceOnDeath = true;
            //entityData.Unsubscribe();
            //entityData.MarkForDestroy();
            //entityData.Descriptor.State.IsFinallyDead = true;

            return newUnit;

        }

        public static BlueprintUnit TryChangeBp(BlueprintUnit OrigEntity)
        {
            bool rollForEncounter = SpawnUnitHelper.rollForEncounter();
            if (!rollForEncounter) { return null; }

            SpawnUnitHelper.PlayerLevel = Game.Instance.Player.MainCharacter.Value.Descriptor.Progression.CharacterLevel;
            if (SpawnUnitHelper.PlayerLevel > 20) { SpawnUnitHelper.PlayerLevel = 20; } // For legend -> scaling stops at lvl20
            string encounterType = SpawnUnitHelper.getEncounterType();
            SpawnUnitHelper.CalculateCRs(encounterType, OrigEntity.CR);

            if (SpawnUnitHelper.MaxCR == 0) { return null; }
            BlueprintUnit result = chooseResultUnit(chosenTheme, backupTheme, MinCR, MaxCR);
            Main.LogDebug("Choose result result" + result + " Theme " + chosenTheme.ToString() + " backuptheme " + backupTheme.ToString() + " mincr " + MinCR + " MaxCr " + MaxCR);
            if (result == null) { return null; }

            return result;
            //newUnit.GroupId = entityData.GroupId;
            //entityData.Group.Add(newUnit);

            //newUnit.Descriptor.SwitchFactions(Factions.FactionMobs);
            //newUnit.Descriptor.Faction = Factions.FactionMobs;

            // give guaranteed loot on harder encounters. (we are missing inventories of original mobs so some additional loot should be fine)
            //if (encounterType == Settings.RareEncounterName || encounterType == Settings.PowerfulEncounterName) 
            //{
            //    TryCreateLoot(newUnit, true);
            //}



            //entityData.Unsubscribe();
            //entityData.MarkForDestroy();
            //entityData.Descriptor.State.IsFinallyDead = true;


        }

        public static UnitEntityData createNewUnit(UnitEntityData OriginalUnit)
        {
            BlueprintUnit result = chooseResultUnit(chosenTheme, backupTheme, MinCR, MaxCR);
            if (result == null) { return null; }

            float roll1 = UnityEngine.Random.Range(0f, 0f);
            float roll2 = UnityEngine.Random.Range(0f, 0f);
            Vector3 vector = SpawnUnitHelper.FindRandomPositionNearbyWithSelector(OriginalUnit.Position, OriginalUnit, roll1, roll2);

            try
            {
                //UnitEntityData newUnit = Game.Instance.EntityCreator.SpawnUnit(result, vector, UnityEngine.Quaternion.LookRotation(OriginalUnit.OrientationDirection), Game.Instance.State.LoadedAreaState.MainState, null);
                UnitEntityData newUnit = Game.Instance.EntityCreator.ChangeUnitBlueprint(OriginalUnit, result, false);
                Main.Log("Created enemy" + newUnit.CharacterName + " in area: " + Game.Instance.CurrentlyLoadedArea.AreaName + " " + Game.Instance.CurrentlyLoadedArea.AreaName.Key);
                return newUnit;
            }
            catch (Exception ex)
            {
                Main.LogDebug("Error creating enemy" + ex);
                return null;
            }
        }

        //public static void TryCreateLoot(UnitEntityData entityData, bool skipLootCheck = false)
        //{
        //    //Kingmaker.EntitySystem.Persistence.JsonUtility.BlueprintConverter.ReadJson
        //    LootType loottype = LootHandler.RollForLootType(skipLootCheck);
        //    Main.LogDebug("Returned from rollforloot type with" + loottype);
        //    if (loottype == LootType.None) { return; }

            
        //    //RangeInt range = LootHandler.CreateRangeForLoot(entityData);
        //    //BlueprintItem Loot = LootHandler.TryToCreateLootItem(loottype, range);
        //    BlueprintItem Loot = LootHandler.GiveRandom(entityData, entityData.CR);
        //    Main.Log("Trying to add loot " + Loot.Name + "to entity " + entityData.CharacterName + " with range " + range.start + range.end + " with loottype " + loottype + " cost " + Loot.Cost);
        //    if (Loot == null || Loot.Name == "")
        //    {
        //        Main.Log("Loottype was null" + Loot.Name);
        //        return;
        //    }
        //    entityData.Inventory.Add(Loot, 1);
        //    Main.SpawnedUnitsLoots.Add(entityData.UniqueId, Loot);
        //}

    }
}

