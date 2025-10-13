using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabHotkeys
{

    [HarmonyPatch(typeof(ItemGrid), nameof(ItemGrid.Initialize))]   
    internal static class CorpseInspectWindow_Enable_Patch
    {

        public static void Prefix(ItemGrid __instance)
        {
            if(__instance.gameObject.GetComponent<ItemGridHook>() == null)
            {
                __instance.gameObject.AddComponent<ItemGridHook>();
                Plugin.Logger.Log("CorpseInspectWindow Attached");
            }

            Plugin.Logger.Log("CorpseInspectWindow Enable");
        }
    }
}
