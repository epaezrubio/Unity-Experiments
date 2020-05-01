using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementRecord
{
    public struct TimedEntry<T>
    {

        public float time;
        public T entry;
        public TimedEntry(float time, T entry)
        {
            this.time = time;
            this.entry = entry;
        }
    }
}