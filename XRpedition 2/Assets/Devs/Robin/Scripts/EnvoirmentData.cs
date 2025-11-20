using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentData", menuName = "Scriptable Objects/EnvironmentData")]
public class EnvironmentData : ScriptableObject
{
    [SerializeField] private List<SpawnEntry> prefabHolder;
}
