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

        }
    }
}

