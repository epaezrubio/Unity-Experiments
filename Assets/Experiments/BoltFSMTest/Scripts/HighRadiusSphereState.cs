using Bolt;
using Ludiq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoltFSMTest
{
    public class HighRadiusSphereState : AbstractBoltState
    {
        public override void OnEnterState()
        {
            Debug.Log("High Radius State Entered");
        }

        public override void OnUpdateState()
        {
            transform.position = new Vector3(2, 0, 2);
        }

        public override void OnExitState()
        {
            Debug.Log("High Radius State Exited");
        }
    }
}
