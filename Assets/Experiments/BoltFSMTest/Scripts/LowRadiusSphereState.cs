using Bolt;
using Ludiq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoltFSMTest
{
    public class LowRadiusSphereState : AbstractBoltState
    {
        private StateMachine stateMachine;
        private GraphReference graphReference;

        public override void OnEnterState()
        {
            Debug.Log("High Radius State Entered");
        }

        public override void OnUpdateState()
        {
            transform.position = new Vector3(1, 0, 1);
        }

        public override void OnExitState()
        {
            Debug.Log("High Radius State Exited");
        }
    }
}
