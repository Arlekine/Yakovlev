using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW_3.Task_3
{
    public class SpawnPointsHolder : IPointsHolder
    {
        private class Point
        {
            private Vector3 _position;

            public Point(Vector3 position)
            {
                _position = position;
            }

            public Vector3 Position => _position;
        }

        private List<Point> _freePoints = new List<Point>();

        public SpawnPointsHolder(IEnumerable<Vector3> spawnPositions)
        {
            foreach (var spawnPosition in spawnPositions)
            {
                _freePoints.Add(new Point(spawnPosition));
            }
        }

        public bool HasFreePoints() => _freePoints.Count > 0;

        public Vector3 GetAndOccupyRandomPoint(AtomicEvent freeingCondition)
        {
            if (HasFreePoints() == false)
                throw new Exception($"This {nameof(SpawnPointsHolder)} doesn't have free points");

            var point = _freePoints.GetRandomItem();

            _freePoints.Remove(point);

            freeingCondition.Subscribe(() => FreePoint(point));

            return point.Position;
        }

        private void FreePoint(Point point)
        {
            _freePoints.Add(point);
        }
    }
}