using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabHotkeys.Patches
{

    [HarmonyPatch(typeof(ItemGrid), nameof(ItemGrid.Initialize))]   
    internal static class ItemGrid_Initialize_Patch
    {

        public static void Prefix(ItemGrid __instance)
        {
            if(__instance.gameObject.GetComponent<ItemGridHook>() == null)
            {
                (__instance.gameObject.AddComponent<ItemGridHook>()).Component = __instance;
            }
        }
    }
}
