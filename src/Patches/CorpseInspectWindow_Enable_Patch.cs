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

            //I'm not sure why this returns null.
            //if(__instance.gameObject.GetComponent<ItemGridHook>() == null)
            //{
            //    (__instance.gameObject.AddComponent<ItemGridHook>()).Component = __instance;
            //}

            ItemGridHook itemGridHook = (ItemGridHook)__instance.gameObject.GetComponents<object>().FirstOrDefault(x => x is ItemGridHook);

            if (itemGridHook == null)
            {
                itemGridHook = __instance.gameObject.AddComponent<ItemGridHook>();
                itemGridHook.Component = __instance;
            }
        }
    }
}
