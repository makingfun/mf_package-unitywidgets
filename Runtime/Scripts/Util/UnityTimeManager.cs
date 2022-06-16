using UnityEngine;

namespace Makingfun.UnityWidgets
{
    
    public class UnityTimeManager : ScriptableObject, TimeManager
    {
        public float Delta => Time.deltaTime;
    }
}