using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TimberwolvesAnywhere
{
    internal class Patches
    {
        [HarmonyPatch(typeof(SpawnRegion), "Deserialize")]
        internal class OnlyTimberwolvesDeserialize
        {
            private static void Postfix(SpawnRegion __instance)
            {
                if (__instance.m_AiSubTypeSpawned == AiSubType.Wolf)
                {
                    //MelonLoader.MelonLogger.Log("Deserialize");
                    AdjustToRegionSetting(__instance);
                }
            }
        }
        [HarmonyPatch(typeof(SpawnRegion), "Start")]
        internal class OnlyTimberwolvesStart
        {
            private static void Postfix(SpawnRegion __instance)
            {
                if (__instance.m_AiSubTypeSpawned == AiSubType.Wolf)
                {
                    //MelonLoader.MelonLogger.Log("Start");
                    AdjustToRegionSetting(__instance);
                }
            }
        }
        private static void AdjustToRegionSetting(SpawnRegion spawnRegion)
        {
            string sceneName = GameManager.m_ActiveScene;
            if (sceneName is null) return;
            if (sceneName == "AshCanyonRegion") SetWolfType(spawnRegion, Settings.options.ashCanyonWolves);
            else if (sceneName == "CanneryRegion") SetWolfType(spawnRegion, Settings.options.bleakInletWolves);
            else if (sceneName == "TracksRegion") SetWolfType(spawnRegion, Settings.options.brokenRailroadWolves);
            else if (sceneName == "CoastalRegion") SetWolfType(spawnRegion, Settings.options.coastalHighwayWolves);
            else if (sceneName == "HighwayTransitionZone") SetWolfType(spawnRegion, Settings.options.crumblingHighwayWolves);
            else if (sceneName == "WhalingStationRegion") SetWolfType(spawnRegion, Settings.options.desolationPointWolves);
            else if (sceneName == "MarshRegion") SetWolfType(spawnRegion, Settings.options.forlornMuskegWolves);
            else if (sceneName == "RiverValleyRegion") SetWolfType(spawnRegion, Settings.options.hushedRiverValleyWolves);
            else if (sceneName == "MountainTownRegion") SetWolfType(spawnRegion, Settings.options.mountainTownWolves);
            else if (sceneName == "LakeRegion") SetWolfType(spawnRegion, Settings.options.mysteryLakeWolves);
            else if (sceneName == "RuralRegion") SetWolfType(spawnRegion, Settings.options.pleasantValleyWolves);
            else if (sceneName == "CrashMountainRegion") SetWolfType(spawnRegion, Settings.options.timberwolfMountainWolves);
            else if (sceneName == "DamRiverTransitionZoneB") SetWolfType(spawnRegion, Settings.options.windingRiverWolves);
        }
        private static void SetWolfType(SpawnRegion spawnRegion,SpawnType spawnType)
        {
            if (spawnRegion is null) return;
            switch (spawnType)
            {
                case SpawnType.RegularWolves:
                    MakeRegularWolves(spawnRegion);
                    return;
                case SpawnType.Timberwolves:
                    MakeTimberwolves(spawnRegion);
                    return;
                case SpawnType.Random:
                    MakeRandomWolves(spawnRegion);
                    return;
            }
        }
        private static void MakeTimberwolves(SpawnRegion spawnRegion)
        {
            if (spawnRegion is null) return;
            GameObject timberwolf = Resources.Load("WILDLIFE_Wolf_grey")?.Cast<GameObject>();
            GameObject timberwolf_aurora = Resources.Load("WILDLIFE_Wolf_grey_aurora")?.Cast<GameObject>();
            if (timberwolf && timberwolf_aurora)
            {
                spawnRegion.m_AuroraSpawnablePrefab = timberwolf_aurora;
                spawnRegion.m_SpawnablePrefab = timberwolf;
                AdjustTimberwolfPackSize(spawnRegion);
            }
        }
        private static void MakeRegularWolves(SpawnRegion spawnRegion)
        {
            if (spawnRegion is null) return;
            GameObject regularWolf = Resources.Load("WILDLIFE_Wolf")?.Cast<GameObject>();
            GameObject regularWolf_aurora = Resources.Load("WILDLIFE_Wolf_aurora")?.Cast<GameObject>();
            if (regularWolf && regularWolf_aurora)
            {
                spawnRegion.m_AuroraSpawnablePrefab = regularWolf_aurora;
                spawnRegion.m_SpawnablePrefab = regularWolf;
            }
        }

        private static void MakeRandomWolves(SpawnRegion spawnRegion)
        {
            if (Utils.RollChance(Settings.options.regularWolfPercentage)) MakeRegularWolves(spawnRegion);
            else MakeTimberwolves(spawnRegion);
        }

        private static void AdjustTimberwolfPackSize(SpawnRegion spawnRegion)
        {
            if (spawnRegion is null) return;
            spawnRegion.m_MaxSimultaneousSpawnsDayInterloper = NotOne(spawnRegion.m_MaxSimultaneousSpawnsDayInterloper);
            spawnRegion.m_MaxSimultaneousSpawnsDayPilgrim = NotOne(spawnRegion.m_MaxSimultaneousSpawnsDayPilgrim);
            spawnRegion.m_MaxSimultaneousSpawnsDayStalker = NotOne(spawnRegion.m_MaxSimultaneousSpawnsDayStalker);
            spawnRegion.m_MaxSimultaneousSpawnsDayVoyageur = NotOne(spawnRegion.m_MaxSimultaneousSpawnsDayVoyageur);
            spawnRegion.m_MaxSimultaneousSpawnsNightInterloper = NotOne(spawnRegion.m_MaxSimultaneousSpawnsNightInterloper);
            spawnRegion.m_MaxSimultaneousSpawnsNightPilgrim = NotOne(spawnRegion.m_MaxSimultaneousSpawnsNightPilgrim);
            spawnRegion.m_MaxSimultaneousSpawnsNightStalker = NotOne(spawnRegion.m_MaxSimultaneousSpawnsNightStalker);
            spawnRegion.m_MaxSimultaneousSpawnsNightVoyageur = NotOne(spawnRegion.m_MaxSimultaneousSpawnsNightVoyageur);
        }

        private static int NotOne(int num)
        {
            if (num == 1) return 2;
            else return num;
        }
    }
}
