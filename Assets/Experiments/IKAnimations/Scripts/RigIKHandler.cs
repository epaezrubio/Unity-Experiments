using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace IKAnimations
{
    public class RigIKHandler : MonoBehaviour
    {

        [SerializeField]
        private List<Transform> handTargets;

        [SerializeField]
        private TwoBoneIKConstraint IKConstraint;

        [SerializeField]
        private Transform IKTarget;


        void Update()
        {
            Transform closest = GetClosestTarget(handTargets);

            IKTarget.position = closest.position;
            IKTarget.rotation = closest.rotation;

            float closestDistance = Vector3.Distance(closest.position, transform.position);

            if (closestDistance < 1.5f)
            {
                IKConstraint.weight = 1;
            }
            else if (closestDistance > 2)
            {
                IKConstraint.weight = 0;
            }
            else
            {
                IKConstraint.weight = 1 - Mathf.InverseLerp(1.5f, 2, closestDistance);
            }
        }

        private Transform GetClosestTarget(List<Transform> targets)
        {
            Transform closestTarget = targets[0];

            foreach (var target in targets)
            {
                if (Vector3.Distance(target.position, transform.position) < Vector3.Distance(closestTarget.position, transform.position))
                {
                    closestTarget = target;
                }
            }

            return closestTarget;
        }

        private float ExponentialIn (float k) {
			return k == 0f ? 0f : Mathf.Pow(100f, k - 1f);
		}
    }
}
