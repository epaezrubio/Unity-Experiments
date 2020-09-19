using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OculusDoor
{
    public class Door : MonoBehaviour
    {
        private Coroutine openDoorRoutine = null;

        [SerializeField]
        private Animator animator;

        public void Open()
        {
            animator.SetBool("open", true);
            ScheduleClose();
        }
        
        public void ScheduleClose()
        {
            if (openDoorRoutine != null)
            {
                StopCoroutine(openDoorRoutine);
            }

            openDoorRoutine = StartCoroutine(OpenDoorCoroutine());
        }

        public void Close()
        {
            animator.SetBool("open", false);
        }

        private IEnumerator OpenDoorCoroutine()
        {
            yield return new WaitForSeconds(2);
            Close();
        }

    }
}
