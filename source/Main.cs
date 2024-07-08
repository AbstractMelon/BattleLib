using BepInEx;
using HarmonyLib;
using System;

namespace BattleLib
{
    [BepInPlugin("com.Melon.BattleLib", "BattleLib", "1.0.0")]
    public class BattleLib : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("com.Melon.BattleLib");

        private void Awake()
        {
            Logger.LogInfo("BattleLib is loaded!");
            ConfigManager.Initialize(Config);
            harmony.PatchAll();
        }

        private void OnDestroy()
        {
            harmony.UnpatchSelf();
            Logger.LogInfo("BattleLib is unloaded!");
        }
    }
}
