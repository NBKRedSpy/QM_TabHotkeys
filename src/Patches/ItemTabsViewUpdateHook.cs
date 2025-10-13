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

            //Component._idsToTabs[0].IsSelected;

            float mouseWheelDir = Input.GetAxisRaw("Mouse ScrollWheel");
            if (mouseWheelDir == 0) return;



            (int tabIndex, ItemTab currentTab) = Component._idsToTabs.FirstOrDefault(x => x.Value.IsSelected);

            if (currentTab == null) return;


            //TODO:  this is not working.  I need the link to the itemgrid to the actual tab. 
            //  Tomorrow:  I think the tabs are independent of the item grid, but not sure how that works.
            //  CorpseInspectWindow has an _itemGrid and a Refresh(bool show, ItemTab tab).
            //  It may be screen specific because Refresh calls Configure which calls _itemGrid.Initialize(_inventory.BackpackStore).


            MonoBehaviour content = Component._idsToContent[tabIndex] as MonoBehaviour;

            ItemGridHook itemGridHook = 
                (currentTab?.Content as MonoBehaviour)
                ?.gameObject
                .GetComponent<ItemGridHook>();

            if (itemGridHook == null || !itemGridHook.IsHovered || !itemGridHook.FitsInView) return;



            int newIndex = tabIndex + (mouseWheelDir < 0 ? 1 : -1);
            Component.TrySelectTabByIndex(newIndex);


            //if ((ItemGridHook.AnyIsHovered == false || ItemGridHook.FitsInView) && mouseWheelDir != 0)
            //{
            //    int selectedTabIndex = Component._idsToTabs.FirstOrDefault(x => x.Value.IsSelected).Key;

            //    int newIndex = selectedTabIndex + (mouseWheelDir < 0 ? 1 : -1);
            //    Component.TrySelectTabByIndex(newIndex);
            //}
            //else
            //{
            //    int index = _keys.FindIndex(x => InputHelper.GetKeyDown(x));
            //    if (index == -1) return;

            //    Component.TrySelectTabByIndex(index + 1);

            //}
        }
    }
}
