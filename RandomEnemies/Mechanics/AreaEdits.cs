using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
namespace RandomEnemies.Mechanics
{
	public static class AreaEdits
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002E54 File Offset: 0x00001054
		public static void SetupAndEditAreas()
		{
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("710c1699aff632c4b9eb69f83942d5e0")); //  AeonQ5RamleyStash
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("5d975faa81f871c4da6d96485721dd7c")); //  Aeon_AreeluLabHouseInThePast
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("74be8ddbfee68ac44b0bbc9fa0359b46")); //  Aeon_DrezenInThePast
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("717ec45ae8715ea4aa040da31038fcf1")); //  Aeon_KenabresInThePast
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("6646702e9acb96b43bb209c9e6fce457")); //  Aeon_MidnightFaneInThePast
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4ff67e4a43ae4db5acabdaab9878ab9a")); //  ArbiterWeaponCheckTestArea
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("84173fc233ed2d34cb21277631c174ee")); //  Area 52
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("22e4873d175e7f34facd68bb3be44c3e")); //  Area
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("45b07a950e25aeb4c971f8696f53e314")); //  Area512
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("a56ef888ed3ddcf4bac9c1210877f605")); //  ArueshalaeRedoubt
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("6147558e4a97a724081ea120a9700be2")); //  Arueshalae_Q1_WhatTheyDreamOf
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("37a055bfae269b8479deb4f72272164a")); //  Arueshalae_Q2_DimalchioMansion
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("1d71d060e97cc4c41916c81ea2d9cca8")); //  Arueshalae_Q3_WhatYouDreamOf
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("d6c02cd9c9292204285838441c6dafdd")); //  Arueshalae_Romance_WhatTheyDreamOf
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("31bab5549f7ea384186159a238360c8d")); //  AzataIsland
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("5a9964cc9d61d2f4a97d9f96e633d1e3")); //  BaseArea
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4c4aa11e9b7e64e4280be38dbe1f0685")); //  BastionOfJustice
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("39d13fab39c8432eb099524d7c79babb")); //  ChickenLair
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("c3a68039dce54d10922953a3966bcd82")); //  Daeran_AlienBossfight
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ba03995f68ef21c43936e213b761965b")); //  Daeran_Q1_KenabresMansion
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("71aa0a62acc36384b9337bbc0a94396f")); //  Daeran_Q2_HeavenDoorstep
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("d3b7552e62f5074439619c903589e686")); //  Daeran_Q3_Autodafe
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2393614075a3d15448d851a7444c6748")); //  DebugDialogPlayer
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("d3836bb7736d4952a1c09210851177f5")); //  DismembermentArea
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("90cc56537a074d58841c8369a3fe8ae5")); //  DLC2_Abyss
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ab2bc9613ffe4c8ba0612b05fc798191")); //  DLC2_ApproachesToTheTavern
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("cda59ec4352849febaf0bf52fd55074d")); //  DLC2_Graveyard
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("dec10943d88040d0962f530cb4f2be63")); //  DLC2_Tavern
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("97622c84997e42949acf567fa2afaa3d")); //  EmberQ1_BaphometsAltar
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("340d5205ca4358a4eb0f6836bc819456")); //  Ember_Q3_Brotherhood
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("a3f0d5be00238c649a42edb97e22b044")); //  GlobalPuzzle_AreshkaArena
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("dab7e98700276964b855d6793ffd83fd")); //  GlobalPuzzle_Bridges
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("17501f76cc3af8342ba6eccbd178fa94")); //  GlobalPuzzle_Cyan
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("8ea944dbefc7c324599509805e65658d")); //  GlobalPuzzle_Green
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("472f64e570afaab45aad7cc304919a40")); //  GlobalPuzzle_Purple
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("b836f67468d1ba843aea89aaf0281c43")); //  GlobalPuzzle_Red
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("7f8046185b8c83940aed106445571a4d")); //  GlobalPuzzle_Start
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("50062f5d95939b746bbbe950ceff89d4")); //  GlobalPuzzle_Yellow
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("9e7095c1bbd7444e9c91808c8d0ae620")); //  IvorySanctum_OutdoorBalcony
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("3091eaedc174f2c45a95a9e9743e9b09")); //  LannWenduagQ1_Neathholm
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("6895cfb45ebc59b4c9c7e522f24d7656")); //  Lich_UnloyalCounselor
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2183cc056a7b5d647ad475c8bc6c2074")); //  LostChapel
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("bad465e5404604346bdf71ef50b3299a")); //  Prologue_Caves_1
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("e31ab967a7accd543bdc420fda370e6d")); //  Prologue_Kenabres
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("af5b69e61c7188f4299877de0289e88d")); //  Prologue_Kenabres_TEST
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("944a6947fe8ffa8458c278aa1c0c4226")); //  Prologue_Labyrinth
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("61fcf2a352daa394ebae399b1348ba62")); //  Prologue_Neathholm
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4fab7fa7251d74e43aaba5b6e4719944")); //  RagdollSetup
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("b912da8ca8180fe4abdc473062141052")); //  Regill_HellknightsVsGargoyles
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("851e4c2352059f044bd1cddbf47c7028")); //  Seelah_Q2_Wedding
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("216b1286f3d81c840ba56460d2fc94ba")); //  Seelah_Q3_JewelerHideout
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("651772c8bfeb6c84e8fb08103cb5a56a")); //  SE_DragonHunt_Attack1
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("9ffe1f8cfff6d48439e602fbda534772")); //  SE_DragonHunt_Attack2
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("47babcc890228a945a69a919a75ff933")); //  SE_GlobalPuzzle_Cyan
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("be4cf06acaba02744bcdf33b1dbd1c40")); //  SE_GlobalPuzzle_Green
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("66730415fa7c29d42a691222d27b8c38")); //  SE_GlobalPuzzle_Purple
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2b25e2e39fbfd7b40b491f388326f079")); //  SE_GlobalPuzzle_Red
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("bcada8838f5c5bb4ca6ef377c1967f01")); //  SE_NoMoreTentacles
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("f9890e11fa993e04194b7198af76b071")); //  SE_Reckoning
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ba45002340891364f8771619d9b4bb3c")); //  SE_RenownExplorer
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("3873633d3c856d249bcb6598aa1606ed")); //  Sosiel_Q2_EradikatorsMassacre
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("460d63306a61d5d4bb4573302a1afaf4")); //  StorytellerTower
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("28a49e115795ed44397b5a1503cef4f0")); //  TricksterCouncil
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("e8f1160e960935344a8aa7466484506d")); //  Ziggurat
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("69a8a5d331f0d7f4c983a1de63b925b0")); //  Capital

			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("7a25c101fe6f7aa46b192db13373d03b")); //  WarCamp - hopefully this means crusaders camp...

		}

		// Token: 0x040000A2 RID: 162
		public static List<BlueprintArea> ProceduralSpawnAreaBlacklist = new List<BlueprintArea>();

		// Token: 0x040000A3 RID: 163
		public static List<BlueprintArea> TempProceduralSpawnAreaBlacklist = new List<BlueprintArea>();
	}
}