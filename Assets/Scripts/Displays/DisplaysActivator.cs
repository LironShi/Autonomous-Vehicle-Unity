using UnityEngine;

namespace Displays
{
    public class DisplaysActivator : MonoBehaviour
    {

        void Awake()
        {
            for (int i = 1; i < Display.displays.Length; i++)
            {
                Display.displays[i].Activate();
            }
        }
    }
}