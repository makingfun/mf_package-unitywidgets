using System;
using UnityEngine;

namespace Makingfun.UnityWidgets
{
    public class Timer
    {
        public float duration { get; private set; }
        public float remaining { get; private set; }
        public event Action Expired;
        
        bool active;
        TimeManager time;

        public Timer(TimeManager time, float duration)
        {
            this.duration = duration;
            remaining = duration;
            this.time = time;
        }

        public void Start() => active = true;

        public void Update()
        {            
            remaining = Mathf.Max(remaining - time.delta, 0);
            if (remaining == 0 && active)
            {
                active = false;
                Expired?.Invoke();
            }
        }
    }
}