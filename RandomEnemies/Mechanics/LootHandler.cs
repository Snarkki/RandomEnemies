using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Entities;
using RandomEnemies.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandomEnemies.Equipment.LootTypes;

namespace RandomEnemies.Mechanics
{
	public class LootHandler
	{
		public static LootType RollForLootType()
		{
			int lootCheck = UnityEngine.Random.Range(1, 100);
			if (lootCheck > (int)Main.settings.ChanceForLootDrop)
			{ return LootType.None; }
			// rolls for what kind of loot - NONE is valid here, if none -> no loot created.
			int lootRoll = UnityEngine.Random.Range(1, 100);

			if (lootRoll <= 50) { return LootType.Weapons; }
			else if (lootRoll <= 70) { return LootType.Armors; }
			else if (lootRoll <= 95) { return LootType.Equipment; }
			else if (lootRoll <= 100) { return LootType.Shields; }
			else return LootType.None;
		}

		public static UnityEngine.RangeInt CreateRangeForLoot(UnitEntityData entityData)
		{
			int multiplier = 1;
			//if (entityData.CR > PlayerLevel) { checkLevel = entityData.CR; };
			UnityEngine.RangeInt resultRange;

			// Roll for additional max range multiplier -> allows chance for better items
			// note min range stays same!! highend items should require multiplier roll + high char lvl and then random roll from list (multipleir chance can be littl higher as it just means the items are on list, 
			// but list still contains mostly low lvl items
			int rangeRoll = UnityEngine.Random.Range(1, 100);
			if (rangeRoll <= 60) { multiplier = 1; }
			else if (rangeRoll <= 80) { multiplier = 2; }
			else if (rangeRoll <= 90) { multiplier = 3; }
			else if (rangeRoll <= 99) { multiplier = 4; }
			else if (rangeRoll <= 100) { multiplier = 20; }

			int minRange = entityData.CR * 100;
			int maxRange = entityData.CR * 1500 * multiplier;
			resultRange = new UnityEngine.RangeInt(minRange, maxRange);
			return resultRange;
		}
		public static BlueprintItem CreateLootItem(LootType lootType, UnityEngine.RangeInt range)
		{
			// Create the actual loot based on the type & range, range meaning min/ max gold of item.
			int costBottom = range.start;
			int costTop = range.end;

			BlueprintItem result;

			switch (lootType)
			{
				case LootType.Weapons:
					result = Helpers.Create<BlueprintItem>();
					{
						bool weaponPredicate(BlueprintItemWeapon b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
						BlueprintItemWeapon[] finalSelectedItems = Equipment.Weapons.WeaponList.Where(weaponPredicate).ToArray<BlueprintItemWeapon>();
						List<BlueprintItemWeapon> modFinalItems = finalSelectedItems.ToList<BlueprintItemWeapon>();

						finalSelectedItems = modFinalItems.ToArray();
						bool itemCheck = finalSelectedItems.Length != 0;
						if (itemCheck) { result = finalSelectedItems.Random<BlueprintItemWeapon>().ToReference<BlueprintItemReference>(); }
					};
					break;
				case LootType.Armors:
					result = Helpers.Create<BlueprintItem>();
					{
						bool weaponPredicate(BlueprintItemArmor b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
						BlueprintItemArmor[] finalSelectedItems = Equipment.Armors.ArmorList.Where(weaponPredicate).ToArray<BlueprintItemArmor>();
						List<BlueprintItemArmor> modFinalItems = finalSelectedItems.ToList<BlueprintItemArmor>();

						finalSelectedItems = modFinalItems.ToArray();
						bool itemCheck = finalSelectedItems.Length != 0;
						if (itemCheck) { result = finalSelectedItems.Random<BlueprintItemArmor>().ToReference<BlueprintItemReference>(); }
					};
					break;
				case LootType.Equipment:
					result = Helpers.Create<BlueprintItem>();
					{
						bool weaponPredicate(BlueprintItemEquipment b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
						BlueprintItemEquipment[] finalSelectedItems = Equipment.Equipment.EquipmentList.Where(weaponPredicate).ToArray<BlueprintItemEquipment>();
						List<BlueprintItemEquipment> modFinalItems = finalSelectedItems.ToList<BlueprintItemEquipment>();

						finalSelectedItems = modFinalItems.ToArray();
						bool itemCheck = finalSelectedItems.Length != 0;
						if (itemCheck) { result = finalSelectedItems.Random<BlueprintItemEquipment>().ToReference<BlueprintItemReference>(); }
					};
					break;
				case LootType.Shields:
					result = Helpers.Create<BlueprintItem>();
					{
						bool weaponPredicate(BlueprintItemShield b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
						BlueprintItemShield[] finalSelectedItems = Equipment.Shields.ShieldList.Where(weaponPredicate).ToArray<BlueprintItemShield>();
						List<BlueprintItemShield> modFinalItems = finalSelectedItems.ToList<BlueprintItemShield>();

						finalSelectedItems = modFinalItems.ToArray();
						bool itemCheck = finalSelectedItems.Length != 0;
						if (itemCheck) { result = finalSelectedItems.Random<BlueprintItemShield>().ToReference<BlueprintItemReference>(); }
					};
					break;
				default:
					result = Equipment.Weapons.AmiriSword;
					break;
			}
			// Lower the cost so player doesnt get shit ton of money from these items. The cost is divided later by multiplier by the game. 
			if (result != null) { result.m_Cost = 500; }
			if (result == null) { result = Equipment.Weapons.AmiriSword; }

			return result;
		}
	}
}
