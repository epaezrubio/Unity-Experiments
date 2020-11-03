using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace IKAnimations
{
    public class RigIKHandler : MonoBehaviour
    {
        [SerializeField]
        private float reactionDistance = 4f;

        [SerializeField]
        private List<Transform> leftHandTargets;
        [SerializeField]
        private List<Transform> rightHandTargets;

        [SerializeField]
        private TwoBoneIKConstraint leftIKConstraint;
        [SerializeField]
        private TwoBoneIKConstraint rightIKConstraint;

        [SerializeField]
        private Transform leftIKTarget;
        [SerializeField]
        private Transform rightIKTarget;


        void Update()
        {
            Transform closestLeft = GetClosestTarget(leftHandTargets);
            Transform closestRight = GetClosestTarget(rightHandTargets);

            leftIKTarget.position = closestLeft.position;
            leftIKTarget.rotation = closestLeft.rotation;
            rightIKTarget.position = closestRight.position;
            rightIKTarget.rotation = closestRight.rotation;

            float leftDistance = Vector3.Distance(closestLeft.position, transform.position);
            float rightDistance = Vector3.Distance(closestRight.position, transform.position);

            if (leftDistance < 1.5f)
            {
                leftIKConstraint.weight = 1;
            }
            else if (leftDistance > 2)
            {
                leftIKConstraint.weight = 0;
            }
            else
            {
                leftIKConstraint.weight = 1 - Mathf.InverseLerp(1.5f, 2, leftDistance);
            }

            if (rightDistance < 1.5f)
            {
                rightIKConstraint.weight = 1;
            }
            else if (rightDistance > 2)
            {
                rightIKConstraint.weight = 0;
            }
            else
            {
                rightIKConstraint.weight = 1 - Mathf.InverseLerp(1.5f, 2, rightDistance);
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
