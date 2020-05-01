using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementRecord
{
    public class RecordManager<T> where T : IRecordable
    {

        public bool isRecording = false;

        private float recordingStart;
        private float recordingEnd;

        private List<TimedEntry<T>> recordedEntries = new List<TimedEntry<T>>() { };

        public void StartRecord()
        {
            isRecording = true;
            recordingStart = Time.time;

            Debug.Log("isRecording true");
        }

        public void StopRecord()
        {
            isRecording = false;
            recordingEnd = Time.time;

            Debug.Log("isRecording false");
            Debug.Log("Time ellapsed " + (recordingEnd - recordingStart).ToString());
        }

        public void AddEntry(T entry)
        {
            TimedEntry<T> t = new TimedEntry<T>(Time.time - recordingStart, entry);

            recordedEntries.Add(t);
        }

        public List<TimedEntry<T>> GetEntries()
        {
            return recordedEntries;
        }

    }
}