using ModSettings;

namespace TimberwolvesAnywhere
{
	internal sealed class Settings : JsonModSettings
	{
		internal static Settings instance = new Settings();

		[Name("Regular Wolf Percentage")]
		[Description("If you use the random option in any of the settings below, this is the percent probability of a pack containing regular wolves.")]
		[Slider(0f, 100f, 101)]
		public float regularWolfPercentage = 50f;

		[Name("Ash Canyon")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType ashCanyonWolves = SpawnType.Default;

		[Name("Black Rock")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType blackRockWolves = SpawnType.Default;

		[Name("Bleak Inlet")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType bleakInletWolves = SpawnType.Default;

		[Name("Broken Railroad")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType brokenRailroadWolves = SpawnType.Default;

		[Name("Coastal Highway")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType coastalHighwayWolves = SpawnType.Default;

		[Name("Crumbling Highway")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType crumblingHighwayWolves = SpawnType.Default;

		[Name("Desolation Point")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType desolationPointWolves = SpawnType.Default;

		[Name("Forlorn Muskeg")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType forlornMuskegWolves = SpawnType.Default;

		[Name("Hushed River Valley")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType hushedRiverValleyWolves = SpawnType.Default;

		[Name("Keeper's Pass")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType keepersPassWolves = SpawnType.Default;

		[Name("Mountain Town")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType mountainTownWolves = SpawnType.Default;

		[Name("Mystery Lake")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType mysteryLakeWolves = SpawnType.Default;

		[Name("Pleasant Valley")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType pleasantValleyWolves = SpawnType.Default;

		[Name("Timberwolf Mountain")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType timberwolfMountainWolves = SpawnType.Default;

		[Name("Winding River")]
		[Description(Implementation.settingDescription)]
		[Choice("Default", "Timberwolves", "Regular Wolves", "Random")]
		public SpawnType windingRiverWolves = SpawnType.Default;
	}
}
