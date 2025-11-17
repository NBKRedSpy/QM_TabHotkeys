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
            if (Component == null || Component.isActiveAndEnabled == false) return;  

            int index = _keys.FindIndex(x => InputHelper.GetKeyDown(x));
            if(index == -1) return;

            this.Component.TrySelectTabByIndex(index +1);
        }
    }
}
