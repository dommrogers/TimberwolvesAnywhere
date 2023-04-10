﻿using MelonLoader;

namespace TimberwolvesAnywhere;

internal sealed class Implementation : MelonMod
{
    public const string settingDescription = "The type of wolf to spawn in this region. If Random, each pack is treated individually.";
	public override void OnInitializeMelon()
	{
        Settings.instance.AddToModSettings("Timberwolves Anywhere");
    }
}
