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

            int index = _keys.FindIndex(x => InputHelper.GetKeyDown(x));
            if(index == -1) return;

            if (index >= Component.TabsCount) return;

            ItemTab tab = Component._idsToTabs[index + 1];

            //Warning COPY: This is a copy of the same logic in MGSC.ItemTabsView.SelectAndShowFirstTab()

            //The game requires the selected tab to be enabled last.  Otherwise the tab's content will not 
            //  be rendered.
            foreach (KeyValuePair<int, ItemTab> idsToTab in Component._idsToTabs.Where(x => x.Value != tab))
            {
                idsToTab.Value.Select(idsToTab.Value == tab);
            }

            tab.Select(true);
        }

    }
}
