extern alias Hinterland;
using HarmonyLib;
using Hinterland;
using UnityEngine;

namespace TimberwolvesAnywhere
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(SpawnRegion), "Deserialize")]
        internal class OnlyTimberwolvesDeserialize
        {
            private static void Postfix(SpawnRegion __instance)
            {
                if (__instance.m_AiSubTypeSpawned == AiSubType.Wolf)
                {
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
                    AdjustToRegionSetting(__instance);
                }
            }
        }
		
        private static void AdjustToRegionSetting(SpawnRegion spawnRegion)
        {
            switch (GameManager.m_ActiveScene)
            {
                case "AshCanyonRegion":
                    SetWolfType(spawnRegion, Settings.instance.ashCanyonWolves);
                    break;
                case "CanneryRegion":
                    SetWolfType(spawnRegion, Settings.instance.bleakInletWolves);
                    break;
                case "TracksRegion":
                    SetWolfType(spawnRegion, Settings.instance.brokenRailroadWolves);
                    break;
                case "CoastalRegion":
                    SetWolfType(spawnRegion, Settings.instance.coastalHighwayWolves);
                    break;
                case "HighwayTransitionZone":
                    SetWolfType(spawnRegion, Settings.instance.crumblingHighwayWolves);
                    break;
                case "WhalingStationRegion":
                    SetWolfType(spawnRegion, Settings.instance.desolationPointWolves);
                    break;
                case "MarshRegion":
                    SetWolfType(spawnRegion, Settings.instance.forlornMuskegWolves);
                    break;
                case "RiverValleyRegion":
                    SetWolfType(spawnRegion, Settings.instance.hushedRiverValleyWolves);
                    break;
                case "MountainTownRegion":
                    SetWolfType(spawnRegion, Settings.instance.mountainTownWolves);
                    break;
                case "LakeRegion":
                    SetWolfType(spawnRegion, Settings.instance.mysteryLakeWolves);
                    break;
                case "RuralRegion":
                    SetWolfType(spawnRegion, Settings.instance.pleasantValleyWolves);
                    break;
                case "CrashMountainRegion":
                    SetWolfType(spawnRegion, Settings.instance.timberwolfMountainWolves);
                    break;
                case "DamRiverTransitionZoneB":
                    SetWolfType(spawnRegion, Settings.instance.windingRiverWolves);
                    break;
            }
        }
		
        private static void SetWolfType(SpawnRegion spawnRegion, SpawnType spawnType)
        {
			switch (spawnType)
			{
				case SpawnType.RegularWolves:
					MakeRegularWolves(spawnRegion);
					break;
				case SpawnType.Timberwolves:
					MakeTimberwolves(spawnRegion);
					break;
				case SpawnType.Random:
					MakeRandomWolves(spawnRegion);
					break;
			}
		}
		
        private static void MakeTimberwolves(SpawnRegion spawnRegion)
        {
			GameObject? timberwolf = Resources.Load("WILDLIFE_Wolf_grey")?.Cast<GameObject>();
			GameObject? timberwolf_aurora = Resources.Load("WILDLIFE_Wolf_grey_aurora")?.Cast<GameObject>();
			if (timberwolf && timberwolf_aurora)
			{
				spawnRegion.m_AuroraSpawnablePrefab = timberwolf_aurora;
				spawnRegion.m_SpawnablePrefab = timberwolf;
				AdjustTimberwolfPackSize(spawnRegion);
			}
		}
		
        private static void MakeRegularWolves(SpawnRegion spawnRegion)
        {
			GameObject? regularWolf = Resources.Load("WILDLIFE_Wolf")?.Cast<GameObject>();
			GameObject? regularWolf_aurora = Resources.Load("WILDLIFE_Wolf_aurora")?.Cast<GameObject>();
			if (regularWolf && regularWolf_aurora)
			{
				spawnRegion.m_AuroraSpawnablePrefab = regularWolf_aurora;
				spawnRegion.m_SpawnablePrefab = regularWolf;
			}
		}

        private static void MakeRandomWolves(SpawnRegion spawnRegion)
        {
            if (Utils.RollChance(Settings.instance.regularWolfPercentage))
            {
                MakeRegularWolves(spawnRegion);
            }
            else
            {
                MakeTimberwolves(spawnRegion);
            }
        }

        private static void AdjustTimberwolfPackSize(SpawnRegion spawnRegion)
        {
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
            return num == 1 ? 2 : num;
        }
    }
}
