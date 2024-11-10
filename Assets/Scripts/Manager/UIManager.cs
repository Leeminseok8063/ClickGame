using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class UIManager : Singleton<UIManager>
    {
        public MainUIModule MainUIPanel;
        public bool isPanel = false;
        public void Init()
        {
            GameObject mainModule = Instantiate(Resources.Load<GameObject>("Prefabs/03.Module/MainUIModule"));
            mainModule.transform.parent = transform;
            MainUIPanel = mainModule.GetComponent<MainUIModule>();
        }

        public void IsPanel(bool state)
        {
            isPanel = state;
        }
    }
}
