using System;
using UnityEngine;

[Serializable]
public class SprintingStateConfig
{
    [field: SerializeField, Range(0, 16)] public float Speed { get; private set; }
}