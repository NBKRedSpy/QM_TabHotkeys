using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TabHotkeys
{
    internal class ItemTabsViewUpdateHook : UpdateComponent<ItemTabsView>
    {
        internal static List<KeyCode> _keys; 

        override public void Update()
        {
            if(Component == null || Component.isActiveAndEnabled == false) return;  

            int index = _keys.FindIndex(x => Input.GetKey(x));
            if(index == -1) return;

            if (index >= Component.TabsCount) return;

            ItemTab tab = Component._idsToTabs[index + 1];

            //Warning COPY: This is a copy of the same logic in MGSC.ItemTabsView.SelectAndShowFirstTab()

            //I think this is just setting everything but the tab to not selected...
            foreach (KeyValuePair<int, ItemTab> idsToTab in Component._idsToTabs)
            {
                idsToTab.Value.Select(idsToTab.Value == tab);
            }
        }

    }
}
