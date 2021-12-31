using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandomEnemies.Main;
using Kingmaker.PubSubSystem;
using Kingmaker;
using Kingmaker.EntitySystem;
using Kingmaker.View.MapObjects;
using Kingmaker.Utility;
using Kingmaker.EntitySystem.Entities;
using Owlcat.Runtime.Core.Utils;
using Kingmaker.Blueprints.Area;
using RandomEnemies.Utilities;
using UnityEngine;
using System.IO;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints;
using Kingmaker.Items;
using Kingmaker.Blueprints.Loot;
using Kingmaker.RuleSystem;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Blueprints.Root;

namespace RandomEnemies.Mechanics
{
    class LootHandler
    {

        public static UnusedLootDict RegLoot = LootJSON.LoadJSON(File.ReadAllText($"{ModPath}/regular.json"));

        public static int Level2Cost(int level)
        {
            return (int)(Math.Pow(level, 2) * 160);
        }

        public static void GiveRandom(UnitEntityData entityData, int level)
        {
            SetWrap.EnsureItemsGiven();
            var blueprint = RegLoot.LootDict.Where(p => p.Value.CR >= (level - 5 >= 1 ? level - 5 : 1) && p.Value.CR <= level && p.Value.Cost <= Level2Cost(level))?.Random().Key;
            if (blueprint.IsNullOrEmpty() || SetWrap.ItemsGiven[Game.Instance.Player.GameId].Contains(blueprint))
            {
                if (3 < level && level < 20)
                    GiveRandom(entityData, level + 1);
                return;
            }
            if (!SetWrap.ItemsGiven[Game.Instance.Player.GameId].Contains(blueprint))
                SetWrap.ItemsGiven[Game.Instance.Player.GameId].Add(blueprint);
            Main.LogDebug($"Gave: {blueprint} to entity {entityData}");
            entityData.Inventory.Add(ResourcesLibrary.TryGetBlueprint<BlueprintItem>(blueprint));
        }

        public static int CalculateLevel()
        {
            var roll = RulebookEvent.Dice.D100;
            var level = Game.Instance.Player.PartyLevel;
            if (0 <= roll && roll < 10)
            {
                level -= 3;
            }
            else if (10 <= roll && roll < 25)
            {
                level -= 2;
            }
            else if (25 <= roll && roll < 40)
            {
                level -= 1;
            }
            else if (40 <= roll && roll < 80)
            {
                //no change
            }
            else if (80 <= roll && roll < 95)
            {
                level += 1;
            }
            else if (95 <= roll && roll < 99)
            {
                level += 2;
            }
            else if (roll == 100)
            {
                level += 3;
            }
            else
            {
                //no change
            }

            if (level < 1)
                level = 1;

            return level;
        }
        public static bool RollForLoot()
        {
            int roll = UnityEngine.Random.Range(1, 100);
            if (roll <= (int)Main.settings.ChanceForLootDrop)
            { return true; }
            else return false;
        }
    }
}

