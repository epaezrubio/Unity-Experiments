using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementRecord
{
    public struct VelocityStruct : IRecordable
    {
        public float horizontal;
        public float vertical;
        public VelocityStruct(float horizontal, float vertical)
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
        }
    }

    [RequireComponent(typeof(UserController))]
    public class InputManager : MonoBehaviour
    {
        private RecordManager<VelocityStruct> recordManager = new RecordManager<VelocityStruct>();
        private PlayBackManager<VelocityStruct> playbackManager = new PlayBackManager<VelocityStruct>();
        private UserController userController;

        private float lastHorizontal = 0;
        private float lastVertical = 0;

        private void Update()
        {


            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (playbackManager.isPlayingBack)
                {
                    playbackManager.StopPlayBack();
                }
                else
                {
                    playbackManager.SetRecodedEntries(recordManager.GetEntries());
                    playbackManager.StartPlayBack();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (recordManager.isRecording)
                {
                    recordManager.StopRecord();
                }
                else
                {
                    recordManager.StartRecord();
                }
            }

            if (recordManager.isRecording)
            {
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");

                userController.SetVelocities(vertical, horizontal);

                if (horizontal != lastHorizontal || vertical != lastVertical)
                {
                    lastHorizontal = horizontal;
                    lastVertical = vertical;

                    recordManager.AddEntry(new VelocityStruct(horizontal, vertical));
                }
            }

            if (playbackManager.isPlayingBack)
            {
                List<TimedEntry<VelocityStruct>> newEntries = playbackManager.GetNewPlayBackEntries();

                if (newEntries.Count > 0)
                {
                    VelocityStruct entry = newEntries[newEntries.Count - 1].entry;

                    userController.SetVelocities(entry.vertical, entry.horizontal);
                }
            }
        }

        private void Start()
        {
            userController = GetComponent<UserController>();
        }
    }
}
