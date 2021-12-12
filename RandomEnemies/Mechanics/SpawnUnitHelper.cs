using HarmonyLib;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Items;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic.Groups;
using Kingmaker.View;
using RandomEnemies.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static RandomEnemies.Equipment.LootTypes;

namespace RandomEnemies.Mechanics
{


    public class SpawnUnitHelper
    { 


        public static List<BlueprintUnit> chosenTheme;
        public static List<BlueprintUnit> backupTheme;
        public static int PlayerLevel = 1;
        public static int MinCR = 0;
        public static int MaxCR = 0;
        public static int MaxSameUnit = 0;
        public static int OrigUnitCR = 0;
        public static List<string> createdUnitID = new List<string>();

        public static void CalculateCRs(string encounterType, BlueprintUnit origUnit)
        {
            OrigUnitCR = origUnit.CR;
            MinCR = SpawnUnitHelper.CalculateMinSingleCR(encounterType, OrigUnitCR, PlayerLevel);
            MaxCR = SpawnUnitHelper.CalculateMaxSingleCR(encounterType, OrigUnitCR, PlayerLevel);
            Main.LogDebug("For BP" + origUnit + "MinMax CR:" + MinCR + " " + MaxCR + " With encounter Type: " + encounterType);
            if (MinCR > MaxCR) { MinCR = MaxCR; }
        }

        public static BlueprintUnit chooseResultUnit(List<BlueprintUnit> chosenTheme, List<BlueprintUnit> backupTheme, int MinCR, int MaxCR)
        {
            // first tries to get result unit type by main theme, then secondary theme, then just loops through all lists until result found (mostly humanoid/demon as they are top of list)
            try
            {
                BlueprintUnit result = chooseResultUnitByTheme(chosenTheme, MinCR, MaxCR);
                //BlueprintUnit result = Units.SummonedEarthElementalLarge; //testing
                if (result == null) { result = chooseResultUnitByTheme(backupTheme, MinCR, MaxCR); }
                if (result == null)
                {
                    foreach (List<BlueprintUnit> p in Units.UnitLists.allLists)
                    {
                        if (p == chosenTheme || p == backupTheme) { continue; }
                        result = chooseResultUnitByTheme(p, MinCR, MaxCR);
                        if (!result) { break; }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Main.LogDebug("Error creating enemy" + ex);
                return null;
            }

        }

        public static BlueprintUnit chooseResultUnitByTheme(List<BlueprintUnit> chosenTheme, int MinCR, int MaxCR) //, bool useMaxCR = default
        {
            BlueprintUnit[] finalSelectedUnits = null;
            //if (useMaxCR == true)
            //{
            //    // idea is to try to get a unit from higher end of the CR pool so we dont spawn shit ton of small things. 
            //    int minCRDummy = (int)Math.Round(MaxCR * 0.95f);
            //    bool predicate(BlueprintUnit b) => b.CR >= minCRDummy && b.CR <= MaxCR;
            //    finalSelectedUnits = chosenTheme.Where(predicate).ToArray<BlueprintUnit>();
            //}
            //if (finalSelectedUnits == null || finalSelectedUnits.Length == 0)
            //{

            //}

            // Fetches a unit from selected unit list (theme) with CR restrictions
            bool predicate(BlueprintUnit b) => b.CR >= MinCR && b.CR <= MaxCR;
            finalSelectedUnits = chosenTheme.Where(predicate).ToArray<BlueprintUnit>();
            List<BlueprintUnit> modFinalUnits = finalSelectedUnits.ToList<BlueprintUnit>();
            finalSelectedUnits = modFinalUnits.ToArray();
            BlueprintUnit result = finalSelectedUnits.Random<BlueprintUnit>();

            return result;
        }

        public static List<BlueprintUnit> ChooseTheme()
        {
            // chooses the main theme for enemy group
            List<BlueprintUnit> resultTheme = new List<BlueprintUnit>();
            int rollForTheme = UnityEngine.Random.Range(1, 100);

            if (rollForTheme <= 30) { resultTheme = Units.UnitLists.HumanoidList; }
            else if (rollForTheme <= 50) { resultTheme = Units.UnitLists.AnimalList; }
            else if (rollForTheme <= 65) { resultTheme = Units.UnitLists.UndeadList; }
            else if (rollForTheme <= 70) { resultTheme = Units.UnitLists.ElementalList; }
            else if (rollForTheme <= 75) { resultTheme = Units.UnitLists.GolemList; }
            else if (rollForTheme <= 90) { resultTheme = Units.UnitLists.OutsiderList; }
            else if (rollForTheme <= 100) { resultTheme = Units.UnitLists.OtherList; }
            //fallback as demon as its longest list
            else resultTheme = Units.UnitLists.OutsiderList;

            return resultTheme;
        }

        public static List<BlueprintUnit> ChooseBackupTheme(List<BlueprintUnit> chosenTheme)
        {
            // Gives a secondary theme to try before just trying any theme. e.g animals & magical beasts go together.
            if (chosenTheme == Units.UnitLists.HumanoidList) { return Units.UnitLists.OutsiderList; }
            else if (chosenTheme == Units.UnitLists.OutsiderList) { return Units.UnitLists.OtherList; }
            else if (chosenTheme == Units.UnitLists.GolemList) { return Units.UnitLists.OtherList; }
            else if (chosenTheme == Units.UnitLists.AnimalList) { return Units.UnitLists.OtherList; }
            else if (chosenTheme == Units.UnitLists.UndeadList) { return Units.UnitLists.OtherList; }
            else if (chosenTheme == Units.UnitLists.OtherList) { return Units.UnitLists.HumanoidList; }
            else if (chosenTheme == Units.UnitLists.ElementalList) { return Units.UnitLists.OtherList; }
            else return Units.UnitLists.OutsiderList;
        }

        public static string getEncounterType()
        {
            // Type meaning raising max CR for unit or multiple easier enemies -> any type can be anykind of encounter, but it weighs the odds to that side.
            string encounterType;
            int rollForType = UnityEngine.Random.Range(1, 100);
            if (rollForType <= Settings.RareEncounterChance)
            {
                encounterType = Settings.RareEncounterName;
            }
            else if (rollForType <= Settings.PowerfulEncounterChance)
            {
                encounterType = Settings.PowerfulEncounterName;
            }
            else if (rollForType <= Settings.EasierEncounterChance)
            {
                encounterType = Settings.EasyEncounterName;
            }
            else encounterType = Settings.CommonEncounterName;
            return encounterType;
        }
        public static int CalculateMinSingleCR(string encounterType, int bpCR, int PlayerLevel)
        {
            // Not using playerlevel currently - maybe better to have encounters try to match original ones....
            if (PlayerLevel < bpCR) { PlayerLevel = bpCR; }
            // minimum CR for an unit in the encounter.
            int MinCR;
            switch (encounterType)
            {
                case (Settings.EasyEncounterName):
                    MinCR = bpCR - 2;
                    break;
                case (Settings.CommonEncounterName):
                    MinCR = bpCR - 1;
                    break;
                case (Settings.PowerfulEncounterName):
                    MinCR = bpCR;
                    break;
                case (Settings.RareEncounterName):
                    MinCR = bpCR + 1;
                    break;
                default:
                    MinCR = 1;
                    break;
            }
            // must be at least!
            if (MinCR < 1)
            {
                MinCR = 1;
            }
            return MinCR;
        }
        public static int CalculateMaxSingleCR(string encounterType, int bpCR, int PlayerLevel)
        {
            if (PlayerLevel < bpCR) { PlayerLevel = bpCR; }
            // maximum CR for single unit in encounter
            int MaxSingleCR = 1;
            // just so early game wont be hell... 
            if (bpCR == 1) { return MaxSingleCR; }
            switch (encounterType)
            {
                case (Settings.EasyEncounterName):
                    MaxSingleCR = (int)Math.Round(bpCR * Settings.EasyEncounterModifier);
                    break;
                case (Settings.CommonEncounterName):
                    MaxSingleCR = (int)Math.Round((bpCR + 1) * Settings.CommonEncounterModifier);
                    break;
                case (Settings.PowerfulEncounterName):
                    MaxSingleCR = (int)Math.Round((bpCR + 1)* Settings.PowerfulEncounterModifier);
                    break;
                case (Settings.RareEncounterName):
                    MaxSingleCR = (int)Math.Round((bpCR + 2) * Settings.RareEncounterModifier);
                    break;
                default:
                    MaxSingleCR = bpCR;
                    break;
            }
            return MaxSingleCR;
        }

        public static bool rollForEncounter()
        {
            int roll = UnityEngine.Random.Range(1, 100);
            if (roll <= (int)Main.settings.ChanceForRandomEncounter)
            { return true; }
            else return false;
        }

    }
    
}
