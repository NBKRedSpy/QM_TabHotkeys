using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace TabHotkeys
{
    internal class ItemGridHook : UpdateComponent<ItemGrid>
    {

        public static bool IsHovered = false;

        public override void Update()
        {
            
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            IsHovered = false;
        }
        public override void OnPointerEnter(PointerEventData eventData)
        {
            IsHovered = true;
        }   
    }
}
