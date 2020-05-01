using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementRecord
{
    public class PlayBackManager<T> where T : IRecordable
    {
        public bool isPlayingBack = false;

        private float playBackStart;
        private float playBackEnd;

        private TimedEntry<T> lastReturnedEntry;

        private List<TimedEntry<T>> recordedEntries = new List<TimedEntry<T>>() { };

        public void SetRecodedEntries(List<TimedEntry<T>> recordedEntries) {
            this.recordedEntries = recordedEntries;
        }

        public void StartPlayBack()
        {
            isPlayingBack = true;
            playBackStart = Time.time;
        }

        public void StopPlayBack()
        {
            isPlayingBack = false;
            playBackEnd = Time.time;
        }

        public List<TimedEntry<T>> GetNewPlayBackEntries()
        {
            List<TimedEntry<T>> inPeriodEntries = new List<TimedEntry<T>>() { };

            float lastReturnedEntryTime = lastReturnedEntry.entry == null ? 0 : lastReturnedEntry.time;

            foreach (TimedEntry<T> entry in recordedEntries)
            {
                if (entry.time > Time.time - playBackStart)
                {
                    break;
                }

                if (entry.time > lastReturnedEntryTime && entry.time < Time.time - playBackStart)
                {
                    inPeriodEntries.Add(entry);

                    lastReturnedEntry = entry;
                }
            }
    
            return inPeriodEntries;
        }
    }
}