using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsHolder : MonoBehaviour
{
    [SerializeField] private List<Transform> _points = new List<Transform>();

    public IReadOnlyList<Transform> Points => _points;
}