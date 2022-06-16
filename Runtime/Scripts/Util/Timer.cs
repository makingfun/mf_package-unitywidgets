using System;
using UnityEngine;

namespace Makingfun.UnityWidgets
{
    public class Timer
    {
        public float Duration { get; }
        public float Remaining { get; private set; }
        public event Action Expired;
        
        bool active;
        readonly TimeManager time;

        public Timer(TimeManager time, float duration)
        {
            Duration = duration;
            this.time = time;
            Remaining = duration;
        }

        public void Start() => active = true;

        public void Update()
        {            
            Remaining = Mathf.Max(Remaining - time.Delta, 0);
            if (Remaining == 0 && active)
            {
                active = false;
                Expired?.Invoke();
            }
        }
    }
}