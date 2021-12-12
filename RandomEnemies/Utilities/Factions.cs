using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomEnemies.Utilities
{
    public class Factions
    {
        public static BlueprintFaction FactionMobs = ResourcesLibrary.TryGetBlueprint<BlueprintFaction>("0f539babafb47fe4586b719d02aff7c4");
        public static BlueprintFaction FactionWildAnimals = ResourcesLibrary.TryGetBlueprint<BlueprintFaction>("b1525b4b33efe0241b4cbf28486cd2cc");
    }
}
