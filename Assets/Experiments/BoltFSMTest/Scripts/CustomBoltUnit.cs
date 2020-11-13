using UnityEngine;
using System.Collections;
using Bolt;
using Ludiq;
using System.Collections.Generic;
using System;

namespace BoltFSMTest
{
    [UnitCategory("Custom")]
    [UnitShortTitle("Custom Bolt FSM")]
    public class CustomBoltUnit : Unit
    {
        [DoNotSerialize]
        public ValueInput self;

        [DoNotSerialize]
        public ValueInput state;

        [DoNotSerialize]
        public ControlInput onEnterState;

        [DoNotSerialize]
        public ControlInput onUpdate;

        [DoNotSerialize]
        public ControlInput onExitState;

        protected override void Definition()
        {
            self = ValueInput<GameObject>("gameObject");
            state = ValueInput<AbstractBoltState>("state");
            onEnterState = ControlInput("onEnterState", OnEnterState);
            onUpdate = ControlInput("onUpdate", OnUpdate);
            onExitState = ControlInput("onExitState", OnExitState);
        }

        private ControlOutput OnEnterState(Flow flow) 
        {
            GameObject go = flow.GetValue<GameObject>(self);
            AbstractBoltState stateComponent = go.GetComponent<AbstractBoltState>();

            stateComponent.OnEnterState();
            
            return null;
        }

        private ControlOutput OnUpdate(Flow flow)
        {
            GameObject go = flow.GetValue<GameObject>(state);
            AbstractBoltState stateComponent = go.GetComponent<AbstractBoltState>();

            stateComponent.OnUpdateState();

            return null;
        }

        private ControlOutput OnExitState(Flow flow)
        {
            GameObject go = flow.GetValue<GameObject>(state);
            AbstractBoltState stateComponent = go.GetComponent<AbstractBoltState>();

            stateComponent.OnExitState();

            return null;
        }
    }
}
