using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModSettings;

namespace TimberwolvesAnywhere
{
    public enum SpawnType
    {
        Default,
        Timberwolves,
        RegularWolves
    }
    internal class TimberwolfSettings : JsonModSettings
    {
        [Name("Ash Canyon")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType ashCanyonWolves = SpawnType.Default;

        [Name("Bleak Inlet")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType bleakInletWolves = SpawnType.Default;

        [Name("Broken Railroad")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType brokenRailroadWolves = SpawnType.Default;

        [Name("Coastal Highway")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType coastalHighwayWolves = SpawnType.Default;

        [Name("Desolation Point")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType desolationPointWolves = SpawnType.Default;

        [Name("Forlourn Muskeg")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType forlournMuskegWolves = SpawnType.Default;

        [Name("Hushed River Valley")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType hushedRiverValleyWolves = SpawnType.Default;

        [Name("Mountain Town")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType mountainTownWolves = SpawnType.Default;

        [Name("Mystery Lake")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType mysteryLakeWolves = SpawnType.Default;

        [Name("Pleasant Valley")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType pleasantValleyWolves = SpawnType.Default;

        [Name("Timberwolf Mountain")]
        [Description("The type of wolf to spawn in this region.")]
        [Choice("Default", "Timberwolves", "Only Regular Wolves")]
        public SpawnType timberwolfMountainWolves = SpawnType.Default;
    }
    internal static class Settings
    {
        internal static TimberwolfSettings options;
        internal static void OnLoad()
        {
            options = new TimberwolfSettings();
            options.AddToModSettings("Timberwolves Anywhere", MenuType.MainMenuOnly);
        }
    }
}
