using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Items;
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
        public static LootType RollForLootType(bool skipLootCheck = false)
        {
            LootType result = LootType.None;
            if (skipLootCheck == false)
            {
                int lootCheck = UnityEngine.Random.Range(1, 100);
                if (lootCheck > (int)Main.settings.ChanceForLootDrop)
                {
                 Main.LogDebug("Returning with LootType.None, roll " + lootCheck + " " + (int)Main.settings.ChanceForLootDrop);
                 return result; 
                }
            }
            // rolls for what kind of loot - NONE is valid here, if none -> no loot created.
            int lootRoll = UnityEngine.Random.Range(1, 100);
            Main.LogDebug("lootRoll roll " + lootRoll);
            if (lootRoll <= 50) { result = LootType.Weapons; }
            else if (lootRoll <= 70) { result = LootType.Armors; }
            else if (lootRoll <= 100) { result = LootType.Equipment; }
            //else if (lootRoll <= 100) { result = LootType.Shields; }

            return result;
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
            if (rangeRoll <= 60) { multiplier = 2; }
            else if (rangeRoll <= 80) { multiplier = 10; }
            else if (rangeRoll <= 90) { multiplier = 20; }
            else if (rangeRoll <= 99) { multiplier = 50; }
            else if (rangeRoll <= 100) { multiplier = 150; }

            int minRange = entityData.CR * 50 * multiplier;
            int maxRange = entityData.CR * 100 * multiplier;
            resultRange = new UnityEngine.RangeInt(minRange, maxRange);
            return resultRange;
        }

        public static BlueprintItem TryToCreateLootItem(LootType lootType, UnityEngine.RangeInt range)
        {
            BlueprintItem Loot = null;
            int i = 0;
            do
            {
                Loot = LootHandler.CreateLootItem(lootType, range);
                i++;
                if (Loot.Name != "" && Loot == null && Loot.Name == "<null>")
                {
                    break;
                }
            } while (i < 10);
            return Loot;
        }

        public static BlueprintItem CreateLootItem(LootType lootType, UnityEngine.RangeInt range)
        {
            // Create the actual loot based on the type & range, range meaning min/ max gold of item.
            int costBottom = range.start;
            int costTop = range.end;
            
            BlueprintItem result;
            Main.LogDebug("Finding BP for Loot, lootType: " + lootType + " " + costBottom + " " + costTop);
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
                        Main.LogDebug("Trying equipment weapon, result: " + result + " " + costBottom + " " + costTop);
                        return result;
                    };

                case LootType.Armors:
                    result = Helpers.Create<BlueprintItem>();
                    {
                        bool weaponPredicate(BlueprintItemArmor b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                        BlueprintItemArmor[] finalSelectedItems = Equipment.Armors.ArmorList.Where(weaponPredicate).ToArray<BlueprintItemArmor>();
                        List<BlueprintItemArmor> modFinalItems = finalSelectedItems.ToList<BlueprintItemArmor>();

                        finalSelectedItems = modFinalItems.ToArray();
                        bool itemCheck = finalSelectedItems.Length != 0;
                        if (itemCheck) { result = finalSelectedItems.Random<BlueprintItemArmor>().ToReference<BlueprintItemReference>(); }
                        Main.LogDebug("Trying equipment armor, result: " + result + " " + costBottom + " " + costTop);
                        return result;
                    };
                case LootType.Equipment:
                    result = Helpers.Create<BlueprintItem>();
                    {

                        for (int i = 0; i < 10; i++)
                        {
                            var value = RandomEnumValue<Equipment.LootTypes.EquipmentTypes>();
                            switch (value)
                            {
                                case (EquipmentTypes.Shoulders):
                                    bool PredicateShoulders(BlueprintItemEquipmentShoulders b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentShoulders[] finalSelectedItemsShoulders = Equipment.Equipment.EquipmentListShoulders.Where(PredicateShoulders).ToArray<BlueprintItemEquipmentShoulders>();
                                    List<BlueprintItemEquipmentShoulders> modFinalItems = finalSelectedItemsShoulders.ToList<BlueprintItemEquipmentShoulders>();

                                    finalSelectedItemsShoulders = modFinalItems.ToArray();
                                    bool itemCheck = finalSelectedItemsShoulders.Length != 0;
                                    if (itemCheck)
                                    {
                                        result = finalSelectedItemsShoulders.Random<BlueprintItemEquipmentShoulders>().ToReference<BlueprintItemEquipmentShouldersReference>();
                                        Main.LogDebug("Trying equipment shoulder, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Belt):
                                    bool PredicateBelt(BlueprintItemEquipmentBelt b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentBelt[] finalSelectedItemsBelt = Equipment.Equipment.EquipmentListBelt.Where(PredicateBelt).ToArray<BlueprintItemEquipmentBelt>();
                                    List<BlueprintItemEquipmentBelt> modFinalItemsBelt = finalSelectedItemsBelt.ToList<BlueprintItemEquipmentBelt>();

                                    finalSelectedItemsBelt = finalSelectedItemsBelt.ToArray();
                                    bool itemCheckBelt = finalSelectedItemsBelt.Length != 0;
                                    if (itemCheckBelt)
                                    {
                                        result = finalSelectedItemsBelt.Random<BlueprintItemEquipmentBelt>().ToReference<BlueprintItemEquipmentBeltReference>();
                                        Main.LogDebug("Trying equipment belt, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Wrist):
                                    bool PredicateWrist(BlueprintItemEquipmentWrist b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentWrist[] finalSelectedItemsWrist = Equipment.Equipment.EquipmentListWrist.Where(PredicateWrist).ToArray<BlueprintItemEquipmentWrist>();
                                    List<BlueprintItemEquipmentWrist> modFinalItemsWrist = finalSelectedItemsWrist.ToList<BlueprintItemEquipmentWrist>();

                                    finalSelectedItemsWrist = finalSelectedItemsWrist.ToArray();
                                    bool itemCheckWrist = finalSelectedItemsWrist.Length != 0;
                                    if (itemCheckWrist)
                                    {
                                        result = finalSelectedItemsWrist.Random<BlueprintItemEquipmentWrist>().ToReference<BlueprintItemEquipmentWristReference>();
                                        Main.LogDebug("Trying equipment wrist, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Feet):
                                    bool PredicateFeet(BlueprintItemEquipmentFeet b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentFeet[] finalSelectedItemsFeet = Equipment.Equipment.EquipmentListFeet.Where(PredicateFeet).ToArray<BlueprintItemEquipmentFeet>();
                                    List<BlueprintItemEquipmentFeet> modFinalItemsFeet = finalSelectedItemsFeet.ToList<BlueprintItemEquipmentFeet>();

                                    finalSelectedItemsFeet = finalSelectedItemsFeet.ToArray();
                                    bool itemCheckFeet = finalSelectedItemsFeet.Length != 0;
                                    if (itemCheckFeet)
                                    {
                                        result = finalSelectedItemsFeet.Random<BlueprintItemEquipmentFeet>().ToReference<BlueprintItemEquipmentFeetReference>();
                                        Main.LogDebug("Trying equipment feet, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Glasses):
                                    bool PredicateGlasses(BlueprintItemEquipmentGlasses b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentGlasses[] finalSelectedItemsGlasses = Equipment.Equipment.EquipmentListGlasses.Where(PredicateGlasses).ToArray<BlueprintItemEquipmentGlasses>();
                                    List<BlueprintItemEquipmentGlasses> modFinalItemsGlasses = finalSelectedItemsGlasses.ToList<BlueprintItemEquipmentGlasses>();

                                    finalSelectedItemsGlasses = finalSelectedItemsGlasses.ToArray();
                                    bool itemCheckGlasses = finalSelectedItemsGlasses.Length != 0;
                                    if (itemCheckGlasses)
                                    {
                                        result = finalSelectedItemsGlasses.Random<BlueprintItemEquipmentGlasses>().ToReference<BlueprintItemEquipmentGlassesReference>();
                                        Main.LogDebug("Trying equipment glasses, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Gloves):
                                    bool PredicateGloves(BlueprintItemEquipmentGloves b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentGloves[] finalSelectedItemsGloves = Equipment.Equipment.EquipmentListGloves.Where(PredicateGloves).ToArray<BlueprintItemEquipmentGloves>();
                                    List<BlueprintItemEquipmentGloves> modFinalItemsGloves = finalSelectedItemsGloves.ToList<BlueprintItemEquipmentGloves>();

                                    finalSelectedItemsGloves = finalSelectedItemsGloves.ToArray();
                                    bool itemCheckGloves = finalSelectedItemsGloves.Length != 0;
                                    if (itemCheckGloves)
                                    {
                                        result = finalSelectedItemsGloves.Random<BlueprintItemEquipmentGloves>().ToReference<BlueprintItemEquipmentGlovesReference>();
                                        Main.LogDebug("Trying equipment gloves, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Head):
                                    bool PredicateHead(BlueprintItemEquipmentHead b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentHead[] finalSelectedItemsHead = Equipment.Equipment.EquipmentListHead.Where(PredicateHead).ToArray<BlueprintItemEquipmentHead>();
                                    List<BlueprintItemEquipmentHead> modFinalItemsHead = finalSelectedItemsHead.ToList<BlueprintItemEquipmentHead>();

                                    finalSelectedItemsHead = finalSelectedItemsHead.ToArray();
                                    bool itemCheckHead = finalSelectedItemsHead.Length != 0;
                                    if (itemCheckHead)
                                    {
                                        result = finalSelectedItemsHead.Random<BlueprintItemEquipmentHead>().ToReference<BlueprintItemEquipmentHeadReference>();
                                        Main.LogDebug("Trying equipment head, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Shirt):
                                    bool PredicateShirt(BlueprintItemEquipmentShirt b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentShirt[] finalSelectedItemsShirt = Equipment.Equipment.EquipmentListShirt.Where(PredicateShirt).ToArray<BlueprintItemEquipmentShirt>();
                                    List<BlueprintItemEquipmentShirt> modFinalItemsShirt = finalSelectedItemsShirt.ToList<BlueprintItemEquipmentShirt>();

                                    finalSelectedItemsShirt = finalSelectedItemsShirt.ToArray();
                                    bool itemCheckShirt = finalSelectedItemsShirt.Length != 0;
                                    if (itemCheckShirt)
                                    {
                                        result = finalSelectedItemsShirt.Random<BlueprintItemEquipmentShirt>().ToReference<BlueprintItemEquipmentShirtReference>();
                                        Main.LogDebug("Trying equipment shirt, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Ring):
                                    bool PredicateRing(BlueprintItemEquipmentRing b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentRing[] finalSelectedItemsRing = Equipment.Equipment.EquipmentListRing.Where(PredicateRing).ToArray<BlueprintItemEquipmentRing>();
                                    List<BlueprintItemEquipmentRing> modFinalItemsRing = finalSelectedItemsRing.ToList<BlueprintItemEquipmentRing>();

                                    finalSelectedItemsRing = finalSelectedItemsRing.ToArray();
                                    bool itemCheckRing = finalSelectedItemsRing.Length != 0;
                                    if (itemCheckRing)
                                    {
                                        result = finalSelectedItemsRing.Random<BlueprintItemEquipmentRing>().ToReference<BlueprintItemEquipmentRingReference>();
                                        Main.LogDebug("Trying equipment ring, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Neck):
                                    bool PredicateNeck(BlueprintItemEquipmentNeck b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentNeck[] finalSelectedItemsNeck = Equipment.Equipment.EquipmentListNeck.Where(PredicateNeck).ToArray<BlueprintItemEquipmentNeck>();
                                    List<BlueprintItemEquipmentNeck> modFinalItemsNeck = finalSelectedItemsNeck.ToList<BlueprintItemEquipmentNeck>();

                                    finalSelectedItemsNeck = finalSelectedItemsNeck.ToArray();
                                    bool itemCheckNeck = finalSelectedItemsNeck.Length != 0;
                                    if (itemCheckNeck)
                                    {
                                        result = finalSelectedItemsNeck.Random<BlueprintItemEquipmentNeck>().ToReference<BlueprintItemEquipmentNeckReference>();
                                        Main.LogDebug("Trying equipment neck, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                case (EquipmentTypes.Usable):
                                    bool PredicateUsable(BlueprintItemEquipmentUsable b) => b.m_Cost >= costBottom && b.m_Cost < costTop && !b.m_IsNotable;
                                    BlueprintItemEquipmentUsable[] finalSelectedItemsUsable = Equipment.Equipment.EquipmentListUsable.Where(PredicateUsable).ToArray<BlueprintItemEquipmentUsable>();
                                    List<BlueprintItemEquipmentUsable> modFinalItemsUsable = finalSelectedItemsUsable.ToList<BlueprintItemEquipmentUsable>();

                                    finalSelectedItemsUsable = finalSelectedItemsUsable.ToArray();
                                    bool itemCheckUsable = finalSelectedItemsUsable.Length != 0;
                                    if (itemCheckUsable)
                                    {
                                        result = finalSelectedItemsUsable.Random<BlueprintItemEquipmentUsable>().ToReference<BlueprintItemEquipmentUsableReference>();
                                        Main.LogDebug("Trying equipment usable, result: " + result + " " + costBottom + " " + costTop);
                                        return result;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
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
                        Main.LogDebug("Trying equipment shield, result: " + result + " " + costBottom + " " + costTop);
                        return result;
                    };
                default:
                    result = Equipment.Weapons.AmiriSword;
                    break;
            }
            // Lower the cost so player doesnt get shit ton of money from these items. The cost is divided later by multiplier by the game. 
            //if (result != null) { result.m_Cost = 500; }
            if (result == null) { result = Equipment.Weapons.AmiriSword; }

            return result;
        }

        static Random _R = new Random();
        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }

    }

}

