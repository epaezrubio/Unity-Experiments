using Bolt;
using Ludiq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoltFSMTest
{
    public class MovingSphereState : AbstractBoltState
    {
        private StateMachine stateMachine;
        private GraphReference graphReference;

        public override void OnEnterState()
        {
            stateMachine = GetComponent<StateMachine>();
            graphReference = GraphReference.New(stateMachine, true);
        }

        public override void OnUpdateState()
        {
            transform.position = new Vector3(
                Mathf.Sin(Time.time) * Variables.ActiveScene.Get<float>("x_radius"),
                0,
                Mathf.Cos(Time.time) * Variables.ActiveScene.Get<float>("z_radius"));
        }

        public override void OnExitState()
        {
            Debug.Log("ON EXIT STATE");
        }
    }
}
