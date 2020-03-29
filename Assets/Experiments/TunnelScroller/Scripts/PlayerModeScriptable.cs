using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerModeScriptable : ScriptableObject
{

    [SerializeField]
    public string matchingTag;

    [SerializeField]
    public Material material;
}
