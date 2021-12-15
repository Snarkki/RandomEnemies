using System.Collections.Generic;
using ModMaker.Utility;
using Kingmaker;

namespace RandomEnemies.Utilities
{
    public static class SetWrap
    {
        public static string LocalizationFileName
        {
            get => Main.settings.localizationFileName;
            set => Main.settings.localizationFileName = value;
        }
        public static SerializableDictionary<string, HashSet<string>> ContainersChecked
        {
            get => Main.settings.containersChecked;
            set => Main.settings.containersChecked = value;
        }

        public static SerializableDictionary<string, HashSet<string>> ItemsGiven
        {
            get => Main.settings.itemsGiven;
            set => Main.settings.itemsGiven = value;
        }

        public static void EnsureContainersChecked()
        {
            if (SetWrap.ContainersChecked == null)
            {
                SetWrap.ContainersChecked = new SerializableDictionary<string, HashSet<string>>();
                SetWrap.ContainersChecked.Add(Game.Instance.Player.GameId, new HashSet<string>());
            }
            else if (!SetWrap.ContainersChecked.ContainsKey(Game.Instance.Player.GameId))
            {
                SetWrap.ContainersChecked.Add(Game.Instance.Player.GameId, new HashSet<string>());
            }
            else if (SetWrap.ContainersChecked[Game.Instance.Player.GameId] == null)
            {
                SetWrap.ContainersChecked[Game.Instance.Player.GameId] = new HashSet<string>();
            }
        }

        public static void EnsureItemsGiven()
        {
            if (SetWrap.ItemsGiven == null)
            {
                SetWrap.ItemsGiven = new SerializableDictionary<string, HashSet<string>>();
                SetWrap.ItemsGiven.Add(Game.Instance.Player.GameId, new HashSet<string>());
            }
            else if (!SetWrap.ItemsGiven.ContainsKey(Game.Instance.Player.GameId))
            {
                SetWrap.ItemsGiven.Add(Game.Instance.Player.GameId, new HashSet<string>());
            }
            else if (SetWrap.ItemsGiven[Game.Instance.Player.GameId] == null)
            {
                SetWrap.ItemsGiven[Game.Instance.Player.GameId] = new HashSet<string>();
            }
        }
    }
}