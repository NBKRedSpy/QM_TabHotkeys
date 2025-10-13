using MGSC;
using Rewired.Demos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TabHotkeys
{
    internal class ItemTabsViewUpdateHook : UpdateComponent<ItemTabsView>, IPointerEnterHandler, 
        IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
    {
        internal static List<KeyCode> _keys;

        //public void OnPointerClick(PointerEventData eventData)
        //{
        //    Plugin.Logger.Log($"Clicked on: {eventData.pointerCurrentRaycast.gameObject?.name}");    
        //}

        //public void OnPointerEnter(PointerEventData eventData)
        //{
        //    Plugin.Logger.Log($"Pointer entered on: {eventData.pointerCurrentRaycast.gameObject?.name}");
        //}

        //public void OnPointerExit(PointerEventData eventData)
        //{
        //    Plugin.Logger.Log($"Pointer exited on: {eventData.pointerCurrentRaycast.gameObject?.name}");
        //}

        override public void Update()
        {
            if (Component == null || Component.isActiveAndEnabled == false) return;

            float mouseWheelDir = Input.GetAxisRaw("Mouse ScrollWheel");

            if (ItemGridHook.IsHovered == false && mouseWheelDir != 0)
            {
                int selectedTabIndex = this.Component._idsToTabs.FirstOrDefault(x => x.Value.IsSelected).Key;

                int newIndex = selectedTabIndex + (mouseWheelDir > 0 ? 1 : -1);
                this.Component.TrySelectTabByIndex(newIndex);
            }
            else
            {
                int index = _keys.FindIndex(x => InputHelper.GetKeyDown(x));
                if (index == -1) return;

                this.Component.TrySelectTabByIndex(index + 1);

            }
        }
    }
}
