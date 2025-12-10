using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentData", menuName = "Scriptable Objects/EnvironmentData")]
public class EnvironmentData : ScriptableObject
{
    public List<SpawnEntry> prefabHolder;
    public AudioClip info;
    public AudioClip correct;
    public AudioClip wrong;
}
