using Kingmaker;
using Kingmaker.EntitySystem;
using Kingmaker.Utility;
using Kingmaker.View.MapObjects;
using RandomEnemies.Utilities;
using ModMaker.Utility;
using Owlcat.Runtime.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering;
using Kingmaker.EntitySystem.Entities;

namespace RandomEnemies.Mechanics
{
    public static class LootHelper
    {
        public static IEnumerable<LootWrapper> GetEntitiesCurrentArea()
        {
            SetWrap.EnsureContainersChecked();
            var lootWrapperList = new List<LootWrapper>();

            var interactionLootParts = Game.Instance.State.Units
                .Where<UnitEntityData>(e => e.IsPlayersEnemy)
                .Where<UnitEntityData>(e => !e.IsDeadAndHasLoot)
                .Select<EntityDataBase, InteractionLootPart>(i => i.Get<InteractionLootPart>())
                .Where<InteractionLootPart>(i => i?.Loot != Game.Instance.Player.SharedStash)
                .NotNull<InteractionLootPart>();

            var source = TempList.Get<InteractionLootPart>();

            foreach (var interactionLootPart in interactionLootParts)
            {
                if (!interactionLootPart.IsViewed)
                    source.Add(interactionLootPart);
            }

            var collection = source.Distinct<InteractionLootPart>((IEqualityComparer<InteractionLootPart>)new MassLootHelper.LootDuplicateCheck()).Select<InteractionLootPart, LootWrapper>((Func<InteractionLootPart, LootWrapper>)(i => new LootWrapper()
            {
                InteractionLoot = i
            }));

            lootWrapperList.AddRange(collection);
            return (IEnumerable<LootWrapper>)lootWrapperList;
        }

        public static int Worth(this LootWrapper container)
        {
            return container.InteractionLoot.Loot.Items.Select(i => i.Cost).Sum();
        }
    }
}