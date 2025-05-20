using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TabHotkeys
{
    [HarmonyPatch(typeof(ItemTabsView), nameof(ItemTabsView.AddTab))]
    public static class ItemTabsView_AddTab_Patch
    {
        public static void Prefix(ItemTabsView __instance)
        {
            //Hack.  Every screen that uses this view will always add a tab first.
            //Use this to attach they key monitor.

            const string GameObjectName = "SortToTabsUpdateObject";

            if (__instance.GetComponent<UpdateComponent<ItemTabsView>>() != null) return;

            //Do not use hotkeys on the inventory screen during loadout.  
            //Due to there possibly being a shuttle tab.  Otherwise pressing the 2 key would
            //the tabs on both sides change.
            if (__instance._tabsRoot.parent.name == "InventoryWindow") return;


            UpdateComponent<ItemTabsView> update = __instance.gameObject.AddComponent<ItemTabsViewUpdateHook>();
            update.name = GameObjectName;
            update.Component = __instance;

        }
    }
}
