using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LC_Boombox_Mod.Patches;

namespace LC_Boombox_Pocket_Patch
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class LCBoomboxPocketMod : BaseUnityPlugin
    {

        private const string modGUID = "TeletubbyPo.BoomboxAlwaysPlay";
        private const string modName = "LC Boombox Pocket Play";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static LCBoomboxPocketMod Instance;

        internal ManualLogSource modLogger;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            modLogger = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            modLogger.LogInfo("Boombox Pocket Player Loaded Successfully!");

            harmony.PatchAll(typeof(BoomboxItemPatch));
            
        }
    }
}
