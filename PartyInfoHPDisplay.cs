using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party_Info_HP_Display {
    internal static class ModInfo {
        internal const string Guid = "air1068.elin.partyinfohpdisplay";
        internal const string Name = "Party Info HP Display";
        internal const string Version = "0.1.0";
    }

    [BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
    public class Party_Info_HP_Display : BaseUnityPlugin {
        private void Awake() {
            var harmony = new Harmony(ModInfo.Guid);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(ButtonRoster), nameof(ButtonRoster.Refresh))]
    class ButtonRoster_Refresh_Patch {
        static void Postfix(ButtonRoster __instance) {
            if (__instance.roster.extra.onlyName) {
                __instance.textName.SetText(__instance.chara.NameSimple + " (" + __instance.chara.hp.ToString() + "/" + __instance.chara.MaxHP.ToString() + ")");
            } else {
                __instance.textName.SetText("(" + __instance.chara.hp.ToString() + "/" + __instance.chara.MaxHP.ToString() + ")");
                __instance.textName.SetActive(true);
            }
        }
    }
}
