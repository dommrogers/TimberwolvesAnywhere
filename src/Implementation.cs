using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace TimberwolvesAnywhere
{
    public class Implementation : MelonMod
    {
        public const string settingDescription = "The type of wolf to spawn in this region. If Random, each pack is treated individually.";
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }
}
