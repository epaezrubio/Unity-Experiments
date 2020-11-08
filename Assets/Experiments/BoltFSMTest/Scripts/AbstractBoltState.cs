using UnityEngine;
using System.Collections;

namespace BoltFSMTest
{
    abstract public class AbstractBoltState : MonoBehaviour
    {
        abstract public void OnEnterState();
        abstract public void OnUpdateState();
        abstract public void OnExitState();
    }
}