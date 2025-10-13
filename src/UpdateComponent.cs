using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TabHotkeys
{
    public abstract class UpdateComponent<T> : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
        where T: MonoBehaviour
    {

        public T Component { get; set; }

        public abstract void Update();

        public void OnDestroy()
        {
            Component = null;
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {   
        }
    }
}
