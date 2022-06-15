using System;
using UnityEngine;

namespace Makingfun.UnityWidgets
{
    public class Timer
    {
        public float duration { get; }
        public float remaining { get; private set; }
        public event Action Expired;
        
        // public event Action Expired;

        
        bool active;
        readonly TimeManager time;

        public Timer(TimeManager time, float duration)
        {
            this.duration = duration;
            this.time = time;
            remaining = duration;
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