using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using RandomEnemies.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandomEnemies.Units.Units;

namespace RandomEnemies.Mechanics
{
    public class BPModify
    {
       public static void ChangeUnitBPs()
        {
            List<BlueprintUnit> ModifierZeroBPs = new List<BlueprintUnit>()
            {
                AxiomiteSummoned,
                AzataBralaniSummoned,
                AzataBralaniSummonedAdvanced,
                AzataGhaelSummoned,
                AzataTreantSummoned,
                BogeymanSummoned,
                CR11_BeerElementalElderSummon,
                CR11_GraveknightSummoned,
                CR12_TherukNul,
                CR1_BeerElementalSmallSummon,
                CR3_BeerElementalMediumSummon,
                CR5_BeerElementalLargeSummon,
                CR9_BeerElementalGreatSummon,
                DireBoarSummoned,
                DireWolfSummon,
                DogSummoned,
                FrostGiantSummoned,
                GiantFrogSummoned,
                HamadryadSummon,
                HellhoundSummoned,
                HorseSummoned,
                LeopardSummoned,
                LivingArmorTankSummoned,
                ManticoreSummoned,
                MastodonSummon,
                MephitAirSummoned,
                MephitEarthSummoned,
                MephitFireSummoned,
                MephitWaterSummoned,
                MiteSummoned,
                MonitorLizardSummoned,
                MovanicDevaSummoned,
                NereidSummoned,
                OwlbearSummoned,
                PonySummoned,
                PurpleWormAdvancedSummoned,
                PurpleWormSummoned,
                RedcapSummoned,
                RocSummoned,
                SmilodonSummoned,
                SoulEaterSummoned,
                SpiderSwarmSummoned,
                SummonedAirElementalElder,
                SummonedAirElementalElderInfested,
                SummonedAirElementalGreater,
                SummonedAirElementalHuge,
                SummonedAirElementalLarge,
                SummonedAirElementalMedium,
                SummonedAirElementalSmall,
                SummonedEarthElementalElder,
                SummonedEarthElementalGreater,
                SummonedEarthElementalHuge,
                SummonedEarthElementalLarge,
                SummonedEarthElementalMedium,
                SummonedEarthElementalSmall,
                SummonedFireElementalElder,
                SummonedFireElementalGreater,
                SummonedFireElementalHuge,
                SummonedFireElementalLarge,
                SummonedFireElementalMedium,
                SummonedFireElementalSmall,
                SummonedSkeletonChampion,
                SummonedWaterElementalElder,
                SummonedWaterElementalGreater,
                SummonedWaterElementalHuge,
                SummonedWaterElementalLarge,
                SummonedWaterElementalMedium,
                SummonedWaterElementalSmall,
                ThanadaemonSoulsCloakSummoned,
                ThanadaemonSummoned,
                TreantSummoned,
                WolfSummon,
            };
            // blaaah need to do this so we get experience from units spawned that normally wouldnt give xp
            foreach (BlueprintUnit unit in ModifierZeroBPs)
                {
                    Experience component = unit.GetComponent<Experience>();
                    if (component.Modifier == 0)
                    {
                        component.Modifier = 1;
                    }
                }
            
        }
        // their CR seems really low compared to class levels.
        public static void UpdateCR()
        {
            Units.Units.CR21_SkeletalChampionArcher.GetComponent<Experience>().CR = 15;
            Units.Units.CR15_HellhoundAlpha.GetComponent<Experience>().CR = 10;
        }
        
    }
}
