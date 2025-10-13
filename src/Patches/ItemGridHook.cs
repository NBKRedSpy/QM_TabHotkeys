using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TabHotkeys.Patches
{
    internal class ItemGridHook : UpdateComponent<ItemGrid>
    {
        public static bool AnyIsHovered = false;
        public static bool FitsInView { get; private set; } = true;

        public bool IsHovered { get; set; }


        public override void Update()
        {

            if(IsHovered && Input.GetKeyDown(KeyCode.F3))
            {
                Plugin.Logger.Log($"AllVisibleSlots Count {Component.AllVisibleSlots.Count()}");
                Plugin.Logger.Log($"All items Count {Component._slots.Where(x => x?.DisplayItem != null).Count()}");
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            AnyIsHovered = false;
            IsHovered = false;
        }
        public override void OnPointerEnter(PointerEventData eventData)
        {
            AnyIsHovered = true;
            IsHovered = true;

            //todo:  needs to be specific to the target item grid instead of static.
            
            //the displays seem to favor 4 rows.  Close enough.
            //FitsInView = !Component.Storage._positions.Any(x => x == null || x.InventoryPos.Y > 4);
            FitsInView = Component.Storage.Empty || !Component.Storage._positions.Any(x => x?.InventoryPos.Y > 4);

        }   
    }
}
