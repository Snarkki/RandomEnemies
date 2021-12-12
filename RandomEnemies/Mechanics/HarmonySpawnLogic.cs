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

//namespace RandomEnemies.Mechanics
//{
//	public class HarmonySpawnLogic
//	{
//		[HarmonyPatch(typeof(BlueprintsCache), "Init")]
//		private static class ResourcesLibrary_LoadLibrary_Patch
//		{
//			private static bool Prefix()
//			{
//				Main.Log("ResourcesLibrary_LoadLibrary_Patch Called");
//				bool initialized = Initialized;
//				return !initialized;
//			}

//			private static void Postfix()
//			{
//				bool initialized = Initialized;
//				if (!initialized)
//				{
//					Initialized = true;
//					try
//					{
//						RandomSpawnLogic.MainHandler = new RandomSpawnLogic();
//						RandomSpawnLogic.MainHandler.InitializeProceduralSpawn();
//					}
//					catch (Exception ex)
//					{
//						Main.LogDebug("Error while patching library");
//						Main.LogDebug(ex.ToString());
//					}
//				}
//			}
//			[HarmonyPatch(typeof(Game), "OnAreaLoaded")]
//			internal static class UnitSpawner1_Spawn_Patch
//			{
//				public static void Prefix()
//				{
//					// Set Theme on area load. 
//					SpawnUnitHelper.chosenTheme = SpawnUnitHelper.ChooseTheme();
//					SpawnUnitHelper.backupTheme = SpawnUnitHelper.ChooseBackupTheme(SpawnUnitHelper.chosenTheme);
//				}
//			}

//			private static bool Initialized;
//		}
//	}
//}

