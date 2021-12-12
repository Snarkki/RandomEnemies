using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomEnemies.Utilities
{
	public static class EquipmentTypes
	{
		public static BlueprintArmorType HideBardingType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("bcb6205a498355c47a972558565c7783");
		public static BlueprintArmorType HideType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("7a01292cef39bf2408f7fae7a9f47594");
		public static BlueprintArmorType LeatherBardingType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("503056b4c5a01f44db0ed10ce4c9ef01");
		public static BlueprintArmorType LeatherType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("c850ba40ed3a61b489b438a5ffa71de9");
		public static BlueprintArmorType OakLeathersType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("d3b50e39b4a46f04cb732acdafb1bad1");
		public static BlueprintArmorType PaddedType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("b7e26eed57d524b478c0c90df0f0b8f1");
		public static BlueprintArmorType ScaleBardingType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("abefac7d8f98aeb40a167e0f5978d9c7");
		public static BlueprintArmorType ScalemailType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("f95c21c70a5677346b75e447c7225ba6");
		public static BlueprintArmorType StuddedType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("aae2cb63162d6334b9a9150398124d46");
		public static BlueprintArmorType BandedType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("da1b160cd13f16a429499b96636f6ed9");
		public static BlueprintArmorType BreastplateType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("d326c3c61a84c6f40977c84fab41503d");
		public static BlueprintArmorType ChainmailBardingType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("bdcce0ac4c930b84a849f935a4bdd93e");
		public static BlueprintArmorType ChainmailType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("cd4a47c5bacbff3498e960eec3a83485");
		public static BlueprintArmorType ChainshirtBardingType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("7b9bb0bc92bb7414d8ba44bcdd55ece6");
		public static BlueprintArmorType ChainshirtType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("7467b0ab8641d8f43af7fc46f2108a1a");
		public static BlueprintArmorType ClothType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("56d86616f18533e4d87f9a56a85f015d");
		public static BlueprintArmorType FullBardingType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("55a6ac3d3ed31fc4d8a7f26f509999a8");
		public static BlueprintArmorType FullplateType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("afd9065539b3ac5499eddca923654c4b");
		public static BlueprintArmorType HalfplateType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("a59bf41f441456a4e8b04b09cb889af8");
		public static BlueprintArmorType HaramakiType = ResourcesLibrary.TryGetBlueprint<BlueprintArmorType>("9511d62bcfc57c245bf64350a5933470");
		public static List<BlueprintArmorType> BardingTypeList = new List<BlueprintArmorType>
		{
			EquipmentTypes.LeatherBardingType,
			EquipmentTypes.HideBardingType,
			EquipmentTypes.ScaleBardingType,
			EquipmentTypes.ChainmailBardingType,
			EquipmentTypes.ChainshirtBardingType,
			EquipmentTypes.FullBardingType
		};
		public static BlueprintShieldType HeavyShieldType = ResourcesLibrary.TryGetBlueprint<BlueprintShieldType>("d1b05b901bab9524388ebfa0435902a6");
		public static BlueprintShieldType LightShieldType = ResourcesLibrary.TryGetBlueprint<BlueprintShieldType>("d38e8ea23ce653c4582eb3e002555483");
		public static BlueprintShieldType TowerShieldType = ResourcesLibrary.TryGetBlueprint<BlueprintShieldType>("5f0f4b6e480e7054b8592b5a8b55854a");
		public static BlueprintShieldType BucklerType = ResourcesLibrary.TryGetBlueprint<BlueprintShieldType>("26fcc43f7d20374498d2e1643381d345");
		public static BlueprintWeaponType Bardiche = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("b1cbf457fd471d148b39ae56667f405a");
		public static BlueprintWeaponType Warhammer = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("fac41e149f49cba4a8e06ce39b41a6fa");
		public static BlueprintWeaponType Trident = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("6ff66364e0a2c89469c2e52ebb46365e");
		public static BlueprintWeaponType Tongi = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("13fa38737d46c9e4abc7f4d74aaa59c3");
		public static BlueprintWeaponType ThrowingAxe = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("ca131c71f4fefcb48b30b5991520e01d");
		public static BlueprintWeaponType Starknife = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("5a939137fc039084580725b2b0845c3f");
		public static BlueprintWeaponType Spear = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("4b289eccefe6d704093201e52eb6d123");
		public static BlueprintWeaponType SlingStaff = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("25da2dc95ed4a6b419608c678f2a9cc3");
		public static BlueprintWeaponType Sickle = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("ec2da496c7936e14c9a28ce616a6b4cd");
		public static BlueprintWeaponType Shortsword = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("a7da36e0e7bb60e42b9f23462ce2f4fc");
		public static BlueprintWeaponType Shortspear = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("cf72040b79c99504785976b28d54b2b7");
		public static BlueprintWeaponType Shortbow = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("99ce02fb54639b5439d07c99c55b8542");
		public static BlueprintWeaponType Scythe = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("4eacfc7e152930a45a1a16217c35011c");
		public static BlueprintWeaponType Scimitar = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("d9fbec4637d71bd4ebc977628de3daf3");
		public static BlueprintWeaponType Sai = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("0944f411666c7594aa1398a7476ecf7d");
		public static BlueprintWeaponType Rapier = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("2ece38f30500f454b8569136221e55b0");
		public static BlueprintWeaponType Quarterstaff = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("629736dabac7f9f4a819dc854eaed2d6");
		public static BlueprintWeaponType PunchingDagger = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("89dc4dc5f386e2049b5e0a5e209a3407");
		public static BlueprintWeaponType Nunchaku = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("4703b4c0922142f4cbe8895c10a47a9f");
		public static BlueprintWeaponType Longsword = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("d56c44bc9eb10204c8b386a02c7eed21");
		public static BlueprintWeaponType Longspear = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("fa2dd17cbde7d3f4aa918d467c30516e");
		public static BlueprintWeaponType Longbow = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("7a1211c05ec2c46428f41e3c0db9423f");
		public static BlueprintWeaponType LightPick = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("da922f4cdb60ef548a2ec0168620568a");
		public static BlueprintWeaponType LightMace = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("cf3e703db4b81904e982a66d7b8474ea");
		public static BlueprintWeaponType LightHammer = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("bbf7d0ea57e4c9349b65c82abc6787b4");
		public static BlueprintWeaponType LightCrossbow = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("d525e7a6d8d5aa648a976ac41194b8d0");
		public static BlueprintWeaponType Kukri = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("006ecd4715809b343b7001e859e3ddb2");
		public static BlueprintWeaponType Javelin = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("a70cea34b275522458654beb3c53fe3f");
		public static BlueprintWeaponType HeavyMace = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("d5a167f0f0208dd439ec7481e8989e21");
		public static BlueprintWeaponType HeavyPick = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("a492410f3d65f744c892faf09daad84a");
		public static BlueprintWeaponType HeavyFlail = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("8fefb7e0da38b06408f185e29372c703");
		public static BlueprintWeaponType HeavyCrossbow = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("36d0551b8a28587438a47fcbbf53c083");
		public static BlueprintWeaponType Handaxe = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("54e7473ff73910c47812fd39c897dc1a");
		public static BlueprintWeaponType Greatsword = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("5f824fbb0766a3543bbd6ae50248688f");
		public static BlueprintWeaponType Greatclub = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("1b8c24cd1f9358c48839bb39266468c3");
		public static BlueprintWeaponType Greataxe = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("e8059a8eac62cd74f9171d748a5ae428");
		public static BlueprintWeaponType GnomeHookedHammerHook = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("018ad48ffd3460d47900491656d2ff26");
		public static BlueprintWeaponType GnomeHookedHammerHead = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("91645b645cf121a479c1fabc5678dcb3");
		public static BlueprintWeaponType Glaive = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("7a14a1b224cd173449cb7ffc77d5f65c");
		public static BlueprintWeaponType Flail = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("bf1e53f7442ed0c43bf52d3abe55e16a");
		public static BlueprintWeaponType Fauchard = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("7a40899c4defec94bb9c291bde74f1a8");
		public static BlueprintWeaponType Falchion = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("6ddc9acbbb6e40746a6a1671df1f7b47");
		public static BlueprintWeaponType Falcata = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("1af5621e2ae551e42bd1dd6744d98639");
		public static BlueprintWeaponType Estoc = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("d516765b3c2904e4a939749526a52a9a");
		public static BlueprintWeaponType ElvenCurvedBlade = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("b5e6838ad2a62b146b49619bcf9f42aa");
		public static BlueprintWeaponType EarthBreaker = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("54e960775daa4714fa52e0954d8cf862");
		public static BlueprintWeaponType DwarvenWaraxe = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("a6925f5f897801449a648d865637e5a0");
		public static BlueprintWeaponType DwarvenUrgroshSpearHead = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("c4e95e3c489721e4382fd8514a522f9d");
		public static BlueprintWeaponType DwarvenUrgrosh = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("0ec97c08fdf87e44f8f16ba87b511743");
		public static BlueprintWeaponType DuelingSword = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("a6f7e3dc443ff114ba68b4648fd33e9f");
		public static BlueprintWeaponType DoubleSword = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("e95efb85a0912a7489be69d5f03a5308");
		public static BlueprintWeaponType DoubleAxe = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("87d76c7534506a546a065731ee6a38cd");
		public static BlueprintWeaponType Dart = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("f415ae950523a7843a74d7780dd551af");
		public static BlueprintWeaponType Dagger = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("07cc1a7fceaee5b42b3e43da960fe76d");
		public static BlueprintWeaponType CompositeShortbow = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("011f6f86a0b16df4bbf7f40878c3e80b");
		public static BlueprintWeaponType CompositeLongbow = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("1ac79088a7e5dde46966636a3ac71c35");
		public static BlueprintWeaponType Club = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("26aa0672af2c7d84ba93bec37758c712");
		public static BlueprintWeaponType Battleaxe = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("2bc77aa47f97de348aefcf03ec8fa43b");
		public static BlueprintWeaponType BastardSword = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("d2fe2c5516b56f04da1d5ea51ae3ddfe");
		public static BlueprintWeaponType Kama = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>("f5872eb0deb3a1b48a36549f8d92c19e");
	}
}
