using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabHotkeys
{

    [HarmonyPatch(typeof(CorpseInspectWindow), nameof(CorpseInspectWindow.OnEnable))]   
    internal static class CorpseInspectWindow_Enable_Patch
    {

        public static void Prefix(CorpseInspectWindow __instance)
        {

            if(__instance._itemGrid.gameObject.GetComponent<ItemGridHook>() == null)
            {
                __instance._itemGrid.gameObject.AddComponent<ItemGridHook>();
                Plugin.Logger.Log("CorpseInspectWindow Attached");
            }

            Plugin.Logger.Log("CorpseInspectWindow Enable");
        }
    }
}
