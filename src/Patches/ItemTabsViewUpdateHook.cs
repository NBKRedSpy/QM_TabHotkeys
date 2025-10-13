using MGSC;
using Rewired.Demos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TabHotkeys.Patches
{
    internal class ItemTabsViewUpdateHook : UpdateComponent<ItemTabsView>, IPointerEnterHandler, 
        IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
    {
        internal static List<KeyCode> _keys;

        override public void Update()
        {
            if (Component == null || Component.isActiveAndEnabled == false) return;

            float mouseWheelDir = Input.GetAxisRaw("Mouse ScrollWheel");

            if ((ItemGridHook.AnyIsHovered == false || ItemGridHook.FitsInView) && mouseWheelDir != 0)
            {
                int selectedTabIndex = Component._idsToTabs.FirstOrDefault(x => x.Value.IsSelected).Key;

                int newIndex = selectedTabIndex + (mouseWheelDir < 0 ? 1 : -1);
                Component.TrySelectTabByIndex(newIndex);
            }
            else
            {
                int index = _keys.FindIndex(x => InputHelper.GetKeyDown(x));
                if (index == -1) return;

                Component.TrySelectTabByIndex(index + 1);

            }
        }
    }
}
