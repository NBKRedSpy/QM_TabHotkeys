using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TabHotkeys
{
    public abstract class UpdateComponent<T> : MonoBehaviour where T: MonoBehaviour
    {

        public T Component { get; set; }

        public abstract void Update();

        public void OnDestroy()
        {
            Component = null;
        }
    }
}
