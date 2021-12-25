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
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("710c1699aff632c4b9eb69f83942d5e0")); // AeonQ5RamleyStash  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("5d975faa81f871c4da6d96485721dd7c")); // Aeon_AreeluLabHouseInThePast  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("74be8ddbfee68ac44b0bbc9fa0359b46")); // Aeon_DrezenInThePast  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("717ec45ae8715ea4aa040da31038fcf1")); // Aeon_KenabresInThePast  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("6646702e9acb96b43bb209c9e6fce457")); // Aeon_MidnightFaneInThePast  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("8217b05e37078414981d994151f0ffb1")); // AlushinyrraHigherCity  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4f849f5683145d0489db4077e0d7eccf")); // AlushinyrraLowerCity  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("180cdb4b48d561f4cb4ef9a066727960")); // AlushinyrraMediumCity  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4ff67e4a43ae4db5acabdaab9878ab9a")); // ArbiterWeaponCheckTestArea  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("84173fc233ed2d34cb21277631c174ee")); // Area 52  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("22e4873d175e7f34facd68bb3be44c3e")); // Area  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("45b07a950e25aeb4c971f8696f53e314")); // Area512  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2c126421bc8d72d4290ebeaefb61c6d7")); // AreeluLab  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ea19beccbb357fa4e864ac029b0eff48")); // AreeluLabReturn  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("a56ef888ed3ddcf4bac9c1210877f605")); // ArueshalaeRedoubt  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("6147558e4a97a724081ea120a9700be2")); // Arueshalae_Q1_WhatTheyDreamOf  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("37a055bfae269b8479deb4f72272164a")); // Arueshalae_Q2_DimalchioMansion  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("1d71d060e97cc4c41916c81ea2d9cca8")); // Arueshalae_Q3_WhatYouDreamOf  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("d6c02cd9c9292204285838441c6dafdd")); // Arueshalae_Romance_WhatTheyDreamOf  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("31bab5549f7ea384186159a238360c8d")); // AzataIsland  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("5a9964cc9d61d2f4a97d9f96e633d1e3")); // BaseArea  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4c4aa11e9b7e64e4280be38dbe1f0685")); // BastionOfJustice  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("39d13fab39c8432eb099524d7c79babb")); // ChickenLair  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("79db5fb331f9d1842b21ff43eae1ebe6")); // CrinukhCamp  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("00cc5139b1a7dcb48a0a5f5e785ad6ec")); // CrinukhNote  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("c3a68039dce54d10922953a3966bcd82")); // Daeran_AlienBossfight  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ba03995f68ef21c43936e213b761965b")); // Daeran_Q1_KenabresMansion  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("71aa0a62acc36384b9337bbc0a94396f")); // Daeran_Q2_HeavenDoorstep  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("d3b7552e62f5074439619c903589e686")); // Daeran_Q3_Autodafe  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2393614075a3d15448d851a7444c6748")); // DebugDialogPlayer  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("089e897983fef564d9e15b46ff679d7e")); // DefendersHeart  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("d3836bb7736d4952a1c09210851177f5")); // DismembermentArea  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("0414dd5acdb74aa7be773f84fd4847cb")); // DLC1_AxisDungeon  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("b562abee3cd34a749da4c2822fa76728")); // DLC1_Iz  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("04c7121842374495a78d609970f3b7ab")); // DLC1_Iz_AxisLair  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ac8d3c6bdd954eb2b14cbdc7659f20d9")); // DLC1_Threshold_IndoorStart  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("90cc56537a074d58841c8369a3fe8ae5")); // DLC2_Abyss  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ab2bc9613ffe4c8ba0612b05fc798191")); // DLC2_ApproachesToTheTavern  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("83df1d76b1ea41858b89e3b8d9720b60")); // DLC2_Catacombs  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("cda59ec4352849febaf0bf52fd55074d")); // DLC2_Graveyard  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("caf98d57bafa456d9a0afc98f25fe720")); // DLC2_RichQuarter  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("dec10943d88040d0962f530cb4f2be63")); // DLC2_Tavern  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("bba80eee01f64c8f950140ca3e0e74cf")); // DLC2_Theatre  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("e47ebabc569a46de8574a222166ee031")); // DLС1_Ziggurat  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("e64ea961b32088948a211ebf28eaf3cd")); // DrezenBannerAndFatefulNight  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2570015799edf594daf2f076f2f975d8")); // DrezenCapital  
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("6369196c9fe31304b8c17bea915d94c9")); // DrezenCitadel_Level1  
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("019995543cfe2314793bb2898d8fe66f")); // DrezenCitadel_Level2  
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("25b92ce5ec06ea04e9d022e79f1c6d39")); // DrezenCitadel_Prison  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("97622c84997e42949acf567fa2afaa3d")); // EmberQ1_BaphometsAltar  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("340d5205ca4358a4eb0f6836bc819456")); // Ember_Q3_Brotherhood  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("f15ddad0f679cd346af5f083e82dcbb7")); // EstrodTower  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4ba69539b5f982945bd340e99c12739a")); // FatefulNight_Kenabres  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("a3f0d5be00238c649a42edb97e22b044")); // GlobalPuzzle_AreshkaArena  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("dab7e98700276964b855d6793ffd83fd")); // GlobalPuzzle_Bridges  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("17501f76cc3af8342ba6eccbd178fa94")); // GlobalPuzzle_Cyan  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("8ea944dbefc7c324599509805e65658d")); // GlobalPuzzle_Green  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("472f64e570afaab45aad7cc304919a40")); // GlobalPuzzle_Purple  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("b836f67468d1ba843aea89aaf0281c43")); // GlobalPuzzle_Red  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("7f8046185b8c83940aed106445571a4d")); // GlobalPuzzle_Start  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("50062f5d95939b746bbbe950ceff89d4")); // GlobalPuzzle_Yellow  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("26d33f4a884c1764fa0d10fa864ed4b5")); // GreyborQ3_DryCrossroads  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("b14e1c77281fed148b40addba23ea98e")); // Greybor_DragonChase_SE  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("c6487d974ed65724a944eb54a0425067")); // KenabresMapArea  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("18b0d671b79db0e488f5b68da0145d72")); // Kenabres_Rebuilded  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("bc5e7179778a4284daa1e20ec77a0f84")); // Lair_AngelFlowers  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("3091eaedc174f2c45a95a9e9743e9b09")); // LannWenduagQ1_Neathholm  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("44fe8dd5fabba2e48b06fd714a217247")); // Lann_Q3_SavamelekhLair  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("cc7d8a18f7ad9ad40be3d60feaf1ef7e")); // Lann_Q3_Sull  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("6a458dc240bbcfe429491d7925a38ae2")); // Pitax  
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("bad465e5404604346bdf71ef50b3299a")); // Prologue_Caves_1  
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("e31ab967a7accd543bdc420fda370e6d")); // Prologue_Kenabres  
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("af5b69e61c7188f4299877de0289e88d")); // Prologue_Kenabres_TEST  
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("944a6947fe8ffa8458c278aa1c0c4226")); // Prologue_Labyrinth  
			//AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("61fcf2a352daa394ebae399b1348ba62")); // Prologue_Neathholm  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4fab7fa7251d74e43aaba5b6e4719944")); // RagdollSetup  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("b912da8ca8180fe4abdc473062141052")); // Regill_HellknightsVsGargoyles  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("83a099db95e0e6e4485a20b10ce7c28d")); // ReturnToDrezen  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("03fca664fc43fb040aae42bb0f41c23c")); // RE_KareliaCanyon  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("147f91771a79f584492c40eba4cb603f")); // RE_KareliaForest  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("b732856564ff898419dfc2431a01efce")); // RE_KareliaRuins  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("9cccc3f5dd88e00448d500fbe954769c")); // RE_KenabresStreets  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ad3aa89f0d3f463478d25f62991e82b2")); // RE_KenabresStreets02  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("851d755cdab9b9a49ae533fd6add5d52")); // RE_KenabresStreets03  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("80b9a3ae6d4c5f24a9fd5a3968c4003f")); // RE_KenabresStreets04  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("97657db76559e6242b13b7ea922714a9")); // RE_KenabresStreets05  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("fd10ce9065ac3ce4f9955b21819e1aec")); // RE_SarkorisDisaster  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("c7125176689d3814199266e2ad2c3077")); // RE_SarkorisDisaster_2  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("fa42b091997a6914f89a1b2e2e4b3257")); // RE_SnowCliffs  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("a188ac8c8acc065459ce1ca68b41e861")); // RE_SnowHills  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("50581d70db957d64b90d06cd1cd197e9")); // RE_WinterForest  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2a2b91bad89a73b4f9e86b219ed74ce3")); // RE_Worldwound  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("784f113d0dc6d0c4bbac0d91abeb7f32")); // RE_Worldwound_Canyon  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("b99ed02cbe28dfe40ac1299cf971784a")); // RE_WoundCracks  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("08ef1831c8de3274c88d9e2016ea2997")); // RE_WoundCracks_2  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("da702e8d79c6046439c17e7e9cbfd758")); // RE_WoundedForest  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("7d7ea752c95749bda9ae1c45f1af955b")); // RichQuarter2  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ba8f49d4519e74c429b822c2a4288862")); // RoguePaladin_SE1  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ebf0432115e15154bac8020c8be397d0")); // RoguePaladin_SE2  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("5bd0b09567c9e234dae0d3f8c67f4ee0")); // RoguePaladin_SE3  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("e42ac8f154788b84f9c9f6cdb3e5334f")); // Seelah_Q1_Warcamp  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("851e4c2352059f044bd1cddbf47c7028")); // Seelah_Q2_Wedding  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("216b1286f3d81c840ba56460d2fc94ba")); // Seelah_Q3_JewelerHideout  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("07cea781f136f8f4d81b7041a98746ea")); // SE_ApprenticeAmbush  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("5d70e53590864ef4e9e8845f0c38dcbb")); // SE_DefendersHeartWarning  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("651772c8bfeb6c84e8fb08103cb5a56a")); // SE_DragonHunt_Attack1  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("9ffe1f8cfff6d48439e602fbda534772")); // SE_DragonHunt_Attack2  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("47babcc890228a945a69a919a75ff933")); // SE_GlobalPuzzle_Cyan  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("be4cf06acaba02744bcdf33b1dbd1c40")); // SE_GlobalPuzzle_Green  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("66730415fa7c29d42a691222d27b8c38")); // SE_GlobalPuzzle_Purple  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2b25e2e39fbfd7b40b491f388326f079")); // SE_GlobalPuzzle_Red  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("7d3e7db3604682845815eb44082ad22d")); // SE_IngerMaggor  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("1b65a60056730a8448b79d0d57f4739a")); // SE_MeetAnemora  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("321e6e7d61e3ad54fa6f098acc591509")); // SE_MeetNenio  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("bcada8838f5c5bb4ca6ef377c1967f01")); // SE_NoMoreTentacles  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("f9890e11fa993e04194b7198af76b071")); // SE_Reckoning  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ba45002340891364f8771619d9b4bb3c")); // SE_RenownExplorer  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("3873633d3c856d249bcb6598aa1606ed")); // Sosiel_Q2_EradikatorsMassacre  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("460d63306a61d5d4bb4573302a1afaf4")); // StorytellerTower  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2c401433834c0e44f97598d32a581500")); // TestArea1  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("0737e9dab85b9984daecdbf8eb4ddf68")); // TestArea2  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("fbe119150585526469ae85a3aff8094d")); // Trader_Desert  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("70e1898c5d62e2b47bba99330f447660")); // Trader_Karelia  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("ac97038913a452d4789e11f4c3eedc66")); // Trader_Winter  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("28a49e115795ed44397b5a1503cef4f0")); // TricksterCouncil  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("2dfec36e32489fb48975c55b52f2423b")); // Tutorial_Test_Polygon  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("7a25c101fe6f7aa46b192db13373d03b")); // WarCamp  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("5ad96c86d3ae345459614e19399bd5e8")); // Woljif_Q1_Shop  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("21614262f3fbfb94ba9634d595697e69")); // Woljif_Q1_ThieflingsHideout  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("cdd144cba83973e46abf8c4581aae018")); // Woljif_Q2_CultistsRunaway  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("4324624fa766ab8489f7882701d1ff58")); // Woljif_Q2_Rite  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("9c48e9e4a2a83bb46acc0b24fb326624")); // Woljif_Q2_VoetielMeeting  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("eadccd4b87958924b87ca5566a853f9e")); // Woljif_Q3_AbandonedMansion  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("362dacd5490050b45aa6828c65a7d4c4")); // WoundWormsLair  
			AreaEdits.ProceduralSpawnAreaBlacklist.Add(ResourcesLibrary.TryGetBlueprint<BlueprintArea>("e8f1160e960935344a8aa7466484506d")); // Ziggurat  


		}

		// Token: 0x040000A2 RID: 162
		public static List<BlueprintArea> ProceduralSpawnAreaBlacklist = new List<BlueprintArea>();

		// Token: 0x040000A3 RID: 163
		public static List<BlueprintArea> TempProceduralSpawnAreaBlacklist = new List<BlueprintArea>();
	}
}