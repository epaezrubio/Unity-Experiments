using UnityEngine;
using System.Collections;
using Bolt;
using Ludiq;
using System.Collections.Generic;
using System;

namespace BoltFSMTest
{
    [UnitCategory("Custom")]
    [UnitShortTitle("Custom Bolt Unit")]
    public class GenericBoltUnit : Unit 
    {
        [DoNotSerialize]
        public ControlInput onUpdate;

        protected override void Definition()
        {
            onUpdate = ControlInput("On update", OnUpdate);
        }

        public ControlOutput OnUpdate(Flow flow)
        {
            Debug.Log(typeof(GenericBoltUnit));

            return null;
        }
    }
}
